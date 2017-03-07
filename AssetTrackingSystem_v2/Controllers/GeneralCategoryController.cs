using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;
using ATS.Model.Interfaces.BLL;
using ATS.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class GeneralCategoryController : Controller
    {
        private IGeneralCategoryManager _generalCategoryManager;

        public GeneralCategoryController()
        {
            _generalCategoryManager = new GeneralCategoryManager();
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
        public ActionResult Create(GeneralCategory generalCategory)
        {
            //PartialMenuView();
            if (ModelState.IsValid && generalCategory != null)
            {
                ModelState.Clear();

                try
                {
                    if (_generalCategoryManager.Add(generalCategory))
                    {
                        ViewBag.Msg = "Created successfully!";
                        return View();
                    }
                }
                catch (Exception exception)
                {

                    int NameExist = _generalCategoryManager.GetAll(c => c.Name.Equals(generalCategory.Name)).Count();

                    if (NameExist > 0)
                    {
                        generalCategory.Name = null;
                        ModelState.AddModelError("Name", "General Category name already exists");
                    }

                    int ShortNameExits = _generalCategoryManager.GetAll(c => c.ShortName == generalCategory.ShortName).Count();

                    if (ShortNameExits > 0)
                    {
                        generalCategory.ShortName = null;
                        ModelState.AddModelError("ShortName", "Short name already exists");
                    }
                }

            }

            return View(generalCategory);
        }

        public ActionResult Delete(int id)
        {
            var generalCategory = _generalCategoryManager.GetById(id);
            try
            {
                if (_generalCategoryManager.Remove(generalCategory))
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

            var generalCategory = _generalCategoryManager.GetById((int)id);
            return View(generalCategory);
        }

        [HttpPost]
        public ActionResult Edit(GeneralCategory generalCategory)
        {
            if (ModelState.IsValid)
            {
                //ModelState.Clear();

                try
                {
                    if (_generalCategoryManager.Update(generalCategory))
                    {
                        ViewBag.Msg = "Updated successfully!";
                        return View();
                    }
                }
                catch (Exception exception)
                {
                    int NameExist = _generalCategoryManager.GetAll(c => c.Name == generalCategory.Name).Count();

                    if (NameExist > 0)
                    {
                        ModelState.AddModelError("Name", "Name already exists in the system");
                    }

                    int ShortNameExist = _generalCategoryManager.GetAll(c => c.ShortName == generalCategory.ShortName).Count();

                    if (ShortNameExist > 0)
                    {
                        ModelState.AddModelError("ShortName", "Short name already exists in the system");
                    }

                }
            }
            return View(generalCategory);
        }

        public ActionResult Details(int id)
        {
            var generalCategory = _generalCategoryManager.GetById(id);

            return View(generalCategory);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "General Category";

            return PartialView("_PartialMenu");
        }

        public JsonResult GetAllgeneralCategory()
        {

            var generalCategorys = _generalCategoryManager.GetAll(c => true).ToList();

            return Json(generalCategorys, JsonRequestBehavior.AllowGet);
        }
    }
}