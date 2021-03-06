using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Vehicle Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
