using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class Login : System.Web.UI.Page
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

        protected void login_button_Click(object sender, ImageClickEventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            con.Open();
            string query = "SELECT Username, Password, Status FROM user_register_tbl WHERE Username = @Username";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", enteredUsername);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string storedPassword = reader["Password"].ToString();
                    string status = reader["Status"].ToString();

                    if (enteredPassword == storedPassword)
                    {
                        if (status == "Active")
                        {
                            Session["UserName"] = enteredUsername;
                            Response.Redirect("MultiShop.aspx");
                        }
                        else
                        {
                            messageLiteral.Text = "<p style='color: red;'>Your account is currently inactive. Please contact support.</p>";
                            messageLiteral.Visible = true;
                        }
                    }
                    else
                    {
                        messageLiteral.Text = "<p style='color: red;'>Invalid username or password.</p>";
                        messageLiteral.Visible = true;
                    }
                }
                else
                {
                    messageLiteral.Text = "<p style='color: red;'>Invalid username or password.</p>";
                    messageLiteral.Visible = true;
                }
            }

            con.Close();
        }

    }
}