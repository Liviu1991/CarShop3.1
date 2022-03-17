using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> VehicleTypeList { get; set; }
        public IEnumerable<SelectListItem> FuelTypeList { get; set; }
    }
}
