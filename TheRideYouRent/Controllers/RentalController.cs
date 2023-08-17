using TheRideYouRent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Controllers
{
    public class RentalController : Controller
    {
        // GET: RentalDAL
        RentalDAL rentalDAL = new RentalDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<RentalModel> rList = new List<RentalModel>();
            rList = rentalDAL.GetAllRentals().ToList();
            return View(rList);
        }

        //Create Rental
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] RentalModel rental)
        {
            if (ModelState.IsValid)
            {
                rentalDAL.CreateRental(rental);
                return RedirectToAction("Index");
            }
            return View(rental);
        }

        //Edit Rental
        [Route("Rental/Edit/{rentalID}")]
        public IActionResult Edit(int? rentalID)
        {
            if (rentalID == null)
            {
                return NotFound();
            }

            RentalModel rental = rentalDAL.GetRentalByRentalID(rentalID);

            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        //Update Rental
        [Route("Rental/Edit/{rentalID}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? rentalID, [Bind] RentalModel rental)
        {
            if (rentalID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                rentalDAL.UpdateRental(rental);
                return RedirectToAction("Index");
            }
            return View(rentalDAL);
        }

        //Get Delete View
        [Route("Rental/Delete/{rentalID}")]
        public IActionResult Delete(int? rentalID)
        {
            if (rentalID == null)
            {
                return NotFound();
            }
            RentalModel rental = rentalDAL.GetRentalByRentalID(rentalID);

            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        //Perform Delete
        [Route("Rental/Delete/{rentalID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRental(int? rentalID)
        {
            rentalDAL.Delete(rentalID);
            return RedirectToAction("Index");
        }
    }
}
