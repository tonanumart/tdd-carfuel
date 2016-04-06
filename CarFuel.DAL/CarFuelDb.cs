using CarFuel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.DAL
{
    public class CarFuelDb : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
