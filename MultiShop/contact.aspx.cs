using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class contact : System.Web.UI.Page
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
        }

        protected void sendMessageButton_Click(object sender, EventArgs e)
        {
            string name = this.name.Text;
            string email = this.email.Text;
            string subject = this.subject.Text;
            string message = this.message.Text;

            con.Open();

            string insertQuery = "INSERT INTO user_query_tbl (Name, Email, Subject, Message) " +
                                 "VALUES (@n, @e, @s, @m)";

            cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@s", subject);
            cmd.Parameters.AddWithValue("@m", message);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}