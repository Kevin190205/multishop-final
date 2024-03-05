using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class Registration : System.Web.UI.Page
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
        protected void registerbutton_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string fileName = Path.GetFileName(FileUpload1.FileName);
                string filePath = Server.MapPath("~/image/user/") + fileName;
                FileUpload1.SaveAs(filePath);
                string extension = Path.GetExtension(fileName);
                byte[] imageData;
                using (Stream stream = FileUpload1.FileContent)
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        imageData = reader.ReadBytes((int)stream.Length);
                    }
                }


                string firstName = this.firstName.Text;
                string lastName = this.lastName.Text;
                string email = this.email.Text;
                string username = this.username.Text;
                string password = this.password.Text;
                string confirmPassword = this.confirmPassword.Text;


                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    messageLiteral.Text = "<p style='color: red;'>Please fill in all the required fields.</p>";
                    messageLiteral.Visible = true;
                    return;
                }
                if (password != confirmPassword)
                {
                    messageLiteral.Text = "<p style='color: red;'>Passwords do not match.</p>";
                    messageLiteral.Visible = true;
                    return;
                }
                con.Open();

                string insertQuery = "INSERT INTO user_register_tbl (firstname, lastname, email, username, password, ImageData, Status) " +
                                     "VALUES (@FirstName, @LastName, @Email, @Username, @Password, @ImageData, @Status)";

                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@ImageData", imageData);
                cmd.Parameters.AddWithValue("@Status", "Active");
                cmd.ExecuteNonQuery();
                con.Close();

                messageLiteral.Text = "<p style='color: green;'>Registration successful!</p>";
                messageLiteral.Visible = true;
            }
            else
            {
                messageLiteral.Text = "Please select a file to upload.";
            }
        }
    }
}