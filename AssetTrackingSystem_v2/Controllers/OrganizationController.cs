using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;

namespace AssetTrackingSystem_v2.Controllers
{
    public class OrganizationController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            PartialMenuView();
            return View(new Organization());
        }

        [HttpPost]
        public ActionResult Create(Organization organization)
        {

            PartialMenuView();

            if (ModelState.IsValid && organization != null)
            {
                try
                {
                    var db = new AssetTrackingManagementDbContext();

                    db.Organizations.Add(organization);

                    int successCount = db.SaveChanges();

                    if (successCount > 0)
                    {
                        // make partialView for success 
                        return View(new Organization());
                    }
                }
                catch (Exception exception)
                {
                    using (var db = new AssetTrackingManagementDbContext())
                    {
                        int NameExist = db.Organizations.Where(c => c.Name.Equals(organization.Name)).Count();

                        if (NameExist > 0)
                        {
                            organization.Name = null;
                            ModelState.AddModelError("Name", "Organization name already exits.");
                        }

                        int ShortNameExits = db.Organizations.Where(c => c.ShortName == organization.ShortName).Count();

                        if (ShortNameExits > 0)
                        {
                            organization.ShortName = null;
                            ModelState.AddModelError("ShortName", "Short name already exits");
                        }
                    }
                }
               
            }

            return View(organization);
        }

        public ActionResult PartialMenuView()
        {

            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Organization Info";
            ViewBag.SubMenu = "Organization";

            return PartialView("_PartialMenu");
        }
    }
}