using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04EmployeesWithFormView
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            if (Request.Params["id"] == null)
            {
                var context = new NorthwndEntities();
                using (context)
                {
                    this.GridViewEmployeeName.DataSource = context.Employees.ToList();
                    GridViewEmployeeName.DataBind();
                }
            }
            else
            {
                var context = new NorthwndEntities();
                using (context)
                {
                    int id = int.Parse(Request.Params["id"]);
                    this.FormViewEmployee.DataSource = context.Employees
                .Where(x => x.EmployeeID == id)
                .ToList();
                    FormViewEmployee.DataBind();
                }
            }
        }
    }
}