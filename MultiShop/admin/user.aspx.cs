using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultiShop.admin;

namespace MultiShop.admin.inc
{
    public partial class user : System.Web.UI.Page
    {
        AdminClass adminClass = new AdminClass(); // Create an instance of AdminClass

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminLoggedIn"] == null || !(bool)Session["AdminLoggedIn"])
            {
                Response.Redirect("Admin_Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            // Load user data using AdminClass
            UserRepeater.DataSource = adminClass.GetUserData();
            UserRepeater.DataBind();
        }

        protected void StatusButton_Command(object sender, CommandEventArgs e)
        {
            string userId = e.CommandArgument.ToString();
            string currentStatus = adminClass.GetUserStatus(userId);
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";
            adminClass.UpdateUserStatus(userId, newStatus);
            LoadUserData();
        }

        protected string GetButtonCssClass(object status)
        {
            string currentStatus = status.ToString();
            return (currentStatus == "Active") ? "Activate" : "Deactivate";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string userId = btn.CommandArgument;

            // Delete user using AdminClass
            adminClass.DeleteUser(userId);
            LoadUserData();
        }
    }
}
