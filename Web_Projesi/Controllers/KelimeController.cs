using Microsoft.AspNetCore.Mvc;

namespace Web_Projesi.Controllers
{
    using Web_Projesi.Models;
    public class KelimeController : Controller
    {
        private readonly KelimeOgrenmeDbContext _context;

        public KelimeController(KelimeOgrenmeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kelimeler = _context.Kelimeler.ToList();
            return View(kelimeler);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kelimeler model)
        {
            if (ModelState.IsValid)
            {
                _context.Kelimeler.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
