using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop.admin
{
    public partial class Setting : System.Web.UI.Page
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
            if (Session["AdminLoggedIn"] == null || !(bool)Session["AdminLoggedIn"])
            {
                Response.Redirect("Admin_Login.aspx");
            }

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
                    TextBox1.Text = reader["Site_Title"].ToString();
                    Label8.Text = TextBox1.Text;
                    TextBox3.Text = reader["Site_Title2"].ToString();
                    Label9.Text = TextBox3.Text;
                    TextBox2.Text = reader["Imformation"].ToString();
                    Label10.Text = TextBox2.Text;
                    TextBox4.Text = reader["Location"].ToString();
                    Label11.Text = TextBox4.Text;
                    TextBox5.Text = reader["Email"].ToString();
                    Label12.Text = TextBox5.Text;
                    TextBox6.Text = reader["Contact"].ToString();
                    Label13.Text = TextBox6.Text;
                    TextBox7.Text = reader["Customer_Service"].ToString();
                    Label14.Text = TextBox7.Text;
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
                    
                    TextBox8.Text = reader1["Newsletter"].ToString();
                    Label15.Text = TextBox8.Text;
                    UserRepeater.DataSource = reader1;
                    UserRepeater.DataBind();
                }
                reader1.Close();
            }
            con.Close();
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Update setting_tbl Set Site_Title=@s1, Site_Title2=@s2, Imformation=@info WHERE Id = @settingid ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@s1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@s2", TextBox3.Text);
            cmd.Parameters.AddWithValue("@info", TextBox2.Text);
            cmd.Parameters.AddWithValue("@settingid", '1');
            cmd.ExecuteNonQuery();
            con.Close();
            LoadUserData();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Update setting_tbl Set Location=@l, Email=@e, Contact=@c, Customer_Service=@cs WHERE Id = @settingid ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@l", TextBox4.Text);
            cmd.Parameters.AddWithValue("@e", TextBox5.Text);
            cmd.Parameters.AddWithValue("@c", TextBox6.Text);
            cmd.Parameters.AddWithValue("@cs", TextBox7.Text);
            cmd.Parameters.AddWithValue("@settingid", '1');
            cmd.ExecuteNonQuery();
            con.Close();
            LoadUserData();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Update Newsletter_tbl Set Newsletter=@New  WHERE Id = @settingid ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@New", TextBox8.Text);
            cmd.Parameters.AddWithValue("@settingid", '1');
            cmd.ExecuteNonQuery();
            con.Close();
            LoadUserData();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;

            string query = "DELETE FROM Newsletter_tbl WHERE Id = @delId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@delId", delId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadUserData1();
        }
    }
}