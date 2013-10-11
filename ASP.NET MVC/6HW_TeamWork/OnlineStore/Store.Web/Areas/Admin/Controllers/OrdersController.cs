using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using Store.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Store.Web.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private StoreDataContext db = new StoreDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = this.db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Include("OrderedProducts").Include("User").FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", order.UserId);
            ViewBag.Statuses = new List<SelectListItem>() 
            { 
                new SelectListItem() 
                {
                    Text = OrderStatus.Prending.ToString(), 
                    Value = OrderStatus.Prending.ToString(),
                    Selected=order.OrderStatus == OrderStatus.Prending
                },
                new SelectListItem() 
                {
                    Text = OrderStatus.Finished.ToString(), 
                    Value = OrderStatus.Finished.ToString(), 
                    Selected=order.OrderStatus == OrderStatus.Finished
                }
            };
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(order).State = EntityState.Modified;
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", order.UserId);
            ViewBag.Statuses = new List<SelectListItem>() 
            { 
                new SelectListItem() 
                {
                    Text = OrderStatus.Prending.ToString(), 
                    Value = OrderStatus.Prending.ToString(),
                    Selected=order.OrderStatus == OrderStatus.Prending
                },
                new SelectListItem() 
                {
                    Text = OrderStatus.Finished.ToString(), 
                    Value = OrderStatus.Finished.ToString(), 
                    Selected=order.OrderStatus == OrderStatus.Finished
                }
            };
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = this.db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return PartialView("_Delete", order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = this.db.Orders.FirstOrDefault(x => x.Id == id);
            var orderedProducts = this.db.OrderedProducts.Where(x => x.OrderId == order.Id);

            this.db.OrderedProducts.RemoveRange(orderedProducts);
            this.db.Orders.Remove(order);
            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult All([DataSourceRequest] DataSourceRequest request)
        {
            var pendingOrders = this.db.Orders.Where(x => x.OrderStatus != OrderStatus.Open).Select(Store.Web.Areas.Admin.Models.OrderViewModel.FromOrder);
            return Json(pendingOrders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProducts([DataSourceRequest] DataSourceRequest request, int id)
        {
            var orderedProducts = this.db.OrderedProducts.Where(x => x.OrderId != id).Select(Store.Web.Areas.Admin.Models.OrderedProductViewModelShort.FromOrderedProduct);
            return Json(orderedProducts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
