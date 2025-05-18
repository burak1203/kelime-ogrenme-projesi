using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Projesi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web_Projesi.Controllers
{
    [Authorize]
    public class QuizGecmisiController : Controller
    {
        private readonly KelimeOgrenmeDbContext _context;

        public QuizGecmisiController(KelimeOgrenmeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kullaniciID = HttpContext.Session.GetInt32("UserID");
            if (!kullaniciID.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var quizler = _context.Quizler?
                .Where(q => q.KullaniciID == kullaniciID)
                .OrderByDescending(q => q.Tarih)
                .Select(q => new QuizGecmisiViewModel
                {
                    QuizID = q.QuizID,
                    Puan = q.Puan,
                    Tarih = q.Tarih,
                    DogruSayisi = q.Puan / 10, // Her doğru cevap 10 puan olduğu varsayılarak
                    ToplamSoru = 10 // Standart quiz uzunluğu
                })
                .ToList() ?? new List<QuizGecmisiViewModel>();

            return View(quizler);
        }
    }
}