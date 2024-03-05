using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class checkout : System.Web.UI.Page
    {
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
            LoadUserData();
            LoadUserData1();
            LoadUserData2();
        }

        private void LoadUserData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT C_Product_name, C_Price, C_Total FROM Cart_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Repeater1.DataSource = reader;
                Repeater1.DataBind();

            }
        }

        private void LoadUserData1()
        {
            con.Open();
            string query = "SELECT SUM(CAST(C_Total AS decimal)) AS TotalSum FROM Cart_tbl";
            SqlCommand cmd = new SqlCommand(query, con);

            object result = cmd.ExecuteScalar();
            decimal totalSum = result != DBNull.Value ? (decimal)result : 0; // Check for DBNull

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TotalSum", typeof(decimal));
            dataTable.Rows.Add(totalSum);

            Repeater2.DataSource = dataTable;
            Repeater2.DataBind();

            con.Close();
        }

        private string LoadUserData2()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT SUM(CAST(C_Total AS decimal)) AS total FROM Cart_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    decimal total = (decimal)result;
                    total += 60; // Adding shipping cost
                    lblTotalWithShipping.Text = total.ToString();
                    return total.ToString();
                }
                else
                {
                    lblTotalWithShipping.Text = "0"; // or any other appropriate handling
                    return "0";
                }
            }
        }

        protected void placeorder_Click(object sender, EventArgs e)
        {
            string sessionuser = Session["Username"]?.ToString();
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string ship = LoadUserData2();
                string firstName = this.f.Text;
                string lastName = this.l.Text;
                string email = this.e.Text;
                string mobile = this.m.Text;
                string address1 = this.a1.Text;
                string address2 = this.a2.Text;
                string country = this.dd.Text;
                string city = this.c.Text;
                string state = this.s.Text;
                string pincode = this.p.Text;



                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                        string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(address1) || string.IsNullOrEmpty(country)
                        || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(pincode))
                {
                    Literal1.Text = "<p style='color: red;'>Please fill in all the required fields.</p>";
                    Literal1.Visible = true;
                    return;
                }
                else
                {
                    string paymentMethod = paymentMethodRadio.SelectedValue;
                    if (paymentMethod == "Cash_On_Delivery")
                    {
                        con.Open();
                        string insertQuery = "INSERT INTO buy_product_tbl (Firstname, Lastname, Email, Mobile_no, Address_1, Address_2, Country, City, State, Pincode ,Status, Amount, Date_Time, [User], OrderId, PaymentId) " +
                                             "VALUES (@fi, @la, @em, @mo, @ad1, @ad2, @co, @ci, @st, @pi, @status, @Amount, @dt, @Userme, @orderid, @paymentid)";

                        cmd = new SqlCommand(insertQuery, con);
                        cmd.Parameters.AddWithValue("@fi", firstName);
                        cmd.Parameters.AddWithValue("@la", lastName);
                        cmd.Parameters.AddWithValue("@em", email);
                        cmd.Parameters.AddWithValue("@mo", mobile);
                        cmd.Parameters.AddWithValue("@ad1", address1);
                        cmd.Parameters.AddWithValue("@ad2", address2);
                        cmd.Parameters.AddWithValue("@co", country);
                        cmd.Parameters.AddWithValue("@ci", city);
                        cmd.Parameters.AddWithValue("@st", state);
                        cmd.Parameters.AddWithValue("@pi", pincode);
                        cmd.Parameters.AddWithValue("@status", "Pending");
                        cmd.Parameters.AddWithValue("@Amount", ship);
                        cmd.Parameters.AddWithValue("@dt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Userme", sessionuser);
                        cmd.Parameters.AddWithValue("@orderid", "COD_ORDER");
                        cmd.Parameters.AddWithValue("@paymentid", "COD_PAYMENT");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("myorder.aspx");
                    }
                    else if (paymentMethod == "Online Payment")
                    {
                        Response.Redirect($"OnlinePaymentPage.aspx?fn={HttpUtility.UrlEncode(firstName)}" +
                $"&ln={HttpUtility.UrlEncode(lastName)}&em={HttpUtility.UrlEncode(email)}" +
                $"&mo={HttpUtility.UrlEncode(mobile)}&ad1={HttpUtility.UrlEncode(address1)}" +
                $"&ad2={HttpUtility.UrlEncode(address2)}&co={HttpUtility.UrlEncode(country)}" +
                $"&ci={HttpUtility.UrlEncode(city)}&st={HttpUtility.UrlEncode(state)}" +
                $"&pn={HttpUtility.UrlEncode(pincode)}&ship={HttpUtility.UrlEncode(ship)}");
                    }
                    else
                    {
                        Literal1.Text = "<p style='color: red;'>Invalid payment method selected.</p>";
                        Literal1.Visible = true;
                    }
                }
            }
        }
    }
}