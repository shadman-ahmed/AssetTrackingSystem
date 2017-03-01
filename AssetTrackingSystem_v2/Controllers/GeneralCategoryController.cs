using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;

namespace AssetTrackingSystem_v2.Controllers
{
    public class GeneralCategoryController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            PartialMenuView();
            return View();
        }

        [HttpPost]
        public ActionResult Create(GeneralCategory generalCategory)
        {
            PartialMenuView();
            return View();
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "GeneralCategory";

            return PartialView("_PartialMenu");
        }
    }
}