using BookManagement.DataAccess.Entity;
using BookManagement.DataAccess.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BookManagement.DataAccess.Service
{
    public class BookRepository : IBookRepository
    {
        string connectionString = string.Empty;

        public BookRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BookMangementDB"].ConnectionString;
        }
        public bool Add(BookEntity entity)
        {
            try
            {
                int row = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddBook", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", entity.Title);
                    cmd.Parameters.AddWithValue("@SBIN", entity.SBIN);
                    cmd.Parameters.AddWithValue("@Price", entity.Price);
                    cmd.Parameters.AddWithValue("@Author", entity.Author);
                    cmd.Parameters.AddWithValue("@Discription", entity.Discription);
                    cmd.Parameters.AddWithValue("@CategoryId", entity.CategoryId);
                    cmd.Parameters.AddWithValue("@CoverPhotoPath", entity.CoverPhotoPath);

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
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
