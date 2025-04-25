using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop.admin
{
    public partial class Product1 : System.Web.UI.Page
    {
        

        AdminClass adminClass = new AdminClass(); // Instance of AdminClass

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminLoggedIn"] == null || !(bool)Session["AdminLoggedIn"])
            {
                Response.Redirect("Admin_Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadUserData();
            }
        }

        private void LoadUserData()
        {
            adminClass.Load_Products(UserRepeater);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string result = adminClass.Add_Product(FileUpload1, TextBox1.Text, TextBox2.Text, TextBox3.Text, Detail.Text , TextBox4.Text);
            Literal1.Text = result;
            LoadUserData();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;

            adminClass.Delete_Product(delId);
            LoadUserData();
        }

    }
}