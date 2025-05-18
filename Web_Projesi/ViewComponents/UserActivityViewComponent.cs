using Microsoft.AspNetCore.Mvc;
using Web_Projesi.Models;

namespace Web_Projesi.ViewComponents
{
    public class UserActivityViewComponent : ViewComponent
    {
        private readonly KelimeOgrenmeDbContext _context;

        public UserActivityViewComponent(KelimeOgrenmeDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var kullaniciID = HttpContext.Session.GetInt32("UserID");
            if (kullaniciID == null)
            {
                return View(new UserActivityViewModel
                {
                    ToplamQuizSayisi = 0,
                    OrtalamaBasari = 0,
                    SonQuizTarihi = null
                });
            }

            var quizler = _context.Quizler?
                .Where(q => q.KullaniciID == kullaniciID)
                .OrderByDescending(q => q.Tarih)
                .ToList();

            var viewModel = new UserActivityViewModel
            {
                ToplamQuizSayisi = quizler?.Count ?? 0,
                OrtalamaBasari = quizler?.Any() == true ? quizler.Average(q => q.Puan) : 0,
                SonQuizTarihi = quizler?.FirstOrDefault()?.Tarih
            };

            return View(viewModel);
        }
    }
}