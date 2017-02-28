using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;

namespace AssetTrackingSystem_v2.Controllers
{
    public class OrganizationController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            PartialMenu();



            return View();
        }

        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            return View();
        }

        public ActionResult PartialMenu()
        {

            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Organization Info";
            ViewBag.SubMenu = "Organization";

            return PartialView("_PartialMenu");
        }
    }
}