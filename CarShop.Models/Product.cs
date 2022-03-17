using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public string Description { get; set; }
        
        [Required]
        public string BodyType { get; set; }
        [Required]
        public int FirstRegistration { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        public string Gear { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        
        public string ImageUrl { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }
        
        [ForeignKey("VehicleTypeId")]
        public VehicleType VehicleType { get; set; }

        [Required]
        public int FuelTypeId { get; set; }

        [ForeignKey("FuelTypeId")]
        public FuelType FuelType { get; set; }
    }
}
