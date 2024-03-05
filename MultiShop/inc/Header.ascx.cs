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
    public partial class Header : System.Web.UI.UserControl
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
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            con.Open();
            string query = "SELECT * FROM setting_tbl ";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Label1.Text = reader["Site_Title"].ToString();                    
                    Label2.Text = reader["Site_Title2"].ToString();
                    Label3.Text = reader["Customer_Service"].ToString();
                }
                reader.Close();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Men_Click(object sender, EventArgs e)
        {
            string searchQuery = "men";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Women_Click(object sender, EventArgs e)
        {
            string searchQuery = "women";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Baby_Click(object sender, EventArgs e)
        {
            string searchQuery = "baby";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Shirts_Click(object sender, EventArgs e)
        {
            string searchQuery = "shirt";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Jeans_Click(object sender, EventArgs e)
        {
            string searchQuery = "jeans";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Swimwear_Click(object sender, EventArgs e)
        {
            string searchQuery = "swimwear";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Sleepwear_Click(object sender, EventArgs e)
        {
            string searchQuery = "sleepwear";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Sportswear_Click(object sender, EventArgs e)
        {
            string searchQuery = "sportswear";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Jumpsuits_Click(object sender, EventArgs e)
        {
            string searchQuery = "Jumpsuits";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Blazers_Click(object sender, EventArgs e)
        {
            string searchQuery = "blazers";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void Jackets_Click(object sender, EventArgs e)
        {
            string searchQuery = "Jackets";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }

        protected void ShoesButton_Click(object sender, EventArgs e)
        {
            string searchQuery = "shoes";
            Response.Redirect("SearchProducts.aspx?search=" + searchQuery);
        }
    }
}