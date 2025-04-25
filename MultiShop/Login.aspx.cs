using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class Login : System.Web.UI.Page
    {
        
        private UserClass  ucs= new UserClass();

        protected void login_button_Click(object sender, ImageClickEventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            var (isAuthenticated, status) = ucs.AuthenticateUser(enteredUsername, enteredPassword);

            if (isAuthenticated)
            {
                if (status == "Active")
                {
                    Session["UserName"] = enteredUsername;
                    Response.Redirect("MultiShop.aspx");
                }
                else
                {
                    messageLiteral.Text = "<p style='color: red;'>Your account is currently inactive. Please contact support.</p>";
                    messageLiteral.Visible = true;
                }
            }
            else
            {
                messageLiteral.Text = "<p style='color: red;'>Invalid username or password.</p>";
                messageLiteral.Visible = true;
            }
        }

    }
}