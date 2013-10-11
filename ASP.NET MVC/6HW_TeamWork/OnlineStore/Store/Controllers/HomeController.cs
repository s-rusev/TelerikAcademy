using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Store.Data;
using Store.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using Store.Utilities;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        StoreDataContext db = new StoreDataContext();
        public ActionResult Index()
        {
            //select all categories with their books
            var found = db.Categories.Include("Products")
                .Select(c => new TreeCategoryNode
                {
                    Name = c.Name,
                    HasChildren = c.Products.Any(),
                    Items = c.Products.Select(p => new ProductNode
                    {
                        Name = p.Name,
                        Url = System.Data.Entity.SqlServer.SqlFunctions.StringConvert((double)p.Id)
                    }),
                }).ToList();

            //from the found items create kendo items for the tree view
            var treeNodes = found.Select(c => new TreeViewItemModel
            {
                Text = c.Name,
                HasChildren = c.HasChildren,
                Items = c.Items.Select(p => new TreeViewItemModel
                {
                    Text = p.Name,
                    Url = string.Format("{0}{1}", "Home/ProductDetails/", p.Url.TrimStart()),
                    Encoded = false
                }).ToList()
            }).ToList();


            IndexViewModel indexVm = new IndexViewModel();
            indexVm.TreeViewItems = treeNodes;
            indexVm.Products = db.Products.ConvertToProductsViewModel();

            return View(indexVm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products([DataSourceRequest] DataSourceRequest request, string category)
        {
            var products = db.Products.ConvertToProductsViewModel();

            return Json(products.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Search(string query)
        {
            this.ViewBag.Query = query;
            return View();
        }
    }
}