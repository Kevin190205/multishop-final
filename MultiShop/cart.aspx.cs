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
    public partial class cart : System.Web.UI.Page
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
        string incre;
        string tprice;
        

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
            if (!IsPostBack)
            {
                string delId = Request.QueryString["delId"];
                
                if (!string.IsNullOrEmpty(delId))
                {
                    string query = "DELETE FROM Cart_tbl WHERE C_Id = @delId";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@delId", delId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                string sub = Request.QueryString["sub"];

                if (!string.IsNullOrEmpty(sub))
                {
                    string query21 = "SELECT C_Quantity ,C_Price ,C_Total, C_ship_total FROM Cart_tbl WHERE C_Id = @sub";
                    using (SqlConnection con1 = new SqlConnection(connectionString))
                    {
                        con1.Open();
                        using (SqlCommand cmd = new SqlCommand(query21, con1))
                        {
                            cmd.Parameters.AddWithValue("@sub", sub);
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                int decre = 0;
                                decimal tprice = 0;
                                decimal pri = 0;
                                decimal st = 0;
                                

                                // Check if the fields are DBNull before conversion
                                if (!reader.IsDBNull(reader.GetOrdinal("C_Quantity")))
                                    decre = Convert.ToInt32(reader["C_Quantity"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("C_Price")))
                                    tprice = Convert.ToDecimal(reader["C_Price"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("C_Total")))
                                    pri = Convert.ToDecimal(reader["C_Total"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("C_ship_total")))
                                    st = Convert.ToDecimal(reader["C_ship_total"]);

                                // Increment quantity, double price, and update total price
                                if (decre > 1)
                                {
                                    decre--;
                                    pri -= tprice;
                                    st = pri + 60;
                                    

                                    reader.Close();
                                    // Update Cart_tbl with new quantity and total price
                                    string query22 = "UPDATE Cart_tbl SET C_Quantity = @quantity, C_Total = @total, C_ship_total = @ship WHERE C_Id = @sub";
                                    using (SqlCommand cmd2 = new SqlCommand(query22, con1))
                                    {
                                        cmd2.Parameters.AddWithValue("@quantity", decre);
                                        cmd2.Parameters.AddWithValue("@total", pri);
                                        cmd2.Parameters.AddWithValue("@ship", st);
                                        cmd2.Parameters.AddWithValue("@sub", sub);

                                        cmd2.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                // Handle case where the item with the specified ID is not found
                                // For example, redirect to an error page or display an error message
                            }

                        }
                    }                   
                }

                string add = Request.QueryString["add"];

                if (!string.IsNullOrEmpty(add))
                {
                    string query21 = "SELECT C_Quantity ,C_Price ,C_Total ,C_ship_total FROM Cart_tbl WHERE C_Id = @add";
                    using (SqlConnection con1 = new SqlConnection(connectionString))
                    {
                        con1.Open();
                        using (SqlCommand cmd = new SqlCommand(query21, con1))
                        {
                            cmd.Parameters.AddWithValue("@add", add);
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                int incre = 0;
                                decimal tprice = 0;
                                decimal pri = 0;
                                decimal st = 0;

                                // Check if the fields are DBNull before conversion
                                if (!reader.IsDBNull(reader.GetOrdinal("C_Quantity")))
                                    incre = Convert.ToInt32(reader["C_Quantity"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("C_Price")))
                                    tprice = Convert.ToDecimal(reader["C_Price"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("C_Total")))
                                    pri = Convert.ToDecimal(reader["C_Total"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("C_ship_total")))
                                    st = Convert.ToDecimal(reader["C_ship_total"]);

                                // Increment quantity, double price, and update total price
                                incre++;
                                pri += tprice;
                                st = pri + 60;

                                reader.Close();

                                // Update Cart_tbl with new quantity and total price
                                string query22 = "UPDATE Cart_tbl SET C_Quantity = @quantity, C_Total = @total, C_ship_total = @ship1 WHERE C_Id = @add";
                                using (SqlCommand cmd2 = new SqlCommand(query22, con1))
                                {
                                    cmd2.Parameters.AddWithValue("@quantity", incre);
                                    cmd2.Parameters.AddWithValue("@total", pri);
                                    cmd2.Parameters.AddWithValue("@ship1", st);
                                    cmd2.Parameters.AddWithValue("@add", add);

                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Handle case where the item with the specified ID is not found
                                // For example, redirect to an error page or display an error message
                            }

                        }
                    }
                }
            }
        }
        private void LoadUserData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT C_Id, C_Product_image, C_Product_name, C_Price, C_Del_Price ,C_Quantity , C_Total FROM Cart_tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                cart_p.DataSource = reader;
                cart_p.DataBind();

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

            Repeater1.DataSource = dataTable;
            Repeater1.DataBind();

            con.Close();
        }


        private void LoadUserData2()
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
                }
                else
                {
                    // Handle the case where there are no records in Cart_tbl
                    lblTotalWithShipping.Text = "0"; // or any other appropriate handling
                }

                con.Close();
            }
        }


        protected void btnProceedToCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }
    }
}