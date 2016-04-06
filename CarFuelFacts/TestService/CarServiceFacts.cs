using CarFuel.Model;
using CarFuel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Should;
using CarFuel.DAL;
using System.ComponentModel.DataAnnotations;
using CarFuel.Service.CustomException;
using Xunit.Abstractions;

namespace CarFuelFacts.TestService
{

    public class ConstantTest
    {
        public static string CarService { get; set; }
    }

    public class ShareCarService
    {
        public CarService carService { get; set; }
        public ShareCarService()
        {
            this.carService = new CarService(new FakeCarDB());
        }
    }

    [CollectionDefinition(nameof(ConstantTest.CarService))]
    public class CarServiceFactsCollections : ICollectionFixture<ShareCarService>
    {

    }

    public class CarServiceFacts
    {
        [Collection(nameof(ConstantTest.CarService))]
        [Trait("Adding Car", "")]
        public class AddCarService
        {
            public CarService carService { get; set; }

            public AddCarService(ShareCarService shareService)
            {
                this.carService = shareService.carService;
            }

            [Fact]
            public void AddingSingleCar()
            {
                var car = new Car()
                {
                    Make = "CarName",
                    Model = "ModelName"
                };
                var userId = Guid.NewGuid();
                var addedCar = carService.AddNewCar(userId, car);
                addedCar.ShouldNotBeNull();
                Assert.Equal(car.Make, addedCar.Make);
                Assert.Equal(car.Model, addedCar.Model);
                var cars = carService.GetCars(userId);
                Assert.Equal(1, cars.Count);
                Assert.Contains(cars, _car => _car.OwnerId == userId);
            }

            [Fact]
            public void ValidateAddingCar()
            {
                var memeberAlice = Guid.NewGuid();
                carService.CanAddingMoreCar(memeberAlice).ShouldBeTrue();

                carService.AddNewCar(memeberAlice, new Car());
                carService.CanAddingMoreCar(memeberAlice).ShouldBeTrue();//1car

                carService.AddNewCar(memeberAlice, new Car());
                carService.CanAddingMoreCar(memeberAlice).ShouldBeFalse();//2car

            }

            [Fact]
            public void Adding3Car_Throw()
            {
                var memberAlice = Guid.NewGuid();
                //throw new ValidationException();
                carService.AddNewCar(memberAlice, new Car());
                carService.AddNewCar(memberAlice, new Car());

                var exception = Assert.Throws<OverQuotaException>(() =>
                {
                    carService.AddNewCar(memberAlice, new Car());
                });
                exception.Message.ShouldEqual("cannot add more car");
            }
        }

        [Collection(nameof(ConstantTest.CarService))]
        [Trait("Get Car", "")]
        public class GetCarService
        {
            public CarService carService { get; set; }

            public GetCarService(ShareCarService sharedService)
            {
                this.carService = sharedService.carService;
            }

            [Fact]
            
            public void GetCarTest_Not_Null()
            {
                var memebr_alice = Guid.NewGuid();
                var memebr_bob = Guid.NewGuid();
                var member_char = Guid.NewGuid();
                carService.AddNewCar(memebr_alice, new Car());

                carService.AddNewCar(memebr_bob, new Car());
                carService.AddNewCar(memebr_bob, new Car());

                Assert.Equal(1, carService.GetCars(memebr_alice).Count);
                Assert.Equal(2, carService.GetCars(memebr_bob).Count);
                Assert.Equal(0, carService.GetCars(member_char).Count);
            }
        }


    }

}
