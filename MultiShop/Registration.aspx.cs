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
        private UserClass ucs = new UserClass();

        protected void registerbutton_Click(object sender, ImageClickEventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                messageLiteral.Text = "<p style='color: red;'>Please select a file to upload.</p>";
                messageLiteral.Visible = true;
                return;
            }

            string fileName = Path.GetFileName(FileUpload1.FileName);
            string filePath = Server.MapPath("~/image/user/") + fileName;
            FileUpload1.SaveAs(filePath);
            byte[] imageData;

            using (Stream stream = FileUpload1.FileContent)
            using (BinaryReader reader = new BinaryReader(stream))
            {
                imageData = reader.ReadBytes((int)stream.Length);
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

            bool isRegistered = ucs.RegisterUser(firstName, lastName, email, username, password, imageData);
            if (isRegistered)
            {
                messageLiteral.Text = "<p style='color: green;'>Registration successful!</p>";
                messageLiteral.Visible = true;
            }
            else
            {
                messageLiteral.Text = "<p style='color: red;'>Registration failed. Please try again.</p>";
                messageLiteral.Visible = true;
            }
        }
    }
}