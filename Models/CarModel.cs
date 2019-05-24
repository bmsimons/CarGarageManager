using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarGarageManager.Models
{
    public class CarModel
    {
        public int CarModelID { get; set; }

        [Display(Name = "Car brand")]
        public int CarBrandFK { get; set; }

        [Display(Name = "Car model")]
        public string CarModelName { get; set; }

        [ForeignKey("CarBrandFK")]
        [Display(Name = "Car brand")]
        public CarBrand CarBrand { get; set; }

        public List<Car> Cars { get; set; }
    }
}
