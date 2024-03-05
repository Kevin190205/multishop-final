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
    public partial class Product : System.Web.UI.Page
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
                string query = "SELECT * FROM F_product_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                UserRepeater.DataSource = reader;
                UserRepeater.DataBind();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string filePath = Server.MapPath("~/image/feature product/") + fileName;
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

                string productName = TextBox1.Text;
                string price = TextBox2.Text;
                string delPrice = TextBox3.Text;

                con.Open();
                string query = "INSERT INTO F_product_tbl (F_Product_image, F_Product_name, F_Price, F_Del_Price) " +
                               "VALUES (@Product_image, @Product_name, @Price, @Del_Price)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Product_image", imageData);
                cmd.Parameters.AddWithValue("@Product_name", productName);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Del_Price", delPrice);
                cmd.ExecuteNonQuery();
                con.Close();
                LoadUserData();


            }
            catch (Exception ex)
            {
                // Handle exceptions
                Literal1.Text = "Error: " + ex.Message;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string delId = btn.CommandArgument;

            string query = "DELETE FROM F_product_tbl WHERE Id = @delId";

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