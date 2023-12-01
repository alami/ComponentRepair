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
        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Device obj)
        {
            if (ModelState.IsValid)
            {
                _db.Device.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0){
                return NotFound();
            }
            var obj=_db.Device.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Device obj)
        {
            if (ModelState.IsValid)
            {
                _db.Device.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0){
                return NotFound();
            }
            var obj=_db.Device.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Device.Find(id);
            if (obj==null) {
                return NotFound();
            }
            _db.Device.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
