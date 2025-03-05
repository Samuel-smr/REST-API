using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modelss;

namespace WebApplication1.Dataa
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category AddCategory (Category category);
        Category updateCategory(Category category);
        void DeleteCategory (int categoryId);
    }
}