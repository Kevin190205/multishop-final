using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace MultiShop.admin
{
    public class AdminClass
    {
        private string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // ********** ADMIN AUTHENTICATION **********

        private bool ValidateAdmin(string adminName, string adminPass)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT COUNT(*) FROM admin_login_tbl WHERE Admin_name = @adminName AND Admin_password = @adminPass";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@adminName", adminName);
                    cmd.Parameters.AddWithValue("@adminPass", adminPass);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public string AuthenticateAdmin(string adminName, string adminPass, HttpSessionState session)
        {
            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPass))
            {
                return "Username and Password cannot be empty!";
            }

            bool isValid = ValidateAdmin(adminName, adminPass);

            if (isValid)
            {
                session["AdminLoggedIn"] = true;
                return "success";
            }
            else
            {
                return "Invalid username or password. Please try again.";
            }
        }

        // ********** BOOKING PAGE FUNCTIONALITIES **********

        public void LoadUserData(Repeater userRepeater)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT * FROM buy_product_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    userRepeater.DataSource = reader;
                    userRepeater.DataBind();
                }
            }
        }

        public void DeleteOrder(string orderId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "DELETE FROM buy_product_tbl WHERE Id = @orderId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MarkOrderShipped(string orderId)
        {
            UpdateOrderStatus(orderId, "shipped");
        }

        public void CancelOrder(string orderId)
        {
            UpdateOrderStatus(orderId, "Cancel Order");
        }

        private void UpdateOrderStatus(string orderId, string newStatus)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE buy_product_tbl SET order_status = @newStatus WHERE Id = @orderId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@newStatus", newStatus);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ********** PRODUCT MANAGEMENT FUNCTIONALITIES **********

        public void LoadProducts(Repeater productRepeater)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT * FROM F_product_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    productRepeater.DataSource = reader;
                    productRepeater.DataBind();
                }
            }
        }

        public string AddProduct(FileUpload fileUpload, string productName, string price, string delPrice)
        {
            try
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = HttpContext.Current.Server.MapPath("~/image/feature product/") + fileName;
                fileUpload.SaveAs(filePath);

                byte[] imageData;
                using (Stream stream = fileUpload.FileContent)
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        imageData = reader.ReadBytes((int)stream.Length);
                    }
                }

                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string query = "INSERT INTO F_product_tbl (F_Product_image, F_Product_name, F_Price, F_Del_Price) " +
                                   "VALUES (@Product_image, @Product_name, @Price, @Del_Price)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Product_image", imageData);
                        cmd.Parameters.AddWithValue("@Product_name", productName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Del_Price", delPrice);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Product added successfully!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public void DeleteProduct(string productId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "DELETE FROM F_product_tbl WHERE Id = @productId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LoadSettings(ref TextBox textBox1, ref TextBox textBox2, ref TextBox textBox3, ref TextBox textBox4, ref TextBox textBox5, ref TextBox textBox6, ref TextBox textBox7)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT * FROM setting_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        textBox1.Text = reader["Site_Title"].ToString();
                        textBox3.Text = reader["Site_Title2"].ToString();
                        textBox2.Text = reader["Imformation"].ToString();
                        textBox4.Text = reader["Location"].ToString();
                        textBox5.Text = reader["Email"].ToString();
                        textBox6.Text = reader["Contact"].ToString();
                        textBox7.Text = reader["Customer_Service"].ToString();
                    }
                    reader.Close();
                }
            }
        }

        public void UpdateSettings1(string siteTitle, string siteTitle2, string info)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE setting_tbl SET Site_Title = @s1, Site_Title2 = @s2, Imformation = @info WHERE Id = @settingid";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@s1", siteTitle);
                    cmd.Parameters.AddWithValue("@s2", siteTitle2);
                    cmd.Parameters.AddWithValue("@info", info);
                    cmd.Parameters.AddWithValue("@settingid", 1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSettings2(string location, string email, string contact, string customerService)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE setting_tbl SET Location = @l, Email = @e, Contact = @c, Customer_Service = @cs WHERE Id = @settingid";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@l", location);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@c", contact);
                    cmd.Parameters.AddWithValue("@cs", customerService);
                    cmd.Parameters.AddWithValue("@settingid", 1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ********** NEWSLETTER PAGE FUNCTIONALITIES **********

        public void LoadNewsletter(ref TextBox textBox8, Repeater UserRepeater)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT * FROM Newsletter_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Load first value for TextBox
                        if (reader.Read())
                        {
                            textBox8.Text = reader["Newsletter"].ToString();
                        }

                        // Move back to beginning
                        reader.Close();
                    }

                    // Load all data for Repeater
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        UserRepeater.DataSource = dt;
                        UserRepeater.DataBind();
                    }
                }
            }
        }


        public void UpdateNewsletter(string newsletter)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE Newsletter_tbl SET Newsletter = @New WHERE Id = @settingid";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@New", newsletter);
                    cmd.Parameters.AddWithValue("@settingid", 1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteNewsletter(int delId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "DELETE FROM Newsletter_tbl WHERE Id = @delId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@delId", delId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetUserData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT * FROM user_register_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public string GetUserStatus(string userId)
        {
            string status = "";
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT Status FROM user_register_tbl WHERE Id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    status = cmd.ExecuteScalar()?.ToString();
                    con.Close();
                }
            }
            return status;
        }

        public void UpdateUserStatus(string userId, string newStatus)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "UPDATE user_register_tbl SET Status = @NewStatus WHERE Id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void DeleteUser(string userId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "DELETE FROM user_register_tbl WHERE Id = @UserId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public DataTable GetUserQueryData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT * FROM user_query_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public void DeleteUserQuery(string queryId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "DELETE FROM user_query_tbl WHERE Id = @QueryId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@QueryId", queryId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void DeleteAllUserQueries()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "DELETE FROM user_query_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void Load_Products(Repeater userRepeater)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT * FROM product_tbl";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    userRepeater.DataSource = reader;
                    userRepeater.DataBind();
                }
            }
        }

        public string Add_Product(FileUpload fileUpload, string productName, string price, string delPrice , string ProductDetail ,string product_n1 )
        {
            try
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = HttpContext.Current.Server.MapPath("~/image/product/") + fileName;
                fileUpload.SaveAs(filePath);

                byte[] imageData;
                using (Stream stream = fileUpload.FileContent)
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        imageData = reader.ReadBytes((int)stream.Length);
                    }
                }

                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string query = "INSERT INTO product_tbl (Product_image, Product_name, Price, Del_Price , Product_Detail , Product_n1 ) " +
                                   "VALUES (@Product_image, @Product_name, @Price, @Del_Price , @Pro_detail , @Pro_n1)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Product_image", imageData);
                        cmd.Parameters.AddWithValue("@Product_name", productName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Del_Price", delPrice);
                        cmd.Parameters.AddWithValue("@Pro_detail", ProductDetail);
                        cmd.Parameters.AddWithValue("@Pro_n1", product_n1);


                        cmd.ExecuteNonQuery();
                    }
                }
                return "Product added successfully!";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public void Delete_Product(string productId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "DELETE FROM product_tbl WHERE Id = @productId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
