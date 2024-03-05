using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class SearchProducts : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["search"]))
                {
                    string searchQuery = Request.QueryString["search"];
                    LoadUserData(searchQuery);
                }
            }
        }
        protected void LoadUserData(string searchQuery)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); // Add wildcard characters for partial match
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    ProductRepeater.DataSource = reader;
                    ProductRepeater.DataBind();
                    NoProductsMessage.Visible = false;
                }
                else
                {
                    ProductRepeater.Visible = false;
                    NoProductsMessage.Visible = true;
                    NoProductsMessage.Text = "<h3> No products found. </h3>";
                }
            }
        }

    }

}