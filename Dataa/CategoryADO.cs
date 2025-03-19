using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using WebApplication1.Modelss;

namespace WebApplication1.Dataa
{
    /*public class CategoryADO : ICategory
    {
        private readonly IConfiguration _configuration;
        private string conStr = string.Empty;
        public CategoryADO(IConfiguration configuration)
        {
            _configuration = configuration;
            conStr = _configuration.GetConnectionString("DefaultConnection");
        }
        public Category AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            string strSql = @"SELECT * FROM Categories ORDER BY CategoryId = @CategoryId", Select scope_identity()";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                try
                {
                    cmd.parameters.AddWithValue("@CategoryId", categoryId);
                    conn.Open();
                    int Results = cmd.ExecuteNonQuery();
                    if(Results==0)
                    {
                        throw new Exception("Category not found");
                    }
                    return Category;
                }
                catch (exeption ex)
                {
                    throw new Exception(ex.Message);
                    
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }

        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            List<Category> categories = new List<Category>();
            using SqlConnection conn = new SqlConnection(conStr){
                    
                string strSql = @"SELECT * FROM Categories ORDER BY CategoryId = @CategoryId", Select scope_identity()";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                try
                {
                    cmd.parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.parameters.AddWithValue("@CategoryId", categoryId);
                    conn.Open();
                    int Results = cmd.ExecuteNonQuery();
                    if(Results==0)
                    {
                        throw new Exception("Category not found");
                    }
                    return Category;
                }
                catch (exeption ex)
                {
                    throw new Exception(ex.Message);
                    
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                }


                conn.Open();
                sqldatareader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        Category category = new Category();
                        category.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                        category.CategoryName = dr["CategoryName"].ToString();
                        categories.Add(category);
                        return category;
                    }
                }
                dr.Close();
                conn.Close();
                dmc.Dispose();
                
            }
            return Category;
        }

        public Category updateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }*/
}