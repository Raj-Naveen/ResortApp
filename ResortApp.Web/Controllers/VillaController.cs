using Microsoft.AspNetCore.Mvc;
using ResortApp.Domain.Entities;
using ResortApp.Infrastructure.Data;

namespace ResortApp.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);// Whatever passes in this View that will be ( model=> @model) value in Index.cshtml file.
        }
        public IActionResult Create()// The view name is must exactly match the action name.
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "The Description cannot match the name value"); 
            }
            if (ModelState.IsValid)//This is server side validation
            {
                _db.Villas.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Update(int villaID)
        {
            Villa? obj=_db.Villas.FirstOrDefault(x => x.ID == villaID);//There are many ways to retrive data  from database
            //Villa obj = _db.Villas.Find(villaID);
            //Villa obj = _db.Villas.Where(x=> x.Price >50 && x.Occupancy >0).FirstOrDefault();
            if (obj == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);// This obj value is written in first line of the view file( Update.cshml)
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid)//This is server side validation
            {
                _db.Villas.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int villaID)
        {
            Villa? obj = _db.Villas.FirstOrDefault(x => x.ID == villaID);//There are many ways to retrive data  from database
            
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);// This obj value is written in first line of the view file( Update.cshml)
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _db.Villas.FirstOrDefault(x => x.ID == obj.ID);
            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "The villa has been deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "The villa could not be deleted.";
            return View(obj);
        }
    }
}
