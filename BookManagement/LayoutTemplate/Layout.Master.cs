using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.LayoutTemplate
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUserIdentity"] != null)
            {
                lblCurrentUser.Text = Session["CurrentUserIdentity"].ToString();
            }
            else
            {
                lblCurrentUser.Text = "Guest";
            }
        }
    }
}