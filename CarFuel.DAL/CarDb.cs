using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Model;

namespace CarFuel.DAL
{
    public class CarDb : ICarDb
    {
        public CarFuelDb context { get; set; }

        public CarDb()
        {
            context = new CarFuelDb();
        }

        public Car Add(Car car)
        {
            var carResult = context.Cars.Add(car);
            context.SaveChanges();
            return carResult;
        }

        public Car Get(Guid Id)
        {
            return context.Cars.Find(Id);
        }

        public IEnumerable<Car> GetAll(Func<Car, bool> predicate)
        {
            return context.Cars.Where(predicate).AsEnumerable();
        }
    }
}
