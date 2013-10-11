using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class TreeCategoryNode
    {
        public string Name { get; set; }
        public IEnumerable<Store.Web.ViewModels.ProductNode> Items { get; set; }

        public bool HasChildren { get; set; }
    }
}