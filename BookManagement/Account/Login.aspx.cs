using BookManagement.DataAccess.Service;
using BookManagement.DataAccess.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly IApplicationUserService applicationUserService;

        public Login()
        {
            applicationUserService = new ApplicationUserService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie ck = Request.Cookies["AuthUser"];
                if (ck != null)
                {
                    string userid = ck["userId"];
                    string password = ck["password"];
                    if (applicationUserService.Validate(userid, password))
                    {
                        Session["CurrentUserIdentity"] = userid;
                        Response.Redirect("~/BookModule/BookCategory.aspx");
                    }

                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UserId = txtUserId.Text;
            string password = txtPassword.Text;

            if (applicationUserService.Validate(UserId, password))
            {
                //login success
                if (chkRemberme.Checked)
                {
                    HttpCookie ck = new HttpCookie("AuthUser");
                    ck["userId"] = UserId;
                    ck["password"] = password;
                    ck.Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(ck);

                }
                Session["CurrentUserIdentity"] = UserId;
                Response.Redirect("~/BookModule/BookCategory.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "invalid", "toastr[\"error\"](\"invalid userid or password\", \"invalid credentials\")", true);

            }
        }
    }
}