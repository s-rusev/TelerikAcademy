using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SchoolHierarchy
{
    interface ICommentable
    {
        List<String> Comments { get; }
        void AddComment(string comment);
    }
}
