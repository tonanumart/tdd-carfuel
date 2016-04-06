using CarFuel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;
using Xunit;

namespace CarFuelFacts
{
    
    public class CarFuelFacts
    {
        [Trait("Car Fuel Rate Prop", "")]
        public class CarFuelRateProperty
        {
            [Fact]
            public void CarFuelRateKMLShouldNull()
            {
                var carFillUp = new FillUp()
                {
                    Lites = 10M,
                    OdoMeter = 10
                };
                carFillUp.RateKmLite.ShouldBeNull();
            }

            [Fact]
            public void CarFuelRateKMLShould12()
            {
                var carFillUp = new FillUp()
                {
                    Lites = 40,
                    OdoMeter = 1000,
                    NextFillUp = new FillUp()
                    {
                        Lites = 50,
                        OdoMeter = 1600
                    }
                };
                Assert.Equal(12, carFillUp.RateKmLite);
            }


        }

        [Trait("Car Fuel Property", "")]
        public class CarProperty
        {
            [Fact]
            public void InitialCar_FillupNotNull()
            {
                var car = new Car();
                List<FillUp> carFillup = car.FillUps.ToList();
                Assert.NotNull(carFillup);
                Assert.Equal(0, car.FillUps.Count);
            }

            [Fact]
            public void CarAddFillUp_FillUpResultNotNull()
            {
                Car car = new Car();
                int OdoMeter = 1000;
                int Lites = 20;
                FillUp fillup = car.AddFillUp(OdoMeter, Lites);
                fillup.ShouldNotBeNull();
                Assert.Equal(1, car.FillUps.Count);
                Assert.Equal(OdoMeter, fillup.OdoMeter);
                Assert.Equal(Lites, fillup.Lites);
            }

            [Fact]
            public void CarAddFillUp_TwoTime()
            {
                var car = new Car();
                FillUp f1 = car.AddFillUp(1000, 50);
                FillUp f2 = car.AddFillUp(1600, 40);
                f1.NextFillUp.ShouldNotBeNull();
                Assert.Same(f2, f1.NextFillUp);
                f2.NextFillUp.ShouldBeNull();
            }


            [Fact]
            public void FillUpAvg()
            {
                var car = new Car();
                FillUp f1 = car.AddFillUp(1000, 40);
                FillUp f2 = car.AddFillUp(1600, 50);
                decimal actual = car.AvgRateFillUp.Value;
                Assert.Equal(12.0M, actual);
            }

            [Fact]
            public void FillUpAvg_3Time()
            {
                var car = new Car();
                FillUp f1 = car.AddFillUp(1000, 40);
                FillUp f2 = car.AddFillUp(1600, 50);
                FillUp f3 = car.AddFillUp(2000, 40);
                decimal actual = car.AvgRateFillUp.Value;
                Assert.Equal(11.11M, actual);
            }

        }
    }
}
