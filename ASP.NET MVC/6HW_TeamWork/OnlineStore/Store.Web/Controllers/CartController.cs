using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using Store.Data;
using Microsoft.AspNet.Identity;
using Store.Web.ViewModels;

namespace Store.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private StoreDataContext db = new StoreDataContext();

        // GET: /Cart/
        public ActionResult Index()
        {
            var cartOrder = db.Orders.Include(o => o.OrderedProducts)
                .Where(o => o.OrderStatus == OrderStatus.Open).FirstOrDefault();

            var offer = this.db.Products.OrderBy(x => Guid.NewGuid()).Select(ProductViewModel.FromProduct).FirstOrDefault();
            this.ViewBag.Offer = offer;
            return View(cartOrder);
        }

        public ActionResult Purchase(FormCollection orderProperties)
        {
            string userId = User.Identity.GetUserId();
            Order order = db.Orders.Include(o => o.OrderedProducts.Select(p => p.Product))
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Open).FirstOrDefault();
            if (order != null)
            {
                    if (TryUpdateModel(order, new string[] { "Id", "Address", "Notes", "Recipient" }))
                    {
                        order.Date = DateTime.Now;
                        order.OrderStatus = OrderStatus.Prending;
                        bool hasCountError = false;
                        foreach (OrderedProduct orderedProduct in order.OrderedProducts)
                        {
                            if (orderedProduct.Product.Stock < orderedProduct.Count)
                            {
                                TempData["ErrorMessage"] = String.Format(
                                    @"The product '{0}' has {1} units in stock and you are trying to purchase {2}. 
                                    Please change the count of the purchased items to be in the valid boundaries.", 
                                    orderedProduct.Product.Name, orderedProduct.Product.Stock, orderedProduct.Count
                                );
                                hasCountError = true;
                                break;
                            }
                            else
                            {
                                orderedProduct.Product.Stock -= orderedProduct.Count;
                            }
                        }

                        if (!hasCountError)
                        {
                            db.Entry<Order>(order).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            TempData["SuccessMessage"] = "The order was purchased. Thank you for shopping in our store.";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = String.Empty;
                        bool stop = false;
                        foreach (ModelState modelState in ModelState.Values)
                        {
                            foreach (ModelError error in modelState.Errors)
                            {
                                TempData["ErrorMessage"] += error.ErrorMessage;
                                stop = true;
                                break;
                            }
                            if (stop) { break; }
                        }
                    }
                }
                else
                {
                TempData["ErrorMessage"] = "There is no carts found. Please try again.";
                }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change(int id, int? count)
        {
            if (count != null && count.Value > 0)
            {
                OrderedProduct product = db.OrderedProducts.Include(o => o.Product)
                    .Where(o => o.Id == id).FirstOrDefault();
                if (product != null)
                {
                    if (product.Product.Stock < count)
                    {
                        TempData["ErrorMessage"] = String.Format("You can't buy {0} units because there is no so units in the stock.", count);
                    }
                    else
                    {
                        product.Count = count.Value;
                        db.SaveChanges();
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid product id. Please try again.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid count. The count must be a numeric value greater than 0. Please try again.";
            }

            return RedirectToAction("Index");
        }

        // POST: /Cart/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            OrderedProduct product = db.OrderedProducts.Find(id);
            if (product != null)
            {
                db.OrderedProducts.Remove(product);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Add(int productId)
        {
            string userId = User.Identity.GetUserId();
            Order order = db.Orders.Include(o => o.OrderedProducts.Select(p => p.Product))
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Open).FirstOrDefault();
            Product product = db.Products.Find(productId);

            if (order != null)
            {
                if (product != null)
                {
                    if (product.Stock > 0)
                    {
                        OrderedProduct orderedProduct = order.OrderedProducts.FirstOrDefault(p => p.ProductId == productId);
                        if (orderedProduct != null)
                        {
                            orderedProduct.Count += 1;
                        }
                        else
                        {
                            order.OrderedProducts.Add(new OrderedProduct()
                            {
                                ProductId = productId,
                                Count = 1
                            });
                        }

                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "The product is unavaliable in the stock. Please wait for few days and follow the product's count in the stock.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid product. Please try again.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "There is no carts found. Please try again.";
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
