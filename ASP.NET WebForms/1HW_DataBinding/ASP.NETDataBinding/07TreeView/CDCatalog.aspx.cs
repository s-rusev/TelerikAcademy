using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _07TreeView
{
    public partial class CDCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TreeViewCatalog_SelectedNodeChanged(object sender, EventArgs e)
        {
            this.innerXml.Text = this.TreeViewCatalog.SelectedNode.Target;
        }
    }
}