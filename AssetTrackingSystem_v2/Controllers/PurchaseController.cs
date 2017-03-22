using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.ViewModels;

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
            ModelState.Clear();
            PartialMenuView("PurchaseEntry");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PurchaseCreateVM purchaseCreateVm)
        {
            return View();
        }

        public ActionResult Search()
        {
            PartialMenuView("PurchaseSearch");
            return View();
        }

    }
}