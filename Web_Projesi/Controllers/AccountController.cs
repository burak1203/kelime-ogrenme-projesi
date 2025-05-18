using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Web_Projesi.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Web_Projesi.Services;

namespace Web_Projesi.Controllers
{
    public class AccountController : Controller
    {
        private readonly KelimeOgrenmeDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SOAService _soaService;

        public AccountController(KelimeOgrenmeDbContext context, IHttpContextAccessor httpContextAccessor, SOAService soaService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _soaService = soaService;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var kullanici = _context.Kullanicilar?
                    .FirstOrDefault(k => k.Eposta == model.Email && k.Sifre == model.Password);

                if (kullanici != null)
                {
                    if (kullanici.Durum == "Pasif")
                    {
                        ModelState.AddModelError("", "Hesabınız pasif durumdadır. Lütfen yönetici ile iletişime geçin.");
                        return View(model);
                    }

                    HttpContext.Session.SetString("UserName", kullanici.KullaniciAdi);
                    HttpContext.Session.SetString("UserRole", kullanici.Rol ?? "Kullanici");
                    HttpContext.Session.SetInt32("UserID", kullanici.KullaniciID);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                        new Claim(ClaimTypes.Role, kullanici.Rol ?? "Kullanici"),
                        new Claim(ClaimTypes.NameIdentifier, kullanici.KullaniciID.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                    };

                    await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                    if (kullanici.Rol == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Quiz");
                }

                ModelState.AddModelError("", "Geçersiz e-posta veya şifre");
            }

            return View(model);
        }

        // POST: Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid && _context.Kullanicilar != null)
            {
                try
                {
                    // E-posta kontrolü
                    if (_context.Kullanicilar.Any(k => k.Eposta == model.Email))
                    {
                        ModelState.AddModelError("", "Bu e-posta adresi zaten kullanımda.");
                        return View(model);
                    }

                    // TC Kimlik bilgilerini düzgün formatta hazırla
                    var temizAd = model.Ad.Trim();
                    var temizSoyad = model.Soyad.Trim();
                    var tcKimlik = long.Parse(model.TCKimlik.Trim());

                    // TC Kimlik doğrulama
                    bool dogrulamaSonucu = await _soaService.DogrulaAsync(
                        tcKimlik,
                        temizAd,
                        temizSoyad,
                        model.DogumTarihi.Year
                    );

                    if (!dogrulamaSonucu)
                    {
                        ModelState.AddModelError("", "Kimlik doğrulama başarısız. Lütfen bilgilerinizi kontrol edin.");
                        return View(model);
                    }

                    // Yeni kullanıcı oluştur
                    var yeniKullanici = new Kullanicilar
                    {
                        KullaniciAdi = model.Email.Split('@')[0], // E-postadan kullanıcı adı oluştur
                        Eposta = model.Email,
                        Sifre = model.Password,
                        Ad = temizAd,
                        Soyad = temizSoyad,
                        TCKimlik = model.TCKimlik,
                        DogumTarihi = model.DogumTarihi,
                        Rol = "Kullanici", // Varsayılan rol
                        Durum = "Aktif" // Varsayılan durum
                    };

                    _context.Kullanicilar.Add(yeniKullanici);
                    await _context.SaveChangesAsync();

                    // Başarılı kayıt sonrası login sayfasına yönlendir
                    TempData["Success"] = "Kayıt işlemi başarılı. Lütfen giriş yapın.";
                    return RedirectToAction(nameof(Login));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Detaylı hata: {ex}");
                    ModelState.AddModelError("", "Kayıt işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                }
            }

            return View(model);
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
