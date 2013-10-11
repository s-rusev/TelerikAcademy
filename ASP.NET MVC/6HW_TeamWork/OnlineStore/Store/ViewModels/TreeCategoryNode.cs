using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.ViewModels
{
    public class TreeCategoryNode
    {
        public string Name { get; set; }
        public IEnumerable<ProductNode> Items { get; set; }
        public bool HasChildren { get; set; }
    }
}