using ComponentRepair.Data;
using ComponentRepair.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComponentRepair.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DeviceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Device> objList = _db.Device;
            return View(objList);
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
