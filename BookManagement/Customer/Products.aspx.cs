using BookManagement.DataAccess.Service;
using BookManagement.DataAccess.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.Customer
{
    public partial class Products : System.Web.UI.Page
    {
        private readonly IBookRepository bookRepository;
        public Products()
        {
            bookRepository = new BookRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                productsrept.DataSource = bookRepository.GetBookProducts();
                productsrept.DataBind();
            }
        }
    }
}