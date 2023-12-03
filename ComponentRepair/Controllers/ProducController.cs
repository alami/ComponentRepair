using ComponentRepair.Data;
using ComponentRepair.Models;
using ComponentRepair.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ComponentRepair.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
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
                }),
                ComponentSelectList =  _db.Component.Select(i => new SelectListItem
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
        public ActionResult Upsert (ProductVM productVM)
        {
            if (ModelState.ErrorCount<=2)  //IsValid
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (productVM.Product.Id == 0)
                {
                    string upload = webRootPath + WC.ImagePath;
                    string filename = Guid.NewGuid().ToString();
                    string extention = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, filename+extention), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    };
                    productVM.Product.Image = filename + extention;

                    _db.Product.Add(productVM.Product);
                    _db.SaveChanges();
                }
                else
                {
                    var objFromODb = _db.Product.AsNoTracking().FirstOrDefault(u=>u.Id == productVM.Product.Id);
                    if (files.Count>0) //получен новый файл?
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string filename = Guid.NewGuid().ToString();
                        string extention = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, objFromODb.Image);
                        if (System.IO.File.Exists(oldFile))   //нада удалить старый
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        using (var fileStream = new FileStream(Path.Combine(upload, filename + extention), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        };
                        productVM.Product.Image = filename + extention;

                    } else
                    {
                        productVM.Product.Image = objFromODb.Image;
                    }
                    _db.Product.Update(productVM.Product);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //            var errors = ModelState.Values.SelectMany(v => v.Errors);

            productVM.DeviceSelectList = _db.Device.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
            productVM.ComponentSelectList = _db.Component.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
            return View(productVM);
        }        

        // GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product product = _db.Product.Include(u=>u.Device).Include(u=>u.Component).FirstOrDefault(u=>u.Id==id);

            return View(product);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            var obj = _db.Product.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            string upload = _webHostEnvironment.WebRootPath + WC.ImagePath;
            var oldFile = Path.Combine(upload, obj.Image);
            if (System.IO.File.Exists(oldFile))   //нада удалить старый
            {
                System.IO.File.Delete(oldFile);
            }

            _db.Product.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
