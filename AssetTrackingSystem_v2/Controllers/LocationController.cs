using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;

namespace AssetTrackingSystem_v2.Controllers
{
    public class LocationController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            PartialMenuView();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {
            PartialMenuView();
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