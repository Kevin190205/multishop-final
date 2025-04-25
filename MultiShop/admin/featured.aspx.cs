using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MultiShop.admin;

namespace MultiShop.admin
{
    public partial class Product : System.Web.UI.Page
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
                LoadProductData();
            }
        }

        private void LoadProductData()
        {
            adminClass.LoadProducts(UserRepeater); // Use AdminClass to load products
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = TextBox1.Text;
                string price = TextBox2.Text;
                string delPrice = TextBox3.Text;

                string result = adminClass.AddProduct(FileUpload1, productName, price, delPrice); // Call AddProduct from AdminClass
                Literal1.Text = result;

                LoadProductData(); // Reload products after adding
            }
            catch (Exception ex)
            {
                Literal1.Text = "Error: " + ex.Message;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;

            adminClass.DeleteProduct(delId); // Call DeleteProduct from AdminClass
            LoadProductData(); // Reload products after deletion
        }
    }
}
