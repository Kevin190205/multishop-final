using System;
using System.Collections.Generic;
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
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename=D:\asp.net\MultiShop\MultiShop\App_Data\multishop_db.mdf;" +
                                    @"Integrated Security=True;" +
                                    @"Connect Timeout=30";

        SqlConnection con;
        SqlCommand cmd;

        void getcon()
        {
            con = new SqlConnection(connectionString);
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
            con.Open();
            string query = "SELECT COUNT(*) FROM Cart_tbl";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                count = (int)cmd.ExecuteScalar();
            }
            con.Close();
            return count;
        }

        private int GetWishlistItemCount()
        {
            int count = 0;
            con.Open();
            string query = "SELECT COUNT(*) FROM Wishlist_tbl";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                count = (int)cmd.ExecuteScalar();
            }
            con.Close();
            return count;
        }
    }
}