using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06EmployeesWithListView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new NorthwndEntities();
            this.ListViewEmployee.DataSource = context.Employees.ToList();
            ListViewEmployee.DataBind();
            context.Dispose();
        }
    }
}