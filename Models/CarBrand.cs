using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarGarageManager.Models
{
    public class CarBrand
    {
        public int CarBrandID { get; set; }

        [Display(Name = "Car brand")]
        public string CarBrandName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
