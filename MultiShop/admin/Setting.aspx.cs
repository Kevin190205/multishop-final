using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultiShop.admin;

namespace MultiShop.admin
{
    public partial class Setting : System.Web.UI.Page
    {
        AdminClass adminClass = new AdminClass(); // Create an instance of AdminClass

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminLoggedIn"] == null || !(bool)Session["AdminLoggedIn"])
            {
                Response.Redirect("Admin_Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadSettingsData();
                LoadNewsletterData();
            }
        }

        private void LoadSettingsData()
        {
            // Load settings data using AdminClass
            adminClass.LoadSettings(ref TextBox1, ref TextBox2, ref TextBox3, ref TextBox4, ref TextBox5, ref TextBox6, ref TextBox7);
        }

        private void LoadNewsletterData()
        {
            // Load newsletter data using AdminClass
            adminClass.LoadNewsletter(ref TextBox8, UserRepeater);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // Update site title and information
            adminClass.UpdateSettings1(TextBox1.Text, TextBox3.Text, TextBox2.Text);
            LoadSettingsData(); // Reload settings after update
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            // Update location, email, contact, and customer service
            adminClass.UpdateSettings2(TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text);
            LoadSettingsData(); // Reload settings after update
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            // Update newsletter
            adminClass.UpdateNewsletter(TextBox8.Text);
            LoadNewsletterData(); // Reload newsletter after update
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // Delete newsletter entry
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;
            adminClass.DeleteNewsletter(Convert.ToInt32(delId)); // Delete using AdminClass
            LoadNewsletterData(); // Reload newsletter data after deletion
        }
    }
}
