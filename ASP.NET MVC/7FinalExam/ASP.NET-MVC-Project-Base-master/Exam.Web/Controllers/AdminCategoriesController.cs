using Exam.Web.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Data.Entity;
using Exam.Models;

namespace Exam.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCategoriesController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            //  ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", category.ManufacturerId);
            return View(category);
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                .Select(x => new CategoryViewModel
                    {
                        CategoryId = x.Id,
                        CategoryName = x.Name
                    });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var categoryDb = this.Data.Categories.GetById(category.CategoryId);

            categoryDb.Name = category.CategoryName;
            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var categoryDb = this.Data.Categories.GetById(category.CategoryId);

            foreach (var ticket in categoryDb.Tickets.ToList())
            {
                foreach (var comment in ticket.Comments.ToList())
                {
                    this.Data.Comments.Delete(comment);
                }
                this.Data.Tickets.Delete(ticket);
            }

            this.Data.Categories.Delete(category.CategoryId);
            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
