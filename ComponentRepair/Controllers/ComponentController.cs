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
            if (ModelState.IsValid)
            {
                _db.Component.Add (obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Component.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Component obj)
        {
            if (ModelState.IsValid)
            {
                _db.Component.Update (obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Component(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Component.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Component
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ComponentPost(int? id)
        {
            var obj = _db.Component.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Component.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Component.Find(id);
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
            var obj = _db.Component.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Component.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
