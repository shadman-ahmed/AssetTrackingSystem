using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem_v2.Models;
using ATS.BLL;
using ATS.Models.Interfaces.BLL;

namespace AssetTrackingSystem_v2.Controllers
{
    public class LoaderController : Controller
    {
        private IOrganizationManager _organizationManager;
        private IBranchManager _branchManager;
        private ILocationManager _locationManager;
        private IGeneralCategoryManager _generalCategoryManager;
        private ICategoryManager _categoryManager;
        private IManufacturerManager _manufacturerManager;
        private IModelManager _modelManager;

        public LoaderController()
        {
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
            _locationManager = new LocationManager();
            _generalCategoryManager = new GeneralCategoryManager();
            _categoryManager = new CategoryManager();
            _manufacturerManager = new ManufacturerManager();
            _modelManager = new ModelManager();
        }
        public JsonResult GetAllOrganization()
        {

            var organizations = _organizationManager.GetAll(c => true).ToList();

            return Json(organizations, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOrganizationById(int? id)
        {
            Organization organization = null;

            if (id != null)
            {
                organization = _organizationManager.GetById((int)id);
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
        public JsonResult GetBranchById(int? id)
        {
            Branch branch = null;

            if (id != null)
            {
                branch = _branchManager.GetById((int)id);
            }

            return Json(branch, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBranchesByOrganization(int? id)
        {
            var branchList = _branchManager.GetAll(c => true);

            if (id != null)
            {
                branchList = branchList.Where(c => c.OrganizationId == id).ToList();
            }

            return Json(branchList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLocations()
        {
            var locationList = _locationManager.GetAll(c => true);
            var organizationList = _organizationManager.GetAll(c => true);
            var branchList = _branchManager.GetAll(c => true);


            var assetLocationList = from l in locationList
                                    join org in organizationList on l.OrganizationId equals org.Id
                                    select new
                                    {
                                        Location = l,
                                        Organization = org.Name,
                                        Name = l.Name,
                                        l.BranchId,
                                        l.ShortName,
                                        l.Code
                                    } into intermediate
                                    join b in branchList on intermediate.BranchId equals b.Id
                                    select new
                                    {
                                        Location = intermediate.Location,
                                        Organization = intermediate.Organization,
                                        Branch = b.Name,
                                        Name = intermediate.Name,
                                        ShortName = intermediate.ShortName,
                                        Code = intermediate.Code
                                    };


            return Json(assetLocationList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllGeneralCategory()
        {

            var generalCategories = _generalCategoryManager.GetAll(c => true).ToList();

            return Json(generalCategories, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGeneralCategoryById(int? id)
        {
            GeneralCategory generalCategory = null;

            if (id != null)
            {
                generalCategory = _generalCategoryManager.GetById((int)id);
            }

            return Json(generalCategory, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCategories()
        {
            var categoryList = _categoryManager.GetAll(c => true);
            var generalCategoryList = _generalCategoryManager.GetAll(c => true);

            var subCategoryList = categoryList.Join(generalCategoryList, category => category.GeneralCategoryId, gnrl => gnrl.Id,
                (category, gnrl) => new
                {
                    GeneralCategory = gnrl.Name,
                    Category = category
                });

            return Json(subCategoryList, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAllManufacturer()
        {

            var manufacturers = _manufacturerManager.GetAll(c => true).ToList();

            return Json(manufacturers, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAllModels()
        {
            var modelList = _modelManager.GetAll(c => true);
            var categoryList = _categoryManager.GetAll(c => true);
            var manufacturerList = _manufacturerManager.GetAll(c => true);


            var assetModelList = from m in modelList
                                 join mf in manufacturerList on m.ManufacturerId equals mf.Id
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
        public JsonResult GetModelsByManufacturerId(int? id)
        {
            var modelList = _modelManager.GetAll(c => true);

            if (id != null)
            {
                modelList = modelList.Where(c => c.ManufacturerId == id).ToList();
            }

            return Json(modelList, JsonRequestBehavior.AllowGet);
        }
    }
}