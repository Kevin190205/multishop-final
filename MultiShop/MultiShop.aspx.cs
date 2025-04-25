using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class MultiShop : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                LoadUserData();
                LoadUserData2();
                if (!string.IsNullOrEmpty(Request.QueryString["search"]))
                {
                    string searchQuery = Request.QueryString["search"];
                    LoadUserData1(searchQuery);
                }
            }
        }

        protected void LoadUserData1(string searchQuery)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }
        private void LoadUserData()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT Id, Product_image, Product_n1, Price, Del_Price FROM product_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        private void LoadUserData2()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT Id, F_Product_image, F_Product_name, F_Price, F_Del_Price FROM F_product_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                featureRepeater.DataSource = reader;
                featureRepeater.DataBind();
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "shirt";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed2_Click1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Jeans";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Swimwear";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Sleepwear";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Sportswear";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Jumpsuit";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Blazers";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Jackets";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed9_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Shoes";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Men";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed11_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Women";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }

        protected void Unnamed12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string searchQuery = "Baby";
                string query = "SELECT * FROM product_tbl WHERE Product_name LIKE @searchQuery";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%"); 
                SqlDataReader reader = cmd.ExecuteReader();
                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();
            }
        }




        protected void ProductRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cmd_detail")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Detail.aspx?pid=" + id);
            }
        }
    }
}