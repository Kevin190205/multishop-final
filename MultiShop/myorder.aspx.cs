using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class detail : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                /*LoadUserData();
                LoadUserData1();*/
            }


            string sessionuser = Session["Username"]?.ToString();
            string oid = Request.QueryString["orderId"];
            string pid = Request.QueryString["paymentId"];
            string fname = Request.QueryString["name"];
            string lname = Request.QueryString["lastn"];
            string email = Request.QueryString["email"];
            string mo = Request.QueryString["contact"];
            string add1 = Request.QueryString["add1"];
            string add2 = Request.QueryString["add2"];
            string country = Request.QueryString["coun"];
            string state = Request.QueryString["stat"];
            string city = Request.QueryString["ci"];
            string pincode = Request.QueryString["pin"];
            string stotal = Request.QueryString["totalship"];

            if (sessionuser != null && oid != null && pid != null && fname != null && lname != null &&
                  email != null && mo != null && add1 != null && add2 != null && country != null &&
                  state != null && city != null && pincode != null && stotal != null)
            {
                con.Open();
                string insertQuery = "INSERT INTO buy_product_tbl (Firstname, Lastname, Email, Mobile_no, Address_1, Address_2, Country, City, State, Pincode ,Status, Amount, Date_Time, [User], OrderId, PaymentId) " +
                                     "VALUES (@fi, @lana, @em, @mo, @ad1, @ad2, @co, @ci, @st, @pi, @status, @Amount, @dt, @Userme, @orderid, @paymentid)";

                cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@fi", fname);
                cmd.Parameters.AddWithValue("@lana", pincode);
                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@mo", mo);
                cmd.Parameters.AddWithValue("@ad1", lname);
                cmd.Parameters.AddWithValue("@ad2", add1);
                cmd.Parameters.AddWithValue("@co", country);
                cmd.Parameters.AddWithValue("@ci", city);
                cmd.Parameters.AddWithValue("@st", state);
                cmd.Parameters.AddWithValue("@pi", add2);
                cmd.Parameters.AddWithValue("@status", "Paid");
                cmd.Parameters.AddWithValue("@Amount", stotal);
                cmd.Parameters.AddWithValue("@dt", DateTime.Now);
                cmd.Parameters.AddWithValue("@Userme", sessionuser);
                cmd.Parameters.AddWithValue("@orderid", oid);
                cmd.Parameters.AddWithValue("@paymentid", pid);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            
        }
        /*private void LoadUserData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Id, Product_image, Product_name, Price, Del_Price FROM product_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                ProductRepeater.DataSource = reader;
                ProductRepeater.DataBind();

            }
        }
        private void LoadUserData1()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Product_image, Product_name, Price, Del_Price FROM product_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                ProductImageRepeater.DataSource = reader;
                ProductImageRepeater.DataBind();
            }
        }*/
    }
}