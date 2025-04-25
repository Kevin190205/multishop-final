using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class GetBadgeCounts : System.Web.UI.Page
    {

        private string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection con;
        SqlCommand cmd;

        void getcon()
        {
            con = new SqlConnection(connString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
            int wishlistCount = GetWishlistItemCount();
            int cartCount = GetCartItemCount();

            var serializer = new JavaScriptSerializer();
            var response = new { wishlistCount = wishlistCount, cartCount = cartCount };
            string jsonResponse = serializer.Serialize(response);

            Response.ContentType = "application/json";
            Response.Write(jsonResponse);
            Response.End();
        }


        private int GetCartItemCount()
        {
            int count = 0;
            string sessionuser = Session["Username"]?.ToString();

            if (sessionuser != null)
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Cart_tbl WHERE C_User_Id=@sessionuser";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@sessionuser", sessionuser);
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            else 
            {
                //Response.Redirect("MultiShop.aspx");
            }

            return count;
        }


        private int GetWishlistItemCount()
        {
            int count = 0;
            string sessionuser = Session["Username"]?.ToString();

            if (sessionuser != null)
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Wishlist_tbl WHERE W_User_Id=@sessionuser";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@sessionuser", sessionuser);
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            else
            {
                //Response.Redirect("MultiShop.aspx");
            }

            return count;
        }

    }
}