using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<TreeViewItemModel> TreeViewItems { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}