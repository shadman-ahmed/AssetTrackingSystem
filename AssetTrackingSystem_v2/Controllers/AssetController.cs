using AssetTrackingSystem_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTrackingSystem_v2.Controllers
{
    public class AssetController : Controller
    {
        private ActionResult PartialMenuView(string subMenu)
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = subMenu;

            return PartialView("_PartialMenu");
        }
        public ActionResult Create()
        {
            ModelState.Clear();
            PartialMenuView("AssetRegistration");
            return View();
        }

        [HttpPost]
        public ActionResult Create(AssetRegistrationVM assetRegistrationVM)
        {
            return View();
        }

        
    }
}