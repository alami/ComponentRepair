using ComponentRepair.Data;
using ComponentRepair.Models;
using ComponentRepair.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComponentRepair.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Product;
            foreach (var obj in objList)
            {
                obj.Device = _db.Device.FirstOrDefault(u => u.Id == obj.DeviceId);
            }
            return View(objList);
        }


        // GET Create & Update
        public ActionResult Upsert(int? id)
        {
            
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                DeviceSelectList =  _db.Device.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };
            if (id != null)
            {
                productVM.Product = _db.Product.Find(id);
                if (productVM.Product == null)
                {
                    return NotFound() ;
                }
            }
            return View(productVM);
        }

        // POST: Create & Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert (IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }        

        // GET: ProducController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProducController/Delete/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
