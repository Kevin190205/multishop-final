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
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename=D:\asp.net\MultiShop\MultiShop\App_Data\multishop_db.mdf;" +
                                    @"Integrated Security=True;" +
                                    @"Connect Timeout=30";

        SqlConnection con;
        SqlCommand cmd;
        string pname;
        string pprice;
        string delprice;
        string base64Image;
        string base64Image1;

        void getcon()
        {
            con = new SqlConnection(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
            LoadUserData1();
            string productId = Request.QueryString["productId"];
            if (productId != null)
            {
                con.Open();
                string query = "SELECT * FROM product_tbl WHERE Id = @productId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pname = reader["Product_Name"].ToString();
                        pprice = reader["Price"].ToString();
                        delprice = reader["Del_Price"].ToString();

                        // Check if Product_image is null before converting to base64
                        if (!reader.IsDBNull(reader.GetOrdinal("Product_image")))
                        {
                            byte[] imageData = (byte[])reader["Product_image"];
                            base64Image = Convert.ToBase64String(imageData);
                        }
                    }
                    reader.Close();
                }

                string insertQuery = "INSERT INTO Wishlist_tbl (W_Product_name, W_Price, W_Del_Price, W_Product_image) VALUES (@pn, @pp, @pdp, @pi)";
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@pn", pname);
                cmd.Parameters.AddWithValue("@pp", pprice);
                cmd.Parameters.AddWithValue("@pdp", delprice);

                // Convert base64 string back to byte array
                byte[] img = Convert.FromBase64String(base64Image);

                cmd.Parameters.AddWithValue("@pi", img);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            string remove = Request.QueryString["remove"];
            if (remove != null)
            {
                con.Open();
                string query = "SELECT * FROM Cart_tbl WHERE C_Id = @remove";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@remove", remove);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pname = reader["C_Product_Name"].ToString();
                        pprice = reader["C_Price"].ToString();
                        delprice = reader["C_Del_Price"].ToString();

                        // Check if Product_image is null before converting to base64
                        if (!reader.IsDBNull(reader.GetOrdinal("C_Product_image")))
                        {
                            byte[] imageData1 = (byte[])reader["C_Product_image"];
                            base64Image1 = Convert.ToBase64String(imageData1);
                        }
                    }
                    reader.Close();
                }

                string insertQuery = "INSERT INTO Wishlist_tbl (W_Product_name, W_Price, W_Del_Price, W_Product_image) VALUES (@pn, @pp, @pdp, @pi)";
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@pn", pname);
                cmd.Parameters.AddWithValue("@pp", pprice);
                cmd.Parameters.AddWithValue("@pdp", delprice);

                // Convert base64 string back to byte array
                byte[] img1 = Convert.FromBase64String(base64Image1);

                cmd.Parameters.AddWithValue("@pi", img1);
                cmd.ExecuteNonQuery();
                con.Close();
            }



            if (!Page.IsPostBack)
            {
                string delId = Request.QueryString["delId"];

                if (!string.IsNullOrEmpty(delId))
                {
                    string query = "DELETE FROM Wishlist_tbl WHERE W_Id = @delId";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@delId", delId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        private void LoadUserData1()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open(); // Open the connection before executing the query
                string query = "SELECT W_Id, W_Product_image, W_Product_name, W_Price, W_Del_Price FROM Wishlist_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    addwishlist.DataSource = reader;
                    addwishlist.DataBind();
                }
            }
        }
    }
}