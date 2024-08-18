using BookManagement.DataAccess.Entity;
using BookManagement.DataAccess.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        string connectionString = string.Empty;
        SqlConnection conn;
        SqlCommand cmd;

        public CategoryRepository()
        {
            connectionString = @"data source=LAPTOP-43NAK8J9\SQLEXPRESS;database=BookManagementDB;trusted_connection=true";
        }
        public bool Add(CategoryEntity entity)
        {
            //code to insert data in database
            try
            {
                int row = 0;
                using (conn = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("spInsertBookCategory", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", entity.CategoryName);
                    cmd.Parameters.AddWithValue("@Discription", entity.Discription);
                    cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);

                    conn.Open();
                    row = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                if(row > 0)
                  return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int CategoryId)
        {
            try
            {
                int row = 0;
                using (conn = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("spDeleteCategory", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                
                    conn.Open();
                    row = cmd.ExecuteNonQuery();
                    conn.Close();
                }

                if (row > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CategoryEntity> GetAll()
        {
            try
            {
                List<CategoryEntity> list = new List<CategoryEntity>();
                using (conn = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("spGetActiveCategory", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            list.Add(new CategoryEntity()
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = Convert.ToString(reader["Name"]),
                                Discription = Convert.ToString(reader["Discription"])
                            });
                        }
                    }
                    conn.Close();
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CategoryEntity GetById(int CategoryId)
        {
            try
            {
                CategoryEntity category = null;
                using (conn = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("spGetCategoryById", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryId", CategoryId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            category =  new CategoryEntity()
                            {
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                CategoryName = Convert.ToString(reader["Name"]),
                                Discription = Convert.ToString(reader["Discription"])
                            };
                        }
                    }
                    conn.Close();
                }
                return category;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(CategoryEntity entity)
        {
            try
            {
                int row = 0;
                using (conn = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("spUpdateCategoryById", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", entity.CategoryName);
                    cmd.Parameters.AddWithValue("@Deiscription", entity.Discription);
                    cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);

                    conn.Open();
                    row = cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
