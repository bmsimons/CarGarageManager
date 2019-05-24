using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarGarageManager.Models;

    public class CarGarageManagerContext : DbContext
    {
        public CarGarageManagerContext (DbContextOptions<CarGarageManagerContext> options)
            : base(options)
        {
        }

        public DbSet<CarGarageManager.Models.CarBrand> CarBrand { get; set; }

        public DbSet<CarGarageManager.Models.CarModel> CarModel { get; set; }

        public DbSet<CarGarageManager.Models.Car> Car { get; set; }
    }
