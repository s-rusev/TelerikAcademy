using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Store.Data;
using System;
using System.Linq;
using System.Web.Mvc;
using Store.Web.Utilities;
using Store.Web.ViewModels;
using Store.Web.Models;
using Store.Models;
using System.Collections.Generic;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string AllProductsToken = "All";
        private StoreDataContext db = new StoreDataContext();

        public ActionResult Index()
        {
            var parentCategories = this.db.Categories.Where(x => x.Parent == null).ToList();

            var categories = new List<TreeViewItemModel>();
            foreach (var parent in parentCategories)
            {
                var parentNode = new TreeViewItemModel()
                {
                    Text = parent.Name,
                    ImageUrl = "~/img/category.png"
                };

                parentNode.Items = this.db.Categories.Where(x => x.Parent.Id == parent.Id)
                    .Select(x => new TreeViewItemModel()
                    {
                        Text = x.Name,
                        ImageUrl = "~/img/category.png"
                    }).ToList();

                categories.Add(parentNode);
            }

            return View(categories);
        }

        public ActionResult ProductsListView(ProductsListViewModel model)
        {
            return PartialView("_ProductsListView", model);
        }

        public ActionResult Products([DataSourceRequest] DataSourceRequest request, ProductsListViewModel model)
        {
            IQueryable<Product> products = this.db.Products;

            if (model.Query != null)
            {
                products = products.Where(x => x.Name.Contains(model.Query));
            }

            if (model.Category != null && model.Category != AllProductsToken)
            {
                products = products.Where(x => x.Category.Name == model.Category || x.Category.Parent.Name == model.Category);
            }

            var result = products.ConvertToProductsViewModel();

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AutoComplete(string text)
        {
            var books = this.db.Products.Where(x => x.Name.Contains(text))
                .Select(x => new { Name = x.Name });
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductDetails(int? Id)
        {
            if (Id != null)
            {
                var found = db.Products.Single(x => x.Id == Id);
                return View("ProductDetails", found);
            }

            return View("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Search(string query)
        {
            var model = new ProductsListViewModel()
            {
                Query = query
            };
            return View(model);
        }
    }
}