using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Projesi.Models;
using Web_Projesi.Attributes;

namespace Web_Projesi.Controllers
{
    [Admin]
    public class AdminController : Controller
    {
        private readonly KelimeOgrenmeDbContext _context;

        public AdminController(KelimeOgrenmeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Admin rolü kontrolü
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var viewModel = new AdminDashboardViewModel
            {
                KullaniciSayisi = _context.Kullanicilar?.Count() ?? 0,
                KelimeSayisi = _context.Kelimeler?.Count() ?? 0,
                KategoriSayisi = _context.Kategoriler?.Count() ?? 0,
                QuizSayisi = _context.Quizler?.Count() ?? 0
            };

            return View(viewModel);
        }

        // Kelime Yönetimi
        public IActionResult Kelimeler()
        {
            var kelimeler = _context.Kelimeler?
                .Select(k => new KelimeYonetimViewModel
                {
                    KelimeID = k.KelimeID,
                    KelimeAdi = k.KelimeAdi,
                    Tanim = k.Tanim,
                    Tur = k.Tur,
                    OrnekCumle = k.OrnekCumle
                })
                .ToList() ?? new List<KelimeYonetimViewModel>();

            return View(kelimeler);
        }

        public IActionResult KelimeEkle()
        {
            return View(new KelimeYonetimViewModel());
        }

        [HttpPost]
        public IActionResult KelimeEkle(KelimeYonetimViewModel model)
        {
            if (ModelState.IsValid && _context.Kelimeler != null)
            {
                var kelime = new Kelimeler
                {
                    KelimeAdi = model.KelimeAdi,
                    Tanim = model.Tanim,
                    Tur = model.Tur,
                    OrnekCumle = model.OrnekCumle ?? string.Empty
                };

                _context.Kelimeler.Add(kelime);
                _context.SaveChanges();
                return RedirectToAction(nameof(Kelimeler));
            }
            return View(model);
        }

        public IActionResult KelimeDuzenle(int id)
        {
            var kelime = _context.Kelimeler?
                .Where(k => k.KelimeID == id)
                .Select(k => new KelimeYonetimViewModel
                {
                    KelimeID = k.KelimeID,
                    KelimeAdi = k.KelimeAdi,
                    Tanim = k.Tanim,
                    Tur = k.Tur,
                    OrnekCumle = k.OrnekCumle
                })
                .FirstOrDefault();

            if (kelime == null)
            {
                return NotFound();
            }

            return View(kelime);
        }

        [HttpPost]
        public IActionResult KelimeDuzenle(int id, KelimeYonetimViewModel model)
        {
            if (id != model.KelimeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid && _context.Kelimeler != null)
            {
                var kelime = new Kelimeler
                {
                    KelimeID = model.KelimeID,
                    KelimeAdi = model.KelimeAdi,
                    Tanim = model.Tanim,
                    Tur = model.Tur,
                    OrnekCumle = model.OrnekCumle ?? string.Empty
                };

                _context.Kelimeler.Update(kelime);
                _context.SaveChanges();
                return RedirectToAction(nameof(Kelimeler));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult KelimeSil(int id)
        {
            var kelime = _context.Kelimeler?.Find(id);
            if (kelime != null)
            {
                _context.Kelimeler?.Remove(kelime);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Kelimeler));
        }

        // Kullanıcı Yönetimi
        public IActionResult Kullanicilar()
        {
            var kullanicilar = _context.Kullanicilar?
                .Select(k => new KullaniciYonetimViewModel
                {
                    KullaniciID = k.KullaniciID,
                    KullaniciAdi = k.KullaniciAdi,
                    Eposta = k.Eposta,
                    Ad = k.Ad,
                    Soyad = k.Soyad,
                    Durum = k.Durum
                })
                .ToList() ?? new List<KullaniciYonetimViewModel>();

            return View(kullanicilar);
        }

        [HttpPost]
        public IActionResult KullaniciDurumGuncelle(int id, string durum)
        {
            var kullanici = _context.Kullanicilar?.Find(id);
            if (kullanici != null)
            {
                kullanici.Durum = durum;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Kullanicilar));
        }

        [HttpPost]
        public IActionResult KullaniciSil(int id)
        {
            var kullanici = _context.Kullanicilar?.Find(id);
            if (kullanici != null && kullanici.KullaniciAdi != "admin")
            {
                // İlişkili quiz sonuçlarını da sil
                var quizler = _context.Quizler?.Where(q => q.KullaniciID == id);
                if (quizler != null)
                {
                    _context.Quizler?.RemoveRange(quizler);
                }

                // İlişkili ilerleme kayıtlarını sil
                var ilerlemeler = _context.KullaniciIlerlemesi?.Where(i => i.KullaniciID == id);
                if (ilerlemeler != null)
                {
                    _context.KullaniciIlerlemesi?.RemoveRange(ilerlemeler);
                }

                // Kullanıcıyı sil
                _context.Kullanicilar?.Remove(kullanici);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Kullanicilar));
        }

        // Quiz İstatistikleri
        public IActionResult QuizIstatistikleri()
        {
            var quizler = _context.Quizler?
                .Include(q => q.Kullanici)
                .OrderByDescending(q => q.Puan)
                .Take(10)
                .Select(q => new QuizIstatistikleriViewModel
                {
                    QuizID = q.QuizID,
                    KullaniciAdi = q.Kullanici != null ? q.Kullanici.KullaniciAdi : "Bilinmiyor",
                    Puan = q.Puan,
                    Tarih = q.Tarih
                })
                .ToList() ?? new List<QuizIstatistikleriViewModel>();

            return View(quizler);
        }
    }
}