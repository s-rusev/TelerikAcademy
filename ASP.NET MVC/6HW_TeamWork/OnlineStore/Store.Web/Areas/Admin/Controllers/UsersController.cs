using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private StoreDataContext db = new StoreDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = this.db.Users.Include("Roles").FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var roles = this.db.Roles.Select(x => new SelectListItem()
            {
                Value = x.Id,
                Text = x.Name,
                Selected = x.UserRoles.Any(r => r.UserId == x.Id)
            }).ToList();

            this.ViewBag.Roles = roles;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreUser user, string role)
        {
            var dbUser = this.db.Users.FirstOrDefault(x => x.Id == user.Id);
            if (dbUser == null)
            {
                return this.RedirectToAction("Index");
            }

            if (this.ModelState.IsValid)
            {
                dbUser.Email = user.Email;
                var userRole = this.db.UserRoles.FirstOrDefault(x => x.UserId == dbUser.Id);

                if (userRole != null)
                {
                    this.db.UserRoles.Remove(userRole);
                }

                var roleToAdd = new UserRole()
                {
                    UserId = dbUser.Id,
                    RoleId = role
                };
                this.db.UserRoles.Add(roleToAdd);

                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult All([DataSourceRequest] DataSourceRequest request)
        {
            IQueryable<Store.Web.Areas.Admin.Models.UserViewModel> users = this.db.Users.Include("Orders").Where(x => x.UserName != this.User.Identity.Name)
                                                                               .Select(Store.Web.Areas.Admin.Models.UserViewModel.FromUser);

            return Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}