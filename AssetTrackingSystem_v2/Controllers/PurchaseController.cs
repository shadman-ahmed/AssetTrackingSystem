using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetTrackingSystem_v2.Controllers
{
    public class PurchaseController : Controller
    {
        private ActionResult PartialMenuView(string subMenu)
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Purchase Info";
            ViewBag.SubMenu = subMenu;

            return PartialView("_PartialMenu");
        }
        public ActionResult Create()
        {
            PartialMenuView("PurchaseEntry");
            return View();
        }

    }
}