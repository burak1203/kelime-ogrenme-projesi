using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Projesi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Web_Projesi.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly KelimeOgrenmeDbContext _context;
        private static readonly Random _random = new Random();

        public QuizController(KelimeOgrenmeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Oturum kontrolü
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                TempData["ErrorMessage"] = "Quiz'e erişmek için giriş yapmalısınız.";
                return RedirectToAction("Login", "Account");
            }

            // Tüm kelimeleri getir
            var tumKelimeler = _context.Kelimeler?.ToList();
            if (tumKelimeler == null || !tumKelimeler.Any())
            {
                return View(new List<QuizViewModel>());
            }

            // Rastgele 10 kelime seç
            var kelimeler = tumKelimeler
                .OrderBy(x => _random.Next())
                .Take(10)
                .ToList();

            var quizSorulari = kelimeler.Select(k => new QuizViewModel
            {
                KelimeID = k.KelimeID,
                KelimeAdi = k.KelimeAdi,
                Tanim = k.Tanim,
                OrnekCumle = k.OrnekCumle,
                KullaniciCevabi = string.Empty
            }).ToList();

            return View(quizSorulari);
        }

        [HttpPost]
        public IActionResult KontrolEt(List<QuizViewModel> model)
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            var kullaniciID = HttpContext.Session.GetInt32("UserID");
            if (!kullaniciID.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            int dogruSayisi = 0;
            var sonuclar = new List<QuizSoruSonuc>();

            foreach (var soru in model)
            {
                var kelime = _context.Kelimeler?.FirstOrDefault(k => k.KelimeID == soru.KelimeID);
                if (kelime != null)
                {
                    bool dogruMu = !string.IsNullOrEmpty(soru.KullaniciCevabi) &&
                                 kelime.Tanim.Equals(soru.KullaniciCevabi.Trim(), StringComparison.OrdinalIgnoreCase);
                    if (dogruMu) dogruSayisi++;

                    sonuclar.Add(new QuizSoruSonuc
                    {
                        KelimeAdi = kelime.KelimeAdi,
                        DogruCevap = kelime.Tanim,
                        KullaniciCevabi = soru.KullaniciCevabi,
                        DogruMu = dogruMu
                    });
                }
            }

            // Quiz sonucunu veritabanına kaydet
            var quiz = new Quiz
            {
                KullaniciID = kullaniciID.Value,
                Tarih = DateTime.Now,
                Puan = dogruSayisi * 10, // Her doğru cevap 10 puan
                DogruSayisi = dogruSayisi,
                ToplamSoru = model.Count
            };
            _context.Quizler?.Add(quiz);
            _context?.SaveChanges();

            //VIEWBAG
            ViewBag.Puan = $"{dogruSayisi} / {model.Count}";
            var sonucModel = new QuizSonucViewModel
            {
                ToplamPuan = quiz.Puan,
                Sonuclar = sonuclar
            };

            return View("Sonuc", sonucModel);
        }
    }
}
