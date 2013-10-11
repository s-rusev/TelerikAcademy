using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Store.Data;
using Store.Models;
using Store.Web.Areas.Admin.Models;

namespace Store.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoriesController : Controller
    {
        private StoreDataContext db = new StoreDataContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, string choosedParent)
        {
            if (db.Categories.Any(x => x.Name == category.Name))
            {
                this.ModelState.AddModelError("Name", string.Format("Category \"{0}\" already exists!", category.Name));
            }

            if (ModelState.IsValid)
            {
                if (choosedParent != null)
                {
                    int parentId = int.Parse(choosedParent);
                    var parentCategory = db.Categories.FirstOrDefault(x => x.Id == parentId);
                    category.Parent = parentCategory;
                    category.Products = new HashSet<Product>();
                }

                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Include("Parent").FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            GenerateCategoryViewBagInfo(category);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, string choosedParent)
        {
            var dbCategory = this.db.Categories.Include("Parent").FirstOrDefault(x => x.Id == category.Id);

            if (db.Categories.Any(x => x.Name == category.Name) && dbCategory.Name != category.Name)
            {
                this.ModelState.AddModelError("Name", string.Format("Category \"{0}\" already exists!", category.Name));
            }

            if (choosedParent == null)
            {
                dbCategory.Parent = null;
            }
            else
            {
                int parentId = int.Parse(choosedParent);
                if (parentId != category.Id)
                {
                    var parentCategory = db.Categories.FirstOrDefault(x => x.Id == parentId);
                    dbCategory.Parent = parentCategory;
                }
                else
                {
                    ModelState.AddModelError("Parent", "Cannot set category parent to itself!");
                }
            }

            if (ModelState.IsValid)
            {
                dbCategory.Name = category.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            GenerateCategoryViewBagInfo(category);

            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Include("Products").FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            bool canBeDeleted = category.Products.Count == 0 && !db.Categories.Any(x => x.Parent.Id == category.Id);
            this.ViewBag.CanBeDeleted = canBeDeleted;
            return PartialView("_Delete", category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            bool canBeDeleted = category.Products.Count == 0 && !db.Categories.Any(x => x.Parent.Id == category.Id);
            if (canBeDeleted)
            {
                db.Categories.Remove(category);
                db.SaveChanges(); 
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult All([DataSourceRequest] DataSourceRequest request)
        {
            var categories = db.Categories.Include("Parent").Include("Products").Select(CategoryViewModel.FromCategory);
            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoriesDropDown(string id, int? parentId)
        {
            IQueryable<Category> categories = db.Categories.OrderBy(x => x.Name);

            if (id != null)
            {
                int intId = int.Parse(id);
                var currentCategory = db.Categories.Include("Parent").FirstOrDefault(x => x.Id == intId);
                categories = categories.Where(x => x.Parent == null && x.Id != intId && x.Parent.Id != currentCategory.Id);
            }

            var model = categories.ToList().Select(
                x => new SelectListItem()
                {
                    Text = x.Name,
                    Selected = x.Id == parentId,
                    Value = x.Id.ToString()
                });

            return PartialView("_CategoriesDropdown", model);
        }

        private void GenerateCategoryViewBagInfo(Category category)
        {
            this.ViewBag.HasParent = category.Parent != null;
            if (this.ViewBag.HasParent)
            {
                this.ViewBag.ParentId = category.Parent.Id;
            }
            else
            {
                this.ViewBag.ParentId = -1;
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
