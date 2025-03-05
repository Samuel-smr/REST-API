using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Modelss;

namespace WebApplication1.Dataa
{
    public class CategoryDal : ICategory
    {
        private List<Category> _categories = new List<Category>();
        public CategoryDal(){
            
            _categories = new List<Category>{
                new Category { categoryId = 1, categoryName = "ASP.NET Core"},
                new Category { categoryId = 2, categoryName = "ASP.NET API"},
                new Category { categoryId = 3, categoryName = "ASP.NET"},
                new Category { categoryId = 4, categoryName = "ASP.NET WAWA"},
                new Category { categoryId = 5, categoryName = "ASP.NET By S"},
                new Category { categoryId = 6, categoryName = "ASP.NET aC"}
            };

        }
        
        public Category AddCategory(Category category)
        {
            _categories.Add(category);
            return category;
        }

        public void DeleteCategory(int categoryId)
        {
            var Category = GetCategoryById(categoryId);
            if (Category != null){
                _categories.Remove(Category);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.categoryId == categoryId);
            return category;
        }

        public Category updateCategory(Category category)
        {
            var exitingCategory = GetCategoryById(category.categoryId);
            if (exitingCategory != null){
                exitingCategory.categoryName = category.categoryName;
            }
            return exitingCategory;
        }
    }
}