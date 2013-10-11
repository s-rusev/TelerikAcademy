using Kendo.Mvc.UI;
using LibrarySystem.Models;
using LibrarySystem.Utilities;
using LibrarySystem.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        LibraryDbContext db = new LibraryDbContext();
        public ActionResult Index()
        {
            //select all categories with their books
            var found = db.Categories.Include("Books")
                .Select(c => new TreeCategoryNode
                {
                    Name = c.Name,
                    HasChildren = c.Books.Any(),
                    Items = c.Books.Select(b => new BookNode
                    {
                        Name = b.Title,
                        Url = SqlFunctions.StringConvert((double)b.Id)
                    }),
                }).ToList();


            //from the found items create kendo items for the tree view
            var treeNodes = found.Select(c => new TreeViewItemModel
            {
                Text = c.Name,
                HasChildren = c.HasChildren,
                Items = c.Items.Select(b => new TreeViewItemModel
                {
                    Text = b.Name,
                    Url = string.Format("{0}{1}", "Home/BookDetails/", b.Url.TrimStart()),
                    Encoded = false
                }).ToList()
            }).ToList();

            IndexViewModel indexVm = new IndexViewModel();
            indexVm.TreeViewItems = treeNodes;
            indexVm.Books = db.Books.ConvertToBookViewModel();
            
            return View(indexVm);
        }

        public ActionResult BookDetails(int? Id)
        {
            if (Id != null)
            {
                var found = db.Books.Single(x => x.Id == Id);
                return View("BookDetails", found);
            }

            return View("Index");
        }
    }
}