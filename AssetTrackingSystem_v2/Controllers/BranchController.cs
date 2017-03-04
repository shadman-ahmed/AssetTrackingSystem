using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;

namespace AssetTrackingSystem_v2.Controllers
{
    public class BranchController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            PartialMenuView();
            ViewBag.OrganizationList = GetOrganizations();

            return View(new Branch());
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            PartialMenuView();
            ViewBag.OrganizationList = GetOrganizations();

            if (ModelState.IsValid && branch != null)
            {
                try
                {
                    using (var db = new AssetTrackingManagementDbContext())
                    {
                        var BranchList = new List<Branch>(db.Branches);

                        int BranchExist = BranchList
                                            .Where(c => c.OrganizationId == branch.OrganizationId)
                                            .Where(c => c.ShortName == branch.ShortName)
                                            .Count();

                        if (BranchExist > 0)
                        {
                            branch.ShortName = null;
                            ModelState.AddModelError("ShortName",
                                "Short name for the branch already exists for the organization");
                        }
                        else
                        {
                            db.Branches.Add(branch);
                            int successCount = db.SaveChanges();

                            if (successCount > 0)
                            {
                                //make partial view for success msg
                                return View(new Branch());
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    using (var db = new AssetTrackingManagementDbContext())
                    {
                        int BranchNameExist = db.Branches.Where(c => c.Name == branch.Name).Count();

                        if (BranchNameExist > 0)
                        {
                            branch.Name = null;
                            ModelState.AddModelError("Name", "Branch name already exists");
                        }
                        
                    }
                }
            }
            return View(branch);
        }

        private ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Organization Info";
            ViewBag.SubMenu = "Branch";

            return PartialView("_PartialMenu");
        }

        private List<SelectListItem> GetOrganizations()
        {
            var db = new AssetTrackingManagementDbContext();

            var organizationList = db.Organizations;

            var organizationDropDownList = new List<SelectListItem>();
            foreach (var organization in organizationList)
            {
                var item = new SelectListItem() { Text = organization.Name, Value = organization.Id.ToString() };
                organizationDropDownList.Add(item);
            }

            organizationDropDownList.Insert(0, new SelectListItem() { Text = "Select Organization", Value = string.Empty });

            return organizationDropDownList;
        }

        public JsonResult GetOrganizationById(int id)
        {
            var db = new AssetTrackingManagementDbContext();

            Organization organization = null;

            organization = db.Organizations.Find(id);

            return Json(organization, JsonRequestBehavior.AllowGet);
        }
    }
}