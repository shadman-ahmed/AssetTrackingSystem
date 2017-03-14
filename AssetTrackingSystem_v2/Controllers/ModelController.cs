using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;
using ATS.Models.Interfaces.BLL;
using ATS.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class ModelController : Controller
    {
        private IManufacturerManager _manufacturerManager;
        private ICategoryManager _categoryManager;
        private IModelManager _modelManager;

        public ModelController()
        {
            _manufacturerManager = new ManufacturerManager();
            _categoryManager = new CategoryManager();
            _modelManager = new ModelManager();

            PartialMenuView();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ManufacturerList = GetManufacturers();
            ViewBag.CategoryList = GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model model)
        {
            ViewBag.ManufacturerList = GetManufacturers();
            ViewBag.CategoryList = GetCategories();

            if (ModelState.IsValid && model != null)
            {
                ModelState.Clear();
                try
                {
                    var modelList = _modelManager.GetAll(c => true);

                    int modelExist = modelList
                                        .Where(c => c.ManufacuturerId == model.ManufacuturerId)
                                        .Where(c => c.CategoryId == model.CategoryId)
                                        .Where(c => c.Name == model.Name)
                                        .Count();

                    if (modelExist > 0)
                    {
                        model.Name = null;
                        ModelState.AddModelError("Name",
                            "Model already exists.");
                    }
                    else
                    {
                        if (_modelManager.Add(model))
                        {
                            ViewBag.Msg = "model added successfully!";
                            return View();
                        }
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.ManufacturerList = GetManufacturers();
            ViewBag.CategoryList = GetCategories();

            var model = _modelManager.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Model model)
        {
            ViewBag.ManufacturerList = GetManufacturers();
            ViewBag.CategoryList = GetCategories();

            if (ModelState.IsValid && model != null)
            {
                try
                {
                    if (_modelManager.Update(model))
                    {
                        ViewBag.Msg = "Model info updated successfully!";
                    }
                    else
                    {
                        if (_modelManager.GetAll(c => c.Id != model.Id && c.Name == model.Name).Count() > 0)
                        {
                            ModelState.AddModelError("Name", "Model already exists.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    ViewBag.Msg = exception.GetType().ToString();
                }
            }

            return View(model);
        }

        public ActionResult Search()
        {

            return View();
        }

        public ActionResult Delete(int id)
        {
            var model = _modelManager.GetById(id);
            try
            {
                if (_modelManager.Remove(model))
                {
                    ViewBag.Msg = "Model deleted Successfully";
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
            var model = _modelManager.GetById(id);

            return View(model);
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "Model";

            return PartialView("_PartialMenu");
        }

        public List<SelectListItem> GetManufacturers()
        {
            var manufacturerDropDownList = new List<SelectListItem>();
            manufacturerDropDownList.Insert(0, new SelectListItem() { Text = "Select Manufacturer", Value = string.Empty });

            try
            {
                var manufacturerList = _manufacturerManager.GetAll(c => true);

                foreach (var manufacturer in manufacturerList)
                {
                    var item = new SelectListItem() { Text = manufacturer.Code + "-" + manufacturer.Name, Value = manufacturer.Id.ToString() };
                    manufacturerDropDownList.Add(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return manufacturerDropDownList;
        }

        public List<SelectListItem> GetCategories()
        {
            var categoryDropDownList = new List<SelectListItem>();
            categoryDropDownList.Insert(0, new SelectListItem() { Text = "Select Category", Value = string.Empty });

            try
            {
                var categoryList = _categoryManager.GetAll(c => true);

                foreach (var category in categoryList)
                {
                    var item = new SelectListItem() { Text = category.Code + "-" + category.Name, Value = category.Id.ToString() };
                    categoryDropDownList.Add(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return categoryDropDownList;
        }

        public JsonResult GetManufacturerById(int? id)
        {
            Manufacturer manufacturer = null;

            if (id != null)
            {
                manufacturer = _manufacturerManager.GetById((int)id);
            }

            return Json(manufacturer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryById(int? id)
        {
            Category category = null;

            if (id != null)
            {
                category = _categoryManager.GetById((int)id);
            }

            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllModels()
        {
            var modelList = _modelManager.GetAll(c => true);
            var categoryList = _categoryManager.GetAll(c => true);
            var manufacturerList = _manufacturerManager.GetAll(c => true);


            var assetModelList = from m in modelList
                                 join mf in manufacturerList on m.ManufacuturerId equals mf.Id
                                 select new
                                 {
                                     Model = m,
                                     Manufacuturer = mf.Name,
                                     Name = m.Name,
                                     m.Description,
                                     m.CategoryId
                                 } into intermediate
                                 join c in categoryList on intermediate.CategoryId equals c.Id
                                 select new
                                 {
                                     Model = intermediate.Model,
                                     Manufacuturer = intermediate.Manufacuturer,
                                     Category = c.Name,
                                     Name = intermediate.Name,
                                     Description = intermediate.Description
                                 };


            return Json(assetModelList, JsonRequestBehavior.AllowGet);
        }
    }
}