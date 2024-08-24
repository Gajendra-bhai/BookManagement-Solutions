using BookManagement.DataAccess.Entity;
using BookManagement.DataAccess.Service;
using BookManagement.DataAccess.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace BookManagement.BookModule
{
    public partial class Book : System.Web.UI.Page
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IBookRepository bookRepository;
        public Book()
        {
            categoryRepository = new CategoryRepository();
            bookRepository = new BookRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Catlist = categoryRepository.GetAll();
                DdlCategory.DataSource = Catlist;
                DdlCategory.DataBind();

                DdlCategory.Items.Insert(0, new ListItem() { Text = "Select Category", Value = "-1" });
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string FolderName = "BookCoverPhotot";
            string filePath = null;
            if (fileCoverPhoto.HasFile)
            {
                string guidId = Guid.NewGuid().ToString();
                string FileName = Path.GetFileNameWithoutExtension(fileCoverPhoto.PostedFile.FileName) +
                    "_" + guidId + Path.GetExtension(fileCoverPhoto.PostedFile.FileName);

                filePath = Path.Combine(Server.MapPath("~/Content/BookCoverPhotot"), FileName);

                fileCoverPhoto.PostedFile.SaveAs(filePath);
            }
            BookEntity book = new BookEntity()
            {
                Title = txtTitle.Text,
                SBIN = txtSBIN.Text,
                Author = DdlAuthors.SelectedValue,
                Price = Convert.ToInt32(txtPrice.Text),
                Discription = txtAreabookDiscription.Text,
                CategoryId = Convert.ToInt32(DdlCategory.SelectedValue),
                CoverPhotoPath = filePath
            };

            if (bookRepository.Add(book))
            {
                //success notification and clear form data
                ClearForm();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateSuccessKey", "toastr[\"success\"](\"Record Inserted\", \"Success Message\")", true);
                 
            }
            else
            {
                //error notification
                ClearForm();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateErrorKey", "toastr[\"error\"](\"Record not Inserted\", \"Error Message\")", true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtSBIN.Text = string.Empty;
            DdlAuthors.SelectedIndex = -1;
            txtPrice.Text = string.Empty;
            txtAreabookDiscription.Text = string.Empty;
            DdlCategory.SelectedIndex = -1;
           

        }
    }
}