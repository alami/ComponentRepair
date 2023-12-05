using ComponentRepair.Data;
using ComponentRepair.Models;
using ComponentRepair.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ComponentRepair.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Products = _db.Product.Include(u=>u.Device).Include(u=>u.Component),
                Devices = _db.Device
            };
            return View(homeVM);
        }
        public IActionResult Details(int id)
        {
            DetailsVM DetailsVM = new DetailsVM()
            {
                Product = _db.Product.Include(u => u.Device).Include(u => u.Component)
                .Where(u=>u.Id == id).FirstOrDefault(),
                ExistsInSell = false
            };
            return View(DetailsVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
