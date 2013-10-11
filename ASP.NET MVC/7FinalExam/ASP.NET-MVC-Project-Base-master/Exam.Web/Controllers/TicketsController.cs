using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Exam.Models;
using Exam.Web.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Exam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        private IQueryable<TicketListViewModel> GetAllTickets()
        {
            var data = this.Data.Tickets.All().ToList();
            List<TicketListViewModel> res = new List<TicketListViewModel>();

            foreach (var item in data)
            {
                var adding = new TicketListViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author.UserName,
                    Category = item.Category.Name,
                    Priority = Enum.GetName(typeof(Priority), item.Priority),
                };
                res.Add(adding);
            }

            return res.AsQueryable();
        }

        public ActionResult KendoList()
        {
            return View();
        }
        //
        // GET: /Tickets/
        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllTickets().ToDataSourceResult(request), JsonRequestBehavior.AllowGet); //.ToDataSourceResult(request)
        }

        public JsonResult GetTicketsCategoryData()
        {
            var result = this.Data.Categories
                .All()
                .Select(x => new CategoryViewModel
                {
                    CategoryName = x.Name,
                    CategoryId = x.Id
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult GetTicketsPriorityData()
        //{
        //    var result = this.Data.Tickets.
        //        .All()
        //        .Select(x => new
        //        {
        //            CategoryName = x.Name
        //        });

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult AddTicket() 
        {
            return View();
        }


        public ActionResult Search(SubmitSearchModel submitModel)
        {
            var result = this.Data.Tickets.All()
                .Where(x => x.Category.Name == submitModel.CategoryName);


            var endResult = result.Select(x => new TicketViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author.UserName,
                Category = x.Category.Name,
                CommentsCount = x.Comments.Count()
            });

            return View(endResult);
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var viewModel = this.Data.Tickets.All().Where(x => x.Id == id)
                .Select(x => new TicketDetailsViewModel
                {
                    Id = x.Id,
                    Author = x.Author.UserName,
                    Title = x.Title,
                    Category = x.Category.Name,
                    Comments = x.Comments.AsQueryable().Select(y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content }),
                    Priority = x.Priority,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description
                }).FirstOrDefault();

            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    TicketId = commentModel.TicketId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTicket(TicketCreateViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.GetUserName();
                var author = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);


                var authorId = User.Identity.GetUserId();

                var cat = this.Data.Categories.All().FirstOrDefault(x => x.Id == ticket.CategoryId);

                var create = new Ticket
                {
                    Author = author,
                    AuthorId = authorId,
                    Comments = new HashSet<Comment>(),
                    Title = ticket.Title,
                    Priority = ticket.Priority,
                    Description = ticket.Description,
                    Category = cat,
                    ImageUrl = ticket.ImageUrl,
                };

                this.Data.Tickets.Add(create);
                cat.Tickets.Add(create);

                //added a ticket
                author.Points++;

                this.Data.SaveChanges();

                return RedirectToAction("AddTicket");
            }

            return View("AddTicket", ticket);
        }
    }
}