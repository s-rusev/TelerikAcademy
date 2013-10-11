using System.IO;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Web.Utilities;
using Store.Web.ViewModels;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace Store.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductsController : Controller
    {
        private StoreDataContext db = new StoreDataContext();

        public ActionResult Index()
        {
            var found = db.Products.ToList();
            return View(found);
        }

        public ActionResult ProductsRead([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ProductViewModel> found = db.Products.ConvertToProductsViewModel();
            DataSourceResult result = found.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "PhotosFolderPath")]Product product, IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any())
            {
                ModelState.AddModelError("Invalid Image", "Product must have image!");
            }

            if (ModelState.IsValid)
            {
                
                db.Products.Add(product);
                db.SaveChanges();
                string subPath = "~/Content/Images/" + product.Id; // your code goes here

                bool isExists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!isExists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
                }

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        bool isImage = HttpPostedFileBaseExtensions.IsImage(file);
                        if (isImage)
                        {
                            bool isEmpty = !Directory.EnumerateFiles(Server.MapPath(subPath)).Any();
                            
                            var fileName = Path.GetFileName(file.FileName);
                            var physicalPath = Path.Combine(Server.MapPath(subPath), fileName);
                            file.SaveAs(physicalPath);
                            if (isEmpty)
                            {                                
                                System.IO.File.Move(Server.MapPath(subPath) + "/" + file.FileName,
                                    Server.MapPath(subPath) + "/1.jpg");
                            }
                        }  
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "PhotosFolderPath")] Product product, IEnumerable<HttpPostedFileBase> files)
        {            
            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        bool isImage = HttpPostedFileBaseExtensions.IsImage(file);
                        if (isImage)
                        {
                            string subPath = "~/Content/Images/" + product.Id;
                            bool isEmpty = !Directory.EnumerateFiles(Server.MapPath(subPath)).Any();
                            var fileName = Path.GetFileName(file.FileName);
                            var physicalPath = Path.Combine(Server.MapPath(subPath), fileName);
                            file.SaveAs(physicalPath);
                            if (isEmpty)
                            {
                                System.IO.File.Move(Server.MapPath(subPath) + "/" + file.FileName,
                                    Server.MapPath(subPath) + "/1.jpg");
                            }
                        }                        
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public ActionResult Details(int? id)
        {
            if (!Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
