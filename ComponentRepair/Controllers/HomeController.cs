using ComponentRepair.Data;
using ComponentRepair.Models;
using ComponentRepair.Models.ViewModels;
using ComponentRepair.Utitlity;
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
            List<SellReady> sellReadyList = new List<SellReady>();
            if (HttpContext.Session.Get<IEnumerable<SellReady>>(WC.SessionSellReady) != null
                && HttpContext.Session.Get<IEnumerable<SellReady>>(WC.SessionSellReady).Count() > 0)
            {
                sellReadyList = HttpContext.Session.Get<List<SellReady>>(WC.SessionSellReady);
            }

            DetailsVM DetailsVM = new DetailsVM()
            {
                Product = _db.Product.Include(u => u.Device).Include(u => u.Component)
                .Where(u=>u.Id == id).FirstOrDefault(),
                ExistsInSell = false
            };

            foreach (var item in sellReadyList)
            {
                if (item.ProductId == id)
                {
                    DetailsVM.ExistsInSell = true;
                }
            }

            return View(DetailsVM);
        }

        [HttpPost, ActionName("Details")]
        public IActionResult DetailsPost(int id)
        {
            List<SellReady> sellReadyList = new List<SellReady>();
            if (HttpContext.Session.Get<IEnumerable<SellReady>>(WC.SessionSellReady) != null
                && HttpContext.Session.Get<IEnumerable<SellReady>>(WC.SessionSellReady).Count() > 0 )
            {
                sellReadyList = HttpContext.Session.Get<List<SellReady>>(WC.SessionSellReady);
            }
            sellReadyList.Add(new SellReady { ProductId = id });
            HttpContext.Session.Set(WC.SessionSellReady, sellReadyList);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveFromSell (int id)
        {
            List<SellReady> sellReadyList = new List<SellReady>();
            if (HttpContext.Session.Get<IEnumerable<SellReady>>(WC.SessionSellReady) != null
                && HttpContext.Session.Get<IEnumerable<SellReady>>(WC.SessionSellReady).Count() > 0 )
            {
                sellReadyList = HttpContext.Session.Get<List<SellReady>>(WC.SessionSellReady);
            }

            var itemToRemove = sellReadyList.SingleOrDefault(r => r.ProductId == id);
            if (itemToRemove!=null)
            {
                sellReadyList.Remove(itemToRemove);
            }
            
            HttpContext.Session.Set(WC.SessionSellReady, sellReadyList);
            return RedirectToAction(nameof(Index));
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
