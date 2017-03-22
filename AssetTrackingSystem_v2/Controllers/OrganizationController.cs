using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class OrganizationController : Controller
    {
        private IOrganizationManager _manager;

        public OrganizationController()
        {
            _manager = new OrganizationManager();
            PartialMenuView();
        }

        [HttpGet]
        public ActionResult Create()
        {
            //PartialMenuView();

            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Organization organization)
        {

            //PartialMenuView();

            if (ModelState.IsValid && organization != null)
            {
                ModelState.Clear();

                try
                {
                    if (_manager.Add(organization))
                    {
                        ViewBag.Msg = "Created successfully!";
                        return View();
                    }
                }
                catch (Exception exception)
                {
                    
                        int NameExist = _manager.GetAll(c => c.Name.Equals(organization.Name)).Count();

                        if (NameExist > 0)
                        {
                            organization.Name = null;
                            ModelState.AddModelError("Name", "Organization name already exists");
                        }

                        int ShortNameExits = _manager.GetAll(c => c.ShortName == organization.ShortName).Count();

                        if (ShortNameExits > 0)
                        {
                            organization.ShortName = null;
                            ModelState.AddModelError("ShortName", "Short name already exists");
                        }
                }
                
            }

            return View(organization);
        }

        public ActionResult Delete(int id)
        {
            var organization = _manager.GetById(id);
            try
            {
                if (_manager.Remove(organization))
                {
                    ViewBag.Msg = "Deleted successfully!";

                    return View("Search");
                }
            }
            catch (Exception exception)
            {
                //return HttpNotFound();
                ViewBag.Msg = exception.GetType().ToString();

            }

            return View("Search");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var organization = _manager.GetById((int) id);
            return View(organization);
        }

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                //ModelState.Clear();

                try
                {
                    if (_manager.Update(organization))
                    {
                        ViewBag.Msg = "Updated successfully!";
                        return View();
                    }
                }
                catch (Exception exception)
                {
                    int NameExist = _manager.GetAll(c => c.Name == organization.Name).Count();

                    if (NameExist > 0)
                    {
                        ModelState.AddModelError("Name", "Name already exists in the system");
                    }

                    int ShortNameExist = _manager.GetAll(c => c.ShortName == organization.ShortName).Count();

                    if (ShortNameExist > 0)
                    {
                        ModelState.AddModelError("ShortName", "Short name already exists in the system");
                    }

                }
            }
            return View(organization);
        }

        public ActionResult Details(int id)
        {
            var organization = _manager.GetById(id);

            return View(organization);
        }

        public ActionResult Search()
        {
            return View();
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