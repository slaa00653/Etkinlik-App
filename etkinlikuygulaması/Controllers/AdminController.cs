using etkinlikuygulaması.Data;
using etkinlikuygulaması.Models;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace etkinlikuygulamasi.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string tc, string sifre)
        {
            var admin = _context.Adminler.FirstOrDefault(a => a.TC == tc && a.Sifre == sifre);

            if (admin != null)
            {
                return RedirectToAction("EtkinlikEkle", "Admin");
            }
            else
            {
                ViewBag.Hata = "TC veya şifre hatalı!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult EtkinlikEkle()
        {
            return View();
        }

        [HttpPost]
      

        public async Task<IActionResult> EtkinlikEkle(string Ad, string Kategori, string Konum, string Ucret, int Kontenjan, IFormFile Dokuman)
        {
            string dokumanAdi = null;



            if (Dokuman != null && Dokuman.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dokumanlar");
                if (!Directory.Exists(uploads))//dokümanlar klasörü yoksa oluşturuyoruz
                    Directory.CreateDirectory(uploads);

                dokumanAdi = Guid.NewGuid().ToString() + Path.GetExtension(Dokuman.FileName);
                var filePath = Path.Combine(uploads, dokumanAdi);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Dokuman.CopyToAsync(stream);
                }

            }

            var yeniEtkinlik = new Etkinlik
            {
                Ad = Ad,
                Kategori = Kategori,
                Konum = Konum,
                Ucret = Ucret,
                Kontenjan = Kontenjan,
                DokumanYolu = "/dokumanlar/" + dokumanAdi
            };

            _context.Etkinlikler.Add(yeniEtkinlik);
            await _context.SaveChangesAsync();

          
            return View();
        }
        public IActionResult EtkinlikListe()
        {
            var etkinlikler = _context.Etkinlikler.ToList();
            return View(etkinlikler);
        }

        [HttpPost]
        public IActionResult EtkinlikSil(int id)
        {
            var etkinlik = _context.Etkinlikler.Find(id);
            if (etkinlik != null)
            {
                _context.Etkinlikler.Remove(etkinlik);
                _context.SaveChanges();
            }

            return RedirectToAction("EtkinlikListe");

        }
    }
} 
       
      














