using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class AddToWishlist : System.Web.UI.Page
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
                    userClass.AddToWishlist(productId, sessionUser);
                }

                string remove = Request.QueryString["remove"];
                if (remove != null)
                {
                    userClass.MoveToWishlistFromCart(remove, sessionUser);
                }

                string delId = Request.QueryString["delId"];
                if (!string.IsNullOrEmpty(delId))
                {
                    userClass.RemoveFromWishlist(delId);
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
                addwishlist.DataSource = userClass.GetWishlistData(sessionUser);
                addwishlist.DataBind();
            }
        }

    }
}