using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResortApp.Application.Common.Interfaces;
using ResortApp.Domain.Entities;
using ResortApp.Infrastructure.Data;
using ResortApp.Web.ViewModels;

namespace ResortApp.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //Important 
            //In this below code  how to load navigation property using .Include in entity framework
            //var villaNumbers = _db.VillaNumbers.Include(x=> x.Villa).ToList();

            var villaNumbers =_unitOfWork.VillaNumber.GetAll(includeProperties:"Villa");
            return View(villaNumbers);
        }
        public IActionResult Create()// The view name is must exactly match the action name.
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                })
            };

           /* IEnumerable<SelectListItem> list = _db.Villas.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            });*/


            // view data transfers data from controller to the view and it is store value as a dictionary
            //So it contains key value pair

            // ViewData["VillaList"] = list;

            // view bag also transfers temoporary data from controller to the view. But It is dynamic type property
            // Because of that we do not have a key value pair 

            //ViewBag.VillaList = list;

            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            //Most efficient answer is using .Any  rather than .Where or .FirstOrDefault

            bool roomNumberExist = _unitOfWork.VillaNumber.Any(x=> x.Villa_Number== obj.VillaNumber.Villa_Number);
            //bool isNumberUnique = _db.VillaNumbers.Where(x => x.Villa_Number == obj.Villa_Number).Count()==0 ;

            // this is validate the navigation property ( villa) in this class
            //ModelState.Remove("Villa");

            if (ModelState.IsValid && !roomNumberExist)
            {
                _unitOfWork.VillaNumber.Add(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            if (roomNumberExist)
            {
                TempData["error"] = "The Villa Number already exists.";
            }
            obj.VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            });
            return View(obj);

        }
        public IActionResult Update(int villaNumberID)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }),
               VillaNumber = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumberID)
            };
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);// This obj value is written in first line of the view file( Update.cshtml)
        }
        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)// If update create does not work, always check if all models are populated as you expected them to e
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Update(villaNumberVM.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            // We need to get the drop down here
            villaNumberVM.VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            });
            return View(villaNumberVM); ;
        }
        public IActionResult Delete(int villaNumberID)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumberID)
            };
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);// This obj value is written in first line of the view file( Update.cshtml)
        }
        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? objFromDb = _unitOfWork.VillaNumber
                .Get(x => x.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);
            if (objFromDb is not null)
            {
                _unitOfWork.VillaNumber.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa number could not be deleted.";
            return View();
        }
    }
}
