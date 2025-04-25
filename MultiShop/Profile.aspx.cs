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

        private UserClass ucs = new UserClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            string userName = Session["UserName"] as string;
            if (!string.IsNullOrEmpty(userName))
            {
                DataTable dt = ucs.GetUserByUsername(userName);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    firstName.Text = row["firstname"].ToString();
                    Label1.Text = firstName.Text;
                    lastName.Text = row["lastname"].ToString();
                    email.Text = row["email"].ToString();
                    address.Text = row["address"].ToString();
                    contactNo.Text = row["contact"].ToString();
                    city.Text = row["city"].ToString();
                    state.Text = row["state"].ToString();
                    username.Text = row["username"].ToString();

                    if (row["ImageData"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])row["ImageData"];
                        string base64Image = Convert.ToBase64String(imageData);
                        Image1.ImageUrl = "data:image/jpeg;base64," + base64Image;
                    }
                }
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"] as string;
            if (!string.IsNullOrEmpty(userName))
            {
                byte[] imageData = null;

                if (fileUploadControl.HasFile)
                {
                    using (Stream stream = fileUploadControl.FileContent)
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        imageData = reader.ReadBytes((int)stream.Length);
                    }
                }

                bool isUpdated = ucs.UpdateUserProfile(userName, firstName.Text, lastName.Text, email.Text, address.Text, contactNo.Text, city.Text, state.Text, imageData);

                if (isUpdated)
                {
                    messageLiteral.Text = "<p style='color: green;'>Profile updated successfully!</p>";
                }
                else
                {
                    messageLiteral.Text = "<p style='color: red;'>Error updating profile.</p>";
                }
            }
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            string userName = Session["UserName"] as string;
            if (!string.IsNullOrEmpty(userName))
            {
                string oldPassHash = oldPassword.Text;
                string newPassHash = newPassword.Text;
                string confirmPassHash = confirmPassword.Text;

                if (newPassHash == confirmPassHash)
                {
                    bool isPasswordChanged = ucs.ChangePassword(userName, oldPassHash, newPassHash);

                    if (isPasswordChanged)
                    {
                        messageLiteral2.Text = "<p style='color: green;'>Password updated successfully!</p>";
                    }
                    else
                    {
                        messageLiteral2.Text = "<p style='color: red;'>Incorrect old password!</p>";
                    }
                }
                else
                {
                    messageLiteral2.Text = "<p style='color: red;'>New password and confirm password do not match.</p>";
                }
            }
        }
    }
}