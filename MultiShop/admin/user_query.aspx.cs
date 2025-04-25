using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultiShop.admin;

namespace MultiShop.admin
{
    public partial class user_query : System.Web.UI.Page
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
            // Load user query data using AdminClass
            UserRepeater.DataSource = adminClass.GetUserQueryData();
            UserRepeater.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string queryId = btn.CommandArgument;

            // Delete specific user query using AdminClass
            adminClass.DeleteUserQuery(queryId);
            LoadUserData();
        }

        protected void lnkDeleteAll_Click(object sender, EventArgs e)
        {
            // Delete all user queries using AdminClass
            adminClass.DeleteAllUserQueries();
            LoadUserData();
        }
    }
}
