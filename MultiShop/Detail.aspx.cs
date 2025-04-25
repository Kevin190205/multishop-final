using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace MultiShop
{
    public partial class Detail : Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayProductDetails();
            }
        }

        private void DisplayProductDetails()
        {
            if (!int.TryParse(Request.QueryString["pid"], out int productId))
            {
                // Handle invalid product ID
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string query = "SELECT * FROM product_tbl WHERE Id = @ProductId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["Product_image"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])reader["Product_image"];
                                string base64Image = Convert.ToBase64String(imageData);
                                string imageUrl = "data:image/png;base64," + base64Image;

                                // Binding Image to Image Control (If using Image control)
                                ProductImage.ImageUrl = imageUrl;
                                N1.Text = reader["Product_n1"].ToString();
                                Name.Text = reader["Product_Detail"].ToString();
                                Price.Text = "₹" + reader["Price"].ToString();
                                Dlprice.Text = "₹" + reader["Del_Price"].ToString();


                            }
                            else
                            {
                                ProductImage.ImageUrl = "~/image/default.png"; // Placeholder image
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
        protected void addToCart_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                int productId = Convert.ToInt32(Request.QueryString["pid"]);
                // Add the product to cart logic here
                Response.Redirect("cart.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
