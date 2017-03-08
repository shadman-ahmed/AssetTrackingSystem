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
    public class CategoryController : Controller
    {
        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;

        public CategoryController()
        {
            _generalCategoryManager = new GeneralCategoryManager();
            _categoryManager = new CategoryManager();
            PartialMenuView();

        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GeneralCategoryList = GetGeneralCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            ViewBag.generalCategoryList = GetGeneralCategories();

            if (ModelState.IsValid && category != null)
            {
                ModelState.Clear();
                try
                {
                    var categoryList = _categoryManager.GetAll(c => true);

                    int categoryExist = categoryList
                                        .Where(c => c.GeneralCategoryId == category.GeneralCategoryId)
                                        .Where(c => c.ShortName == category.ShortName)
                                        .Count();

                    if (categoryExist > 0)
                    {
                        category.ShortName = null;
                        ModelState.AddModelError("ShortName",
                            "Short name for the category already exists for the generalCategory");
                    }
                    else
                    {
                        if (_categoryManager.Add(category))
                        {
                            ViewBag.Msg = "Category added successfully!";
                            return View();
                        }
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.generalCategoryList = GetGeneralCategories();
            var category = _categoryManager.GetById(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            ViewBag.generalCategoryList = GetGeneralCategories();

            if (ModelState.IsValid && category != null)
            {
                try
                {
                    if (_categoryManager.Update(category))
                    {
                        ViewBag.Msg = "Category info updated successfully!";
                    }
                    else
                    {
                        if (_categoryManager.GetAll(c => c.Id != category.Id && c.ShortName == category.ShortName).Count() > 0)
                        {
                            ModelState.AddModelError("ShortName", "ShortName for a category already exist for the general Category");
                        }
                    }
                }
                catch (Exception exception)
                {
                    ViewBag.Msg = exception.GetType().ToString();
                }
            }

            return View(category);
        }

        public ActionResult Search()
        {
            var categoryList = _categoryManager.GetAll(c => true);
            return View(categoryList);
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryManager.GetById(id);
            try
            {
                if (_categoryManager.Remove(category))
                {
                    ViewBag.Msg = "Category deleted Successfully";
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
            var category = _categoryManager.GetById(id);

            return View(category);
        }

        public ActionResult PartialMenuView()
        {
            /* Action is used to load the menu dynamically when traversing from page to page */
            ViewBag.Menu = "Asset Info";
            ViewBag.SubMenu = "Category";

            return PartialView("_PartialMenu");
        }

        public List<SelectListItem> GetGeneralCategories()
        {
            var generalCategoryDropDownList = new List<SelectListItem>();
            generalCategoryDropDownList.Insert(0, new SelectListItem() { Text = "Select generalCategory", Value = string.Empty });

            try
            {
                var generalCategoryList = _generalCategoryManager.GetAll(c => true);

                foreach (var generalCategory in generalCategoryList)
                {
                    var item = new SelectListItem() { Text = generalCategory.Name, Value = generalCategory.Id.ToString() };
                    generalCategoryDropDownList.Add(item);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return generalCategoryDropDownList;
        }

        public JsonResult GetgeneralCategoryById(int? id)
        {
            GeneralCategory generalCategory = null;

            if (id != null)
            {
                generalCategory = _generalCategoryManager.GetById((int)id);
            }

            return Json(generalCategory, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllcategoryes()
        {
            var categoryList = _categoryManager.GetAll(c => true);
            var generalCategoryList = _generalCategoryManager.GetAll(c => true);

            var orgcategoryList = categoryList.Join(generalCategoryList, category => category.GeneralCategoryId, org => org.Id,
                (category, org) => new
                {
                    generalCategory = org.Name,
                    category = category
                });

            return Json(orgcategoryList, JsonRequestBehavior.AllowGet);
        }
        
    }
}