using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;
using ATS.BLL;
using ATS.Model.Interfaces.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class LocationController : Controller
    {
        //private ILocationManager _manager;

        public LocationController()
        {
            //_manager = new LocationManager();
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
            return View();
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "Location";

            return PartialView("_PartialMenu");
        }
    }
}