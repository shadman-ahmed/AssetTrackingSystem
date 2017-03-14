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
            ViewBag.OrganizationList = GetOrganizations();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {
            ViewBag.OrganizationList = GetOrganizations();

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
            ViewBag.OrganizationList = GetOrganizations();

            var location = _locationManager.GetById(id);

            return View(location);
        }

        [HttpPost]
        public ActionResult Edit(Location location)
        {

            ViewBag.OrganizationList = GetOrganizations();

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
                        if (_locationManager.GetAll(c => c.Id != location.Id && c.ShortName == location.ShortName).Count() > 0)
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

        public JsonResult GetBranchesByOrganization(int? id)
        {

            var branchList = _branchManager.GetAll(c => true);

            if (id != null)
            {
                branchList = branchList.Where(c => c.OrganizationId == id).ToList();
            }

            return Json(branchList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllOrganization(int? id)
        {

            var organizationList = _organizationManager.GetAll(c => true);



            return Json(organizationList, JsonRequestBehavior.AllowGet);
        }

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

        public JsonResult GetOrganizationById(int? id)
        {
            Organization organization = null;

            if (id != null)
            {
                organization = _organizationManager.GetById((int)id);
            }

            return Json(organization, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchById(int? id)
        {
            Branch branch = null;

            if (id != null)
            {
                branch = _branchManager.GetById((int)id);
            }

            return Json(branch, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllLocations()
        {
            var locationList = _locationManager.GetAll(c => true);
            var organizationList = _organizationManager.GetAll(c => true);
            var branchList = _branchManager.GetAll(c => true);


            var assetLocationList = from l in locationList
                                    join org in organizationList on l.OrganizationId equals org.Id
                                    select new
                                    {
                                        Location = l,
                                        Organization = org.Name,
                                        Name = l.Name,
                                        l.BranchId,
                                        l.ShortName,
                                        l.Code
                                    } into intermediate
                                    join b in branchList on intermediate.BranchId equals b.Id
                                    select new
                                    {
                                        Location = intermediate.Location,
                                        Organization = intermediate.Organization,
                                        Branch = b.Name,
                                        Name = intermediate.Name,
                                        ShortName = intermediate.ShortName,
                                        Code = intermediate.Code
                                    };


            return Json(assetLocationList, JsonRequestBehavior.AllowGet);
        }
    }
}