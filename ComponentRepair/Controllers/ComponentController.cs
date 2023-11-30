using ComponentRepair.Data;
using ComponentRepair.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComponentRepair.Controllers
{
    public class ComponentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ComponentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Component> objList = _db.Component;
            return View(objList);
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Component obj)
        {
            _db.Component.Add (obj);
            _db.SaveChanges();
            return View();
        }
    }
}
