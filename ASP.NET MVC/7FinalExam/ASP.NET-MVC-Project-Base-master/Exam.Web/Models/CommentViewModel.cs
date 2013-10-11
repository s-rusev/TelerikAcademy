using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string AuthorUsername { get; set; }

        public string Content { get; set; }

        //public static Expression<Func<Comment, CommentViewModel>> FromComment
        //{
        //    get
        //    {
        //        return y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content };
        //    }
        //}
    }
}