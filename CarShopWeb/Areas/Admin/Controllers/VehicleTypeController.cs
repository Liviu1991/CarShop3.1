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
    public class VehicleTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            VehicleType vehicleType = new VehicleType();
            if (id == null)
            {
                //this is for create
                return View(vehicleType);
            }
            //this is for edit
            vehicleType = _unitOfWork.VehicleType.Get(id.GetValueOrDefault());
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                if (vehicleType.Id == 0)
                {
                    _unitOfWork.VehicleType.Add(vehicleType);
                    
                }
                else
                {
                    _unitOfWork.VehicleType.Update(vehicleType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleType);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.VehicleType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.VehicleType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.VehicleType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}