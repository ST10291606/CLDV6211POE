using TheRideYouRent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Controllers
{
    public class DriverController : Controller
    {
        // GET: DriverDAL
        DriverDAL driverDAL = new DriverDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<DriverModel> dList = new List<DriverModel>();
            dList = driverDAL.GetAllDrivers().ToList();
            return View(dList);
        }

        //Create Driver
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] DriverModel driver)
        {
            if (ModelState.IsValid)
            {
                driverDAL.CreateDriver(driver);
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        //Edit Driver
        [Route("Driver/Edit/{driverID}")]
        public IActionResult Edit(int? driverID)
        {
            if (driverID == null)
            {
                return NotFound();
            }

            DriverModel driver = driverDAL.GetDriverByDriverID(driverID);

            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        //Update Driver
        [Route("Driver/Edit/{driverID}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? driverID, [Bind] DriverModel driver)
        {
            if (driverID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                driverDAL.UpdateDriver(driver);
                return RedirectToAction("Index");
            }
            return View(driverDAL);
        }

        //Get Delete View
        [Route("Driver/Delete/{driverID}")]
        public IActionResult Delete(int? driverID)
        {
            if (driverID == null)
            {
                return NotFound();
            }
            DriverModel driver = driverDAL.GetDriverByDriverID(driverID);

            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        //Perform Delete
        [Route("Driver/Delete/{driverID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDriver(int driverID)
        {
            driverDAL.Delete(driverID);
            return RedirectToAction("Index");
        }
    }
}
