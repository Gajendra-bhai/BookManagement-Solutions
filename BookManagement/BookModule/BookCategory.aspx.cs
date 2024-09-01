using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookManagement.DataAccess.Entity;
using BookManagement.DataAccess.ServiceInterface;
using BookManagement.DataAccess.Service;


namespace BookManagement.BookModule
{
    public partial class BookCategory : System.Web.UI.Page
    {

        private readonly ICategoryRepository categoryRepository;
        public BookCategory()
        {
            categoryRepository = new CategoryRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetCategory();
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategoryEntity categoryEntity = new CategoryEntity()
            {
                //CategoryId = (hdbCategoryId.Value != "" ? Convert.ToInt32(hdbCategoryId.Value) : 0),
                CategoryId = (ViewState["BookCatId"] != null ? Convert.ToInt32(ViewState["BookCatId"]) : 0),
                CategoryName = txtCategoryName.Text,
                Discription = txtAreaCategoryDiscription.Text,
                IsActive = true
            };

            string CurrentUserId = string.Empty;
            if(Session["CurrentUserIdentity"] != null)
            {
                CurrentUserId = Session["CurrentUserIdentity"].ToString();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "sessionExpire", "toastr[\"info\"](\"OOPS! Session is expired.\", \"Session Expired\")", true);
                return;
            }

            if (categoryEntity.CategoryId == 0)
            {
                if (categoryRepository.Add(categoryEntity))
                {
                    ClearForm();
                    GetCategory();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateSuccessKey", "toastr[\"success\"](\"Record Inserted\", \"Success Message\")", true);
                }
                else
                {
                    //Notify User that data not saved
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateErrorKey", "toastr[\"error\"](\"Record not Inserted\", \"Error Message\")", true);

                }
            }
            else
            {
                categoryRepository.Update(categoryEntity);
                GetCategory();
                ClearForm();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "updateKey", "toastr[\"success\"](\"Record Updated\", \"Success Message\")", true);

            }

        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void GetCategory()
        {
            CategoryGrid.DataSource = categoryRepository.GetAll();
            CategoryGrid.DataBind();
        }
        private void ClearForm()
        {
            //hdbCategoryId.Value = null;
            if(ViewState["BookCatId"] != null)
            {
                ViewState["BookCatId"] = null;
            }
            txtCategoryName.Text = string.Empty;
            txtAreaCategoryDiscription.Text = string.Empty;
        }

        protected void CategoryGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CategoryId = Convert.ToInt32(CategoryGrid.DataKeys[e.RowIndex].Value);
            //Code to delete this data
            if (categoryRepository.Delete(CategoryId))
            {
                GetCategory();
                //Notify user that data save
                ClientScript.RegisterClientScriptBlock(this.GetType(), "DeleteKey", "toastr[\"success\"](\"Record removed\", \"Success Message\")", true);
            }
            else
            {
                //Notify User that data not saved
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CreateErrorKey", "toastr[\"error\"](\"Record not removed\", \"Error Message\")", true);

            }
        }


        protected void CategoryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

            int CatId = Convert.ToInt32(CategoryGrid.DataKeys[CategoryGrid.SelectedIndex].Value);

            CategoryEntity category = categoryRepository.GetById(CatId);
            if (category != null)
            {
                //hdbCategoryId.Value = category.CategoryId.ToString();
                if (ViewState["BookCatId"] == null)
                {
                    ViewState["BookCatId"] = category.CategoryId.ToString();
                }
                txtCategoryName.Text = category.CategoryName;
                txtAreaCategoryDiscription.Text = category.Discription;
            }
            else
            {
                //Notify User that data not saved
                ClientScript.RegisterClientScriptBlock(this.GetType(), "infoKey", "toastr[\"info\"](\"Record not fount\", \"Information Message\")", true);

            }
        }
    }
}