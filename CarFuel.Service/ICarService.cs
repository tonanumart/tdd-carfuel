using System;
using System.Collections.Generic;
using CarFuel.Model;

namespace CarFuel.Service
{
    public interface ICarService
    {
        Car AddNewCar(Guid userId, Car car);
        bool CanAddingMoreCar(Guid userId);
        List<Car> GetCars(Guid memeberId);
    }
}