using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {

       
        private AdminClass adminHandler = new AdminClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Nothing required here for now
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string adminName = AdminNameTextBox.Text.Trim();
            string adminPass = AdminPassTextBox.Text.Trim();

            string result = adminHandler.AuthenticateAdmin(adminName, adminPass, Session);

            if (result == "success")
            {
                Response.Redirect("Buy_Product.aspx");
            }
            else
            {
                LoginAlert.Visible = true;
                LoginAlert.Text = result;
            }
        }
    }
}