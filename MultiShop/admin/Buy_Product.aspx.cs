using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop.admin
{
    public partial class Booking : System.Web.UI.Page
    {
        private AdminClass adminHandler = new AdminClass();  // Create an instance of AdminClass

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminLoggedIn"] == null || !(bool)Session["AdminLoggedIn"])
            {
                Response.Redirect("Admin_Login.aspx");
            }

            if (!IsPostBack)
            {
                adminHandler.LoadUserData(UserRepeater);
            }
        }

        // **Delete Order**
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;

            adminHandler.DeleteOrder(delId);
            adminHandler.LoadUserData(UserRepeater);
        }

        // **Mark Order as Shipped**
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string orderId = btn.CommandArgument;

            adminHandler.MarkOrderShipped(orderId);
            adminHandler.LoadUserData(UserRepeater);
        }

        // **Cancel Order**
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string orderId = btn.CommandArgument;

            adminHandler.CancelOrder(orderId);
            adminHandler.LoadUserData(UserRepeater);
        }
    }
}
