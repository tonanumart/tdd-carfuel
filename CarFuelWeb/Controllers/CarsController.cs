using CarFuel.Model;
using CarFuel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CarFuel.DAL;
using CarFuel.Service.CustomException;

namespace CarFuelWeb.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {

        private CarService carService { get; set; }
        public CarsController()
        {
            this.carService = new CarService(new CarDb());
        }
        // GET: Cars
        
        public ActionResult Index()
        {
            var memberId = User.Identity.GetUserId();
            List<Car> cars = carService.GetCars(new Guid(memberId));
            return View(cars);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {
            var memberId = new Guid(User.Identity.GetUserId());
            try
            {
                Car newCar = carService.AddNewCar(memberId, car);
            }
            catch (OverQuotaException ex) {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}