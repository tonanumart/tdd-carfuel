using CarFuel.DAL;
using CarFuel.Model;
using CarFuel.Service.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Service
{
    public class CarService
    {
        public ICarDb carDb { get; }

        public CarService()
        {
            if (carDb == null)
                carDb = new FakeCarDB();
        }

        public CarService(ICarDb CarDb)
        {
            if (CarDb == null) throw new ArgumentNullException(nameof(CarDb));

            this.carDb = CarDb;
        }

        public List<Car> GetCars(Guid guid)
        {
            return carDb.GetAll(car => car.OwnerId == guid).ToList();
        }

        public Car AddNewCar(Guid userId, Car car)
        {
            if (!this.CanAddingMoreCar(userId))
                throw new OverQuotaException("cannot add more car");

            car.OwnerId = userId;
            return carDb.Add(car);
        }

        public bool CanAddingMoreCar(Guid userId)
        {
            return this.GetCars(userId).Count < 2;
        }
    }
}
