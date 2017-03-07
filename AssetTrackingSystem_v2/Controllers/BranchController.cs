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
                   var BranchList = _branchManager.GetAll(c => true);

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
                        if(_branchManager.Add(branch))
                        {
                            ViewBag.Msg = "Branch added successfully!";
                            return View();
                        }
                    }
                    
                }
                catch (Exception exception)
                {
                   Console.WriteLine(exception.Message);
                }
            }

            return View(branch);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.OrganizationList = GetOrganizations();
            var branch = _branchManager.GetById(id);

            return View(branch);
        }

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            ViewBag.OrganizationList = GetOrganizations();

            if (ModelState.IsValid && branch != null)
            {
                try
                {
                    if (_branchManager.Update(branch))
                    {
                        ViewBag.Msg = "Branch info updated successfully!";
                    }
                    else
                    {
                        if (_branchManager.GetAll(c => c.Id != branch.Id && c.ShortName == branch.ShortName).Count() > 0)
                        {
                            ModelState.AddModelError("ShortName", "ShortName for a branch already exist for the organization");
                        }
                    }
                }
                catch (Exception exception)
                {
                    ViewBag.Msg = exception.GetType().ToString();
                }
            }

            return View(branch);
        }

        public ActionResult Search()
        {
            var branchList = _branchManager.GetAll(c => true);
            return View(branchList);
        }

        public ActionResult Delete(int id)
        {
            var branch = _branchManager.GetById(id);
            try
            {
                if (_branchManager.Remove(branch))
                {
                    ViewBag.Msg = "Branch deleted Successfully";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Msg = exception.GetType().ToString();
            }

            return View("Search");
        }

        public ActionResult Details(int id)
        {
            var branch = _branchManager.GetById(id);
            
            return View(branch);
        }

        private ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Organization Info";
            ViewBag.SubMenu = "Branch";

            return PartialView("_PartialMenu");
        }

        public List<SelectListItem> GetOrganizations()
        {
            var organizationDropDownList = new List<SelectListItem>();
            organizationDropDownList.Insert(0, new SelectListItem() { Text = "Select Organization", Value = string.Empty });

            try
            {
                var organizationList = _organizationManager.GetAll(c => true);

                foreach (var organization in organizationList)
                {
                    var item = new SelectListItem() { Text = organization.Name, Value = organization.Id.ToString() };
                    organizationDropDownList.Add(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            return organizationDropDownList;
        }

        public JsonResult GetOrganizationById(int? id)
        {
            Organization organization = null;

            if (id != null)
            {
                organization = _organizationManager.GetById((int) id);
            }

            return Json(organization, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllBranches()
        {
            var branchList = _branchManager.GetAll(c => true);
            var organizationList = _organizationManager.GetAll(c => true);

            var orgBranchList = branchList.Join(organizationList, branch => branch.OrganizationId, org => org.Id,
                (branch, org) => new
                {
                    Organization = org.Name,
                    Branch = branch
                });

            return Json(orgBranchList, JsonRequestBehavior.AllowGet);
        }
    }
}