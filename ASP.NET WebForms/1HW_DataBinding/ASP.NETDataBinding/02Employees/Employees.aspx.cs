using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _02Employees
{
    public partial class Employees : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new NorthwndEntities();
            this.GridViewEmployeeName.DataSource = context.Employees.ToList();

            Page.DataBind();
            context.Dispose();
        }

    }
}