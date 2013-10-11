﻿using System.IO;
using System.Web.WebPages.Razor.Configuration;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {

        StoreDataContext context = new StoreDataContext();
        //
        // GET: /Products/
        [HttpGet]
        [ActionName("GetProduct")]
        public ActionResult Index(int id)
        {
            using (context)
            {
                var product =
                    context.Products.Where(x => x.Id == id).Select(Store.Web.ViewModels.ProductViewModel.FromProduct).FirstOrDefault();
                if (product == null)
                {
                    // error
                }

                product.PhotosUrlList = MapImagePaths(id);
                return View(product);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult OrderNow(int id)
        {
            var orderModel = new Store.Web.ViewModels.OrderViewModel()
            {
                ProductId = id
            };

            return View(orderModel);
        }

        private List<string> MapImagePaths(int productId)
        {
            string imagePath = "~/Content/Images/" + productId;
            List<string> filePaths =
                Directory.GetFiles(Server.MapPath(imagePath)).Select(path => Path.GetFileName(path)).ToList();
            
            return filePaths;
        } 
	}
}