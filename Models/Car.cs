using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration;

namespace CarGarageManager.Models
{
    public class Car
    {
        public int CarID { get; set; }

        [Display(Name = "Car model")]
        public int CarModelFK { get; set; }

        [Display(Name = "Build year")]
        public int Year { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Mileage")]
        public int Mileage { get; set; }

        [ForeignKey("CarModelFK")]
        [Display(Name = "Car model")]
        public CarModel CarModel { get; set; }
    }
}
