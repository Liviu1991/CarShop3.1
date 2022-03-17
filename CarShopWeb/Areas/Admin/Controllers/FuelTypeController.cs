using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.DataAccess.Repository.IRepository;
using CarShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FuelTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuelTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            FuelType fuelType = new FuelType();
            if (id == null)
            {
                //this is for create
                return View(fuelType);
            }
            //this is for edit
            fuelType = _unitOfWork.FuelType.Get(id.GetValueOrDefault());
            if (fuelType == null)
            {
                return NotFound();
            }
            return View(fuelType);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                if (fuelType.Id == 0)
                {
                    _unitOfWork.FuelType.Add(fuelType);

                }
                else
                {
                    _unitOfWork.FuelType.Update(fuelType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelType);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.FuelType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.FuelType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.FuelType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}