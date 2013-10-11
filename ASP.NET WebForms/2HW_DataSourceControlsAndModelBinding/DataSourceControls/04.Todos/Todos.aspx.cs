using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.Todos
{
    public partial class Todos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            TodosEntities context = new TodosEntities();
            string categoryName = this.TextBoxCategoryName.Text;

            if (!string.IsNullOrEmpty(categoryName))
            {
                Category category = new Category()
                {
                    Name = categoryName
                };
                context.Categories.Add(category);
                context.SaveChanges();
                this.ListBoxCategories.DataBind();
            }
        }

        protected void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (this.ListBoxCategories.SelectedValue != null)
            {
                TodosEntities context = new TodosEntities();
                int categoryId = int.Parse(this.ListBoxCategories.SelectedValue);
                Category categoryToDelete = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
                if (categoryToDelete != null)
                {
                    context.Categories.Remove(categoryToDelete);
                    context.SaveChanges();
                    this.ListBoxCategories.DataBind();
                }
            }

        }

        protected void ButtonEditCategory_Click(object sender, EventArgs e)
        {
            if (this.ListBoxCategories.SelectedValue != null)
            {
                TodosEntities context = new TodosEntities();
                int categoryId = int.Parse(this.ListBoxCategories.SelectedValue);
                Category category = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
                if (category != null)
                {
                    category.Name = this.TextBoxEditCategory.Text;
                    context.SaveChanges();
                    this.ListBoxCategories.DataBind();
                }
            }
        }
    }
}