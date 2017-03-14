using AssetTrackingSystem_v2.Models;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTrackingSystem_v2.Controllers
{
    public class ManufacturerController : Controller
    {
        private IManufacturerManager _manufacturerManager;

        public ManufacturerController()
        {
            _manufacturerManager = new ManufacturerManager();
            PartialMenuView();
        }

        [HttpGet]
        public ActionResult Create()
        {
            //PartialMenuView();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            //PartialMenuView();
            if (ModelState.IsValid && manufacturer != null)
            {
                ModelState.Clear();

                try
                {
                    if (_manufacturerManager.Add(manufacturer))
                    {
                        ViewBag.Msg = "Created successfully!";
                        return View();
                    }
                }
                catch (Exception exception)
                {

                    int NameExist = _manufacturerManager.GetAll(c => c.Name.Equals(manufacturer.Name)).Count();

                    if (NameExist > 0)
                    {
                        manufacturer.Name = null;
                        ModelState.AddModelError("Name", "Manufacturer name already exists");
                    }

                    int ShortNameExits = _manufacturerManager.GetAll(c => c.Code == manufacturer.Code).Count();

                    if (ShortNameExits > 0)
                    {
                        manufacturer.Code = null;
                        ModelState.AddModelError("Code", "Code already exists");
                    }
                }

            }

            return View(manufacturer);
        }

        public ActionResult Delete(int id)
        {
            var manufacturer = _manufacturerManager.GetById(id);
            try
            {
                if (_manufacturerManager.Remove(manufacturer))
                {
                    ViewBag.Msg = "Deleted successfully!";

                    return View("Search");
                }
            }
            catch (Exception exception)
            {
                //return HttpNotFound();
                ViewBag.Msg = exception.GetType().ToString();

            }

            return View("Search");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var manufacturer = _manufacturerManager.GetById((int)id);
            return View(manufacturer);
        }

        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                //ModelState.Clear();

                try
                {
                    if (_manufacturerManager.Update(manufacturer))
                    {
                        ViewBag.Msg = "Updated successfully!";
                        return View();
                    }
                }
                catch (Exception exception)
                {
                    int NameExist = _manufacturerManager.GetAll(c => c.Name == manufacturer.Name).Count();

                    if (NameExist > 0)
                    {
                        ModelState.AddModelError("Name", "Name already exists in the system");
                    }

                    int ShortNameExist = _manufacturerManager.GetAll(c => c.Code == manufacturer.Code).Count();

                    if (ShortNameExist > 0)
                    {
                        ModelState.AddModelError("Code", "Code already exists in the system");
                    }

                }
            }
            return View(manufacturer);
        }

        public ActionResult Details(int id)
        {
            var manufacturer = _manufacturerManager.GetById(id);

            return View(manufacturer);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "Manufacturer";

            return PartialView("_PartialMenu");
        }

        public JsonResult GetAllManufacturer()
        {

            var manufacturers = _manufacturerManager.GetAll(c => true).ToList();

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
        }

        
    }
}