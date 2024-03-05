using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop.admin.inc
{
    public partial class user : System.Web.UI.Page
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
            if (Session["AdminLoggedIn"] == null || !(bool)Session["AdminLoggedIn"])
            {
                Response.Redirect("Admin_Login.aspx");
            }

            getcon();
            if (!IsPostBack)
            {
                LoadUserData();
            }
        }
        private void LoadUserData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();          
                string query = "SELECT * FROM user_register_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                UserRepeater.DataSource = reader;
                UserRepeater.DataBind();
            }
        }

        protected void StatusButton_Command(object sender, CommandEventArgs e)
        {
            string userId = e.CommandArgument.ToString();
            string currentStatus = GetStatus(userId);
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";
            UpdateStatus(userId, newStatus);
            LoadUserData();
        }
        protected string GetStatus(string userId)
        {
            string status = "";
           
                string query = "SELECT Status FROM user_register_tbl WHERE Id = @UserId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                status = cmd.ExecuteScalar()?.ToString();
            con.Close();
            return status;
        }
        protected void UpdateStatus(string userId, string newStatus)
        {          
                string query = "UPDATE user_register_tbl SET Status = @NewStatus WHERE Id = @UserId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                cmd.ExecuteNonQuery();           
        }
        protected string GetButtonCssClass(object status)
        {
            string currentStatus = status.ToString();
            return (currentStatus == "Active") ? "Activate" : "Deactivate";
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;

            string query = "DELETE FROM user_register_tbl WHERE Id = @delId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@delId", delId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUserData();
        }
    }
}