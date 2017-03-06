using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;
using ATS.BLL;
using ATS.Model.Interfaces.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class BranchController : Controller
    {
        private IBranchManager _branchManager;
        private IOrganizationManager _organizationManager;


        public BranchController()
        {
            PartialMenuView();
            _branchManager = new BranchManager();
            _organizationManager = new OrganizationManager();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.OrganizationList = GetOrganizations();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            ViewBag.OrganizationList = GetOrganizations();

            if (ModelState.IsValid && branch != null)
            {
                ModelState.Clear();
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
                                ModelState.Clear();
                                //make partial view for success msg
                                return View();
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
            var organizationDropDownList = new List<SelectListItem>();
            organizationDropDownList.Insert(0, new SelectListItem() { Text = "Select Organization", Value = string.Empty });

            try
            {
                var organizationList = _organizationManager.GetAll(c => true);

                foreach (var organization in organizationList)
                {
                    var item = new SelectListItem() {Text = organization.Name, Value = organization.Id.ToString()};
                    organizationDropDownList.Add(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            return organizationDropDownList;
        }

        public JsonResult GetOrganizationById(int id)
        {
            Organization organization = null;

            organization = _organizationManager.GetById(id);

            return Json(organization, JsonRequestBehavior.AllowGet);
        }
    }
}