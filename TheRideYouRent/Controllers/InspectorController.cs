using TheRideYouRent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Controllers
{
    public class InspectorController : Controller
    {
        // GET: CustomerDAL
        InspectorDAL inspectorDAL = new InspectorDAL();

        public IActionResult Index()
        {
            //Get All JobTypes
            List<InspectorModel> iList = new List<InspectorModel>();
            iList = inspectorDAL.GetAllInspectors().ToList();
            return View(iList);
        }

        //Create Inspector
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] InspectorModel inspector)
        {
            if (ModelState.IsValid)
            {
                inspectorDAL.CreateInspector(inspector);
                return RedirectToAction("Index");
            }
            return View(inspector);
        }

        //Edit Inspector
        [Route("Inspector/Edit/{inspectorNo}")]
        public IActionResult Edit(string inspectorNo)
        {
            if (inspectorNo == null)
            {
                return NotFound();
            }

            InspectorModel insp = inspectorDAL.GetInspectorByInspectorID(inspectorNo);

            if (insp == null)
            {
                return NotFound();
            }

            return View(insp);
        }

        //Update Inspector
        [Route("Inspector/Edit/{inspectorNo}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string inspectorNo, [Bind] InspectorModel insp)
        {
            if (inspectorNo == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                inspectorDAL.UpdateInspector(insp);
                return RedirectToAction("Index");
            }
            return View(inspectorDAL);
        }

        //Get Delete View
        [Route("Inspector/Delete/{inspectorNo}")]
        public IActionResult Delete(string inspectorNo)
        {
            if (inspectorNo == null)
            {
                return NotFound();
            }
            InspectorModel insp = inspectorDAL.GetInspectorByInspectorID(inspectorNo);

            if (insp == null)
            {
                return NotFound();
            }
            return View(insp);
        }

        //Perform Delete
        [Route("Inspector/Delete/{inspectorNo}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInspector(string inspectorNo)
        {
            inspectorDAL.Delete(inspectorNo);
            return RedirectToAction("Index");
        }
    }
}
