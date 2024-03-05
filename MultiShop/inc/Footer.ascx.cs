using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class Footer : System.Web.UI.UserControl
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
                LoadUserData1();
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
                    Label1.Text = reader["Imformation"].ToString();
                    Label2.Text = reader["Location"].ToString();
                    Label3.Text = reader["Email"].ToString();
                    Label4.Text = reader["Contact"].ToString();
                }
                reader.Close();
            }
            con.Close();
        }

        private void LoadUserData1()
        {
            con.Open();
            string query1 = "SELECT * FROM Newsletter_tbl ";
            using (SqlCommand cmd1 = new SqlCommand(query1, con))
            {
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    Label5.Text = reader1["Newsletter"].ToString();
                }
                reader1.Close();
            }
            con.Close();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            con.Open();

            string insertQuery = "INSERT INTO Newsletter_tbl (Email) " +
                                 "VALUES (@em)";

            cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@em", email);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}