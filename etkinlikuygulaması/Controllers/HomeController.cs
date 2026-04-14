using etkinlikuygulaması.Data;
using etkinlikuygulaması.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using System.Net.Http;
//using System.Text.Json;
//using System.Threading.Tasks;

namespace etkinlikuygulaması.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var etkinlikler = _context.Etkinlikler.ToList();
            return View(etkinlikler);
        }
       
     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
       
    }
}
