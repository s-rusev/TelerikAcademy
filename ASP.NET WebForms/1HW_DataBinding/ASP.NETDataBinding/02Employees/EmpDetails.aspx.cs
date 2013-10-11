using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02Employees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["id"] == null)
            {
                Response.Redirect("Employees.aspx");
            }
            int id = int.Parse(Request.Params["id"]);

            var context = new NorthwndEntities();
            this.DetailViewEmployee.DataSource = context.Employees
                .Where(x=> x.EmployeeID == id)
                .ToList();
            DetailViewEmployee.DataBind();
            context.Dispose();
        }
    }
}