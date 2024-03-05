using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                  @"AttachDbFilename=D:\asp.net\MultiShop\MultiShop\App_Data\multishop_db.mdf;" +
                                  @"Integrated Security=True;" +
                                  @"Connect Timeout=30";

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        string g;
        void getcon()
        {
            con = new SqlConnection(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string adminName = AdminNameTextBox.Text;
            string adminPass = AdminPassTextBox.Text;

            con.Open();
            string query = "SELECT * FROM admin_login_tbl WHERE Admin_name = @adminName AND Admin_password = @adminPass";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@adminName", adminName);
            cmd.Parameters.AddWithValue("@adminPass", adminPass);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Session["AdminLoggedIn"] = true;
                Response.Redirect("Buy_Product.aspx");
            }
            else
            {
                LoginAlert.Visible = true;
                LoginAlert.Text = "Invalid username or password. Please try again.";
            }

            reader.Close();
            con.Close();
        }
    }
}