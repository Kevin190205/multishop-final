using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MultiShop
{
    public partial class Header : System.Web.UI.UserControl
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
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Men_Click(object sender, EventArgs e)
        {
            string searchQuery = "Men";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Women_Click(object sender, EventArgs e)
        {
            string searchQuery = "Women";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Baby_Click(object sender, EventArgs e)
        {
            string searchQuery = "Baby";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Shirts_Click(object sender, EventArgs e)
        {
            string searchQuery = "shirt";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Jeans_Click(object sender, EventArgs e)
        {
            string searchQuery = "Jeans";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Swimwear_Click(object sender, EventArgs e)
        {
            string searchQuery = "Swimwear";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Sleepwear_Click(object sender, EventArgs e)
        {
            string searchQuery = "Sleepwear";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Sportswear_Click(object sender, EventArgs e)
        {
            string searchQuery = "Sportswear";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Jumpsuits_Click(object sender, EventArgs e)
        {
            string searchQuery = "Jumpsuits";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Blazers_Click(object sender, EventArgs e)
        {
            string searchQuery = "Blazers";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void Jackets_Click(object sender, EventArgs e)
        {
            string searchQuery = "Jackets";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }

        protected void ShoesButton_Click(object sender, EventArgs e)
        {
            string searchQuery = "Shoes";
            Response.Redirect("MultiShop.aspx?search=" + searchQuery);
        }
    }
}