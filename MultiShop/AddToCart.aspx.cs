using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace MultiShop
{
    public partial class AddToCart : Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename=D:\asp.net\MultiShop\MultiShop\App_Data\multishop_db.mdf;" +
                                    @"Integrated Security=True;" +
                                    @"Connect Timeout=30";

        SqlConnection con;
        SqlCommand cmd;
        string pname;
        string pprice;
        String sp;
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


            string sessionuser = Session["Username"]?.ToString();

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

                       
                        if (!reader.IsDBNull(reader.GetOrdinal("Product_image")))
                        {
                            byte[] imageData = (byte[])reader["Product_image"];
                            base64Image = Convert.ToBase64String(imageData);
                        }
                    }
                    reader.Close();
                }

                sp = pprice + 60;

                string insertQuery = "INSERT INTO Cart_tbl (C_Product_name, C_Price, C_Del_Price, C_Product_image, C_Quantity, C_Total, C_ship_total) VALUES (@pn, @pp, @pdp, @pi, @q, @t, @st)";
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@pn", pname);
                cmd.Parameters.AddWithValue("@pp", pprice);
                cmd.Parameters.AddWithValue("@pdp", delprice);

               
                byte[] img = Convert.FromBase64String(base64Image);

                cmd.Parameters.AddWithValue("@pi", img);
                cmd.Parameters.AddWithValue("@q", '1');
                cmd.Parameters.AddWithValue("@t", pprice);
                cmd.Parameters.AddWithValue("@st", sp);
                cmd.ExecuteNonQuery();



                /*// Parsing successful, proceed with insertion into order_tbl
                string insertOrderQuery = "INSERT INTO order_tbl (P_Image, P_Name, P_Price, User_Id) VALUES ( @im, @na, @pr, @id)";
                cmd = new SqlCommand(insertOrderQuery, con);
                cmd.Parameters.AddWithValue("@id", '1');
                cmd.Parameters.AddWithValue("@im", img);
                cmd.Parameters.AddWithValue("@na", pname);
                cmd.Parameters.AddWithValue("@pr", pprice);
                cmd.ExecuteNonQuery();*/







                con.Close();
            }


            string remove = Request.QueryString["remove"];
            if (remove != null)
            {
                con.Open();
                string query = "SELECT * FROM Wishlist_tbl WHERE W_Id = @remove";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@remove", remove);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pname = reader["W_Product_Name"].ToString();
                        pprice = reader["W_Price"].ToString();
                        delprice = reader["W_Del_Price"].ToString();

                       
                        if (!reader.IsDBNull(reader.GetOrdinal("W_Product_image")))
                        {
                            byte[] imageData1 = (byte[])reader["W_Product_image"];
                            base64Image1 = Convert.ToBase64String(imageData1);
                        }
                    }
                    reader.Close();
                }

                string insertQuery = "INSERT INTO Cart_tbl (C_Product_name, C_Price, C_Del_Price, C_Product_image, C_Quantity, C_Total) VALUES (@pn, @pp, @pdp, @pi, @q, @t)";
                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@pn", pname);
                cmd.Parameters.AddWithValue("@pp", pprice);
                cmd.Parameters.AddWithValue("@pdp", delprice);

                
                byte[] img1 = Convert.FromBase64String(base64Image1);

                cmd.Parameters.AddWithValue("@pi", img1);
                cmd.Parameters.AddWithValue("@q", '1');
                cmd.Parameters.AddWithValue("@t", pprice);
                cmd.ExecuteNonQuery();
                con.Close();
            }




            if (!Page.IsPostBack)
            {
                string delId = Request.QueryString["delId"];

                if (!string.IsNullOrEmpty(delId))
                {
                    string query = "DELETE FROM Cart_tbl WHERE C_Id = @delId";

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
                con.Open();
                string query = "SELECT C_Id, C_Product_image, C_Product_name, C_Price, C_Del_Price FROM Cart_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                addcart.DataSource = reader;
                addcart.DataBind();
            }
        }
    }
}
