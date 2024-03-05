using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class Profile : System.Web.UI.Page
    {
        public TextBox oldPassword;
        public TextBox newPassword;
        public TextBox confirmPassword;
        protected Button changePasswordButton;


        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                  @"AttachDbFilename=D:\asp.net\MultiShop\MultiShop\App_Data\multishop_db.mdf;" +
                                  @"Integrated Security=True;" +
                                  @"Connect Timeout=30";

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
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
            // Retrieve current user's data from the database based on their username
            string userName = Session["UserName"] as string;
            if (!string.IsNullOrEmpty(userName))
            {
                con.Open();
                string query = "SELECT * FROM user_register_tbl WHERE username = @UserName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        firstName.Text = reader["firstname"].ToString();
                        Label1.Text = firstName.Text;
                        lastName.Text = reader["lastname"].ToString();
                        email.Text = reader["email"].ToString();
                        address.Text = reader["address"].ToString();
                        contactNo.Text = reader["contact"].ToString();
                        city.Text = reader["city"].ToString();
                        state.Text = reader["state"].ToString();
                        username.Text = reader["username"].ToString();

                        byte[] imageData = reader["ImageData"] as byte[];
                        if (imageData != null)
                        {
                            string base64Image = Convert.ToBase64String(imageData);
                            Image1.ImageUrl = "data:image/jpeg;base64," + base64Image;
                        }
                    }
                    reader.Close();
                }

            }
        }



        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (fileUploadControl.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(fileUploadControl.FileName);
                    string filePath = Server.MapPath("~/image/user/") + fileName;
                    fileUploadControl.SaveAs(filePath);
                    Image1.ImageUrl = "~/image/user/" + fileName;
                    string extension = Path.GetExtension(fileName);
                    byte[] imageData;
                    using (Stream stream = fileUploadControl.FileContent)
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            imageData = reader.ReadBytes((int)stream.Length);
                        }
                    }
                    string userName1 = Session["UserName"] as string;
                    if (!string.IsNullOrEmpty(userName1))
                    {
                        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                                  @"AttachDbFilename=D:\asp.net\MultiShop\MultiShop\App_Data\multishop_db.mdf;" +
                                                  @"Integrated Security=True;" +
                                                  @"Connect Timeout=30";
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();
                            string query1 = "UPDATE user_register_tbl SET ImageData = @ImageData WHERE UserName = @UserName";
                            using (SqlCommand cmd = new SqlCommand(query1, con))
                            {
                                cmd.Parameters.AddWithValue("@ImageData", imageData);
                                cmd.Parameters.AddWithValue("@UserName", userName1);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    Literal1.Text = "Image uploaded and saved successfully!";
                                }
                                else
                                {
                                    Literal1.Text = "Error: Image not saved. Please try again.";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    Literal1.Text = "Error uploading image: " + ex.Message;
                }
            }
            else
            {
                Literal1.Text = "Please select a file to upload.";
            }



            string userName = Session["UserName"] as string;
            if (!string.IsNullOrEmpty(userName))
            {

                con.Open();
                string query = "Update user_register_tbl Set firstName=@firstName, lastName=@lastName, email=@email, address=@address, contact=@contact, city=@city, state=@state where username = @UserName";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@firstName", firstName.Text);
                cmd.Parameters.AddWithValue("@lastName", lastName.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.Parameters.AddWithValue("@contact", contactNo.Text);
                cmd.Parameters.AddWithValue("@city", city.Text);
                cmd.Parameters.AddWithValue("@state", state.Text);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                messageLiteral.Text = "<p style='color: green;'>Update Profile successful!</p>";
                messageLiteral.Visible = true;
            }

        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"] as string;
            string old = oldPassword.Text;
            string newpass = newPassword.Text;
            string confirm = confirmPassword.Text;

            if (!string.IsNullOrEmpty(userName))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT password FROM [user_register_tbl] WHERE userName = @UserName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        string storedPassword = cmd.ExecuteScalar() as string;
                        if (!string.IsNullOrEmpty(storedPassword))
                        {
                            if (storedPassword == old)
                            {
                                if (newpass == confirm)
                                {
                                    string updateQuery = "UPDATE [user_register_tbl] SET password = @NewPassword WHERE UserName = @UserName";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@NewPassword", newpass);
                                        updateCmd.Parameters.AddWithValue("@UserName", userName);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    messageLiteral2.Text = "<p style='color: green;'>Password updated successfully!</p>";
                                }
                                else
                                {
                                    messageLiteral2.Text = "<p style='color: red;'>New password and confirm password do not match.</p>";
                                }
                            }
                            else
                            {
                                messageLiteral2.Text = "<p style='color: red;'>Incorrect old password!</p>";
                            }
                        }
                        else
                        {
                            messageLiteral2.Text = "<p style='color: red;'>User not found or password not set!</p>";
                        }
                    }
                }
            }
        }
    }
}