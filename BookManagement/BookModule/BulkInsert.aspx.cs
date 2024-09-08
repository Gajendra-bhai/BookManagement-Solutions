using BookManagement.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.BookModule
{
    public partial class BulkInsert : System.Web.UI.Page
    {
        List<CategoryEntity> categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CategoryGrid.DataSource = new List<CategoryEntity>();
                CategoryGrid.DataBind();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategoryEntity bookCategory = new CategoryEntity()
            {
                CategoryName = txtCategoryName.Text,
                Discription = txtAreaCategoryDiscription.Text
            };

            if (ViewState["CategoryList"] == null)
            {
                categories = new List<CategoryEntity>();
            }
            else
            {
                categories = (List<CategoryEntity>)ViewState["CategoryList"];
            }

            categories.Add(bookCategory);

            ViewState["CategoryList"] = categories;

            CategoryGrid.DataSource = categories;
            CategoryGrid.DataBind();

            //using(SqlBulkCopy copy = new SqlBulkCopy(new SqlConnection("ConnectionString")))
            //{
            //    copy.DestinationTableName = "TBookCategory";
            //    copy.ColumnMappings.Add("sourcecolumnName1", "DestnitationColumnName1");
            //    copy.BatchSize = 1000;
            //   // copy.WriteToServer(DataTable);
            //}
        }
    }
}