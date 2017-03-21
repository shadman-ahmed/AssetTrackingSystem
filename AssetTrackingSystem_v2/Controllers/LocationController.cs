using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class LocationController : Controller
    {
        private ILocationManager _locationManager;
        private IOrganizationManager _organizationManager;
        private IBranchManager _branchManager;


        public LocationController()
        {
            _locationManager = new LocationManager();
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();

            PartialMenuView();
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {

            if (ModelState.IsValid && location != null)
            {
                ModelState.Clear();
                try
                {
                    var locationList = _locationManager.GetAll(c => true);

                    int locationExist = locationList
                                        .Where(c => c.OrganizationId == location.OrganizationId)
                                        .Where(c => c.BranchId == location.BranchId)
                                        .Where(c => c.ShortName == location.ShortName)
                                        .Count();

                    if (locationExist > 0)
                    {
                        location.ShortName = null;
                        ModelState.AddModelError("ShortName",
                            "Short name for the location already exists");
                    }
                    else
                    {
                        if (_locationManager.Add(location))
                        {
                            ViewBag.Msg = "location added successfully!";
                            return View();
                        }
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return View(location);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var location = _locationManager.GetById(id);

            return View(location);
        }

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid && location != null)
            {
                try
                {
                    if (_locationManager.Update(location))
                    {
                        ViewBag.Msg = "Location info updated successfully!";
                    }
                    else
                    {
                        if (_locationManager.GetAll(c => c.Id != location.Id && c.ShortName == location.ShortName).Any())
                        {
                            ModelState.AddModelError("ShortName", "ShortName for Location already exists.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    ViewBag.Msg = exception.GetType().ToString();
                }
            }
            
            return View(location);
        }

        public ActionResult Search()
        {

            return View();
        }

        public ActionResult Delete(int id)
        {
            var location = _locationManager.GetById(id);
            try
            {
                if (_locationManager.Remove(location))
                {
                    ViewBag.Msg = "Location deleted Successfully";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Msg = exception.GetType().ToString();
            }

            return View("Search");
        }

        public ActionResult Details(int id)
        {
            var location = _locationManager.GetById(id);

            return View(location);
        }
        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "Location";

            return PartialView("_PartialMenu");
        }

        public JsonResult GetAllOrganization(int? id)
        {

            var organizationList = _organizationManager.GetAll(c => true);



            return Json(organizationList, JsonRequestBehavior.AllowGet);
        }

        // confusuad why id

        public List<SelectListItem> GetOrganizations()
        {
            var organizationDropDownList = new List<SelectListItem>();
            organizationDropDownList.Insert(0, new SelectListItem() { Text = "Select Organization", Value = string.Empty });

            try
            {
                var organizationList = _organizationManager.GetAll(c => true);

                foreach (var organization in organizationList)
                {
                    var item = new SelectListItem() { Text = organization.Name, Value = organization.Id.ToString() };
                    organizationDropDownList.Add(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return organizationDropDownList;
        }
    }
}