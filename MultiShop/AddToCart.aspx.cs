using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace MultiShop
{
    public partial class AddToCart : Page
    {
       

        UserClass userClass = new UserClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionUser = Session["Username"]?.ToString();

            if (sessionUser == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string productId = Request.QueryString["productId"];
                if (productId != null)
                {
                    userClass.AddToCart(productId, sessionUser);
                }

                string delId = Request.QueryString["delId"];
                if (!string.IsNullOrEmpty(delId))
                {
                    userClass.RemoveFromCart(delId);
                }

                if (!IsPostBack)
                {
                    LoadUserData();
                }
            }
        }

        private void LoadUserData()
        {
            string sessionUser = Session["Username"]?.ToString();
            if (sessionUser != null)
            {
                addcart.DataSource = userClass.GetCartData(sessionUser);
                addcart.DataBind();
            }
        }

    }
}
