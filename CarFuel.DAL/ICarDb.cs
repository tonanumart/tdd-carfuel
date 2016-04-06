using CarFuel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.DAL
{
    public interface ICarDb
    {
        Car Add(Car car);
        Car Get(Guid Id);
        IEnumerable<Car> GetAll(Func<Car, bool> predicate);

    }
}
