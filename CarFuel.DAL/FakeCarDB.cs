using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Model;

namespace CarFuel.DAL
{
    public class FakeCarDB : ICarDb
    {
        public bool IsCalledAdd { get; set; } = false;

        public FakeCarDB() {
            cars = new List<Car>();
        }

        public List<Car> cars { get; set; }

        public Car Add(Car car)
        {
            cars.Add(car);
            IsCalledAdd = true;
            return car;
        }

        public Car Get(Guid Id)
        {
            return cars.SingleOrDefault(car => car.Id == Id);
        }

        public IEnumerable<Car> GetAll(Func<Car, bool> predicate)
        {
            return cars.Where(predicate);
        }
    }
}
