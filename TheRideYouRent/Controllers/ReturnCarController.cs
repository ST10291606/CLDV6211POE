using TheRideYouRent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TheRideYouRent.Controllers
{
    public class ReturnCarController : Controller
    {
        // GET: CustomerDAL
        ReturnCarDAL returnCarDAL = new ReturnCarDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<ReturnCarModel> cList = new List<ReturnCarModel>();
            cList = returnCarDAL.GetAllReturnCars().ToList();
            return View(cList);
        }

        //Create ReturnCar
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ReturnCarModel returnCar)
        {
            if (ModelState.IsValid)
            {
                returnCarDAL.CreateReturnCar(returnCar);
                return RedirectToAction("Index");
            }
            return View(returnCar);
        }

        //Edit ReturnCar
        [Route("ReturnCar/Edit/{returnCarID}")]
        public IActionResult Edit(int? returnCarID)
        {
            if (returnCarID == null)
            {
                return NotFound();
            }

            ReturnCarModel returnCar = returnCarDAL.GetReturnCar(returnCarID);

            if (returnCar == null)
            {
                return NotFound();
            }

            return View(returnCar);
        }

        //Update ReturnCar
        [Route("ReturnCar/Edit/{returnCarID}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? returnCarID, [Bind] ReturnCarModel returnCar)
        {
            if (returnCarID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                returnCarDAL.UpdateReturnCar(returnCar);
                return RedirectToAction("Index");
            }
            return View(returnCarDAL);
        }

        //Get Delete View
        [Route("ReturnCar/Delete/{returnCarID}")]
        public IActionResult Delete(int? returnCarID)
        {
            if (returnCarID == null)
            {
                return NotFound();
            }
            ReturnCarModel returnCar = returnCarDAL.GetReturnCar(returnCarID);

            if (returnCar == null)
            {
                return NotFound();
            }
            return View(returnCar);
        }

        //Perform Delete
        [Route("ReturnCar/Delete/{returnCarID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReturnCar(int? returnCarID)
        {
            returnCarDAL.Delete(returnCarID);
            return RedirectToAction("Index");
        }
    }
}
