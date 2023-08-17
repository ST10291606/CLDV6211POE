using TheRideYouRent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Controllers
{
    public class CarController : Controller
    {
        // GET: CarDAL
        CarDAL carDAL = new CarDAL();

        public IActionResult Index()
        {
            //Get All Cars
            List<CarModel> cList = new List<CarModel>();
            cList = carDAL.GetAllCars().ToList();
            return View(cList);
        }

        //Create Car
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CarModel car)
        {
            if (ModelState.IsValid)
            {
                carDAL.CreateCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        //Edit Car
        [Route("Car/Edit/{carNo}")]
        public IActionResult Edit(string carNo)
        {
            if (carNo == null)
            {
                return NotFound();
            }

            CarModel cust = carDAL.GetCarByCarID(carNo);

            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        //Update Customer
        [Route("Car/Edit/{carNo}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string carNo, [Bind] CarModel cust)
        {
            if (carNo == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                carDAL.UpdateCar(cust);
                return RedirectToAction("Index");
            }
            return View(carDAL);
        }

        //Get Delete View
        [Route("Car/Delete/{carNo}")]
        public IActionResult Delete(string carNo)
        {
            if (carNo == null)
            {
                return NotFound();
            }
            CarModel cust = carDAL.GetCarByCarID(carNo);

            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        //Perform Delete
        [Route("Car/Delete/{carNo}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteCar(string carNo)
        {
            carDAL.Delete(carNo);
            return RedirectToAction("Index");
        }
    }
}

