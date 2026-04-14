using etkinlikuygulaması.Data;
using EtkinlikUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikUygulamasi.Controllers
{
    public class BasvuruController : Controller
    {
        private readonly AppDbContext _context;

        public BasvuruController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Basvuru/Basvuru
        public IActionResult Basvuru()
        {
            return View();
        }

        // POST: Basvuru/Basvuru
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Basvuru(Basvuru basvuru)
        {
            if (ModelState.IsValid)
            {
                _context.Basvurular.Add(basvuru);
                _context.SaveChanges();

                // TempData ile mesaj gönder ve Index sayfasına yönlendir
                TempData["BasvuruMesaj"] = "Başvurunuz alındı! Teşekkür ederiz.";
                return RedirectToAction("Index", "Home");
            }
            return View(basvuru);
        }
    }
}
