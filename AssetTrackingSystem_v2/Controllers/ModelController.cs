using AssetTrackingSystem_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTrackingSystem_v2.Controllers
{
    public class ModelController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            PartialMenuView();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model model)
        {
            PartialMenuView();
            return View();
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "Model";

            return PartialView("_PartialMenu");
        }
    }
}