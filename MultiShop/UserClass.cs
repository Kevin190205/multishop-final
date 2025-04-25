using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public class UserClass
    {
        private string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public void AddToCart(string productId, string sessionUser)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                // Get Product Details
                string pname = "", pprice = "", delprice = "";
                byte[] imageData = null;

                string query = "SELECT * FROM product_tbl WHERE Id = @productId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pname = reader["Product_Name"].ToString();
                        pprice = reader["Price"].ToString();
                        delprice = reader["Del_Price"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("Product_image")))
                        {
                            imageData = (byte[])reader["Product_image"];
                        }
                    }
                    reader.Close();
                }

                string sp = (Convert.ToInt32(pprice) + 60).ToString();

                // Insert into Cart
                string insertQuery = "INSERT INTO Cart_tbl (C_Product_name, C_Price, C_Del_Price, C_Product_image, C_Quantity, C_Total, C_ship_total, C_User_Id) " +
                                     "VALUES (@pn, @pp, @pdp, @pi, @q, @t, @st, @uid)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@pn", pname);
                    cmd.Parameters.AddWithValue("@pp", pprice);
                    cmd.Parameters.AddWithValue("@pdp", delprice);
                    cmd.Parameters.AddWithValue("@pi", imageData);
                    cmd.Parameters.AddWithValue("@q", '1');
                    cmd.Parameters.AddWithValue("@t", pprice);
                    cmd.Parameters.AddWithValue("@st", sp);
                    cmd.Parameters.AddWithValue("@uid", sessionUser);
                    cmd.ExecuteNonQuery();
                }

                // Insert into Order Table
                string insertOrderQuery = "INSERT INTO order_tbl (P_Image, P_Name, P_Price, User_Id) VALUES (@im, @na, @pr, @id)";
                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, con))
                {
                    cmd.Parameters.AddWithValue("@id", sessionUser);
                    cmd.Parameters.AddWithValue("@im", imageData);
                    cmd.Parameters.AddWithValue("@na", pname);
                    cmd.Parameters.AddWithValue("@pr", pprice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveFromCart(string delId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "DELETE FROM Cart_tbl WHERE C_Id = @delId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@delId", delId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader GetCartData(string sessionUser)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "SELECT C_Id, C_Product_image, C_Product_name, C_Price, C_Del_Price FROM Cart_tbl WHERE C_User_Id=@sessionuser";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sessionuser", sessionUser);
            return cmd.ExecuteReader();
        }


        // Add To Wishlist

        public void AddToWishlist(string productId, string sessionUser)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                // Get Product Details
                string pname = "", pprice = "", delprice = "";
                byte[] imageData = null;

                string query = "SELECT * FROM product_tbl WHERE Id = @productId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pname = reader["Product_Name"].ToString();
                        pprice = reader["Price"].ToString();
                        delprice = reader["Del_Price"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("Product_image")))
                        {
                            imageData = (byte[])reader["Product_image"];
                        }
                    }
                    reader.Close();
                }

                // Insert into Wishlist
                string insertQuery = "INSERT INTO Wishlist_tbl (W_Product_name, W_Price, W_Del_Price, W_Product_image, W_User_Id) VALUES (@pn, @pp, @pdp, @pi, @uid)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@pn", pname);
                    cmd.Parameters.AddWithValue("@pp", pprice);
                    cmd.Parameters.AddWithValue("@pdp", delprice);
                    cmd.Parameters.AddWithValue("@pi", imageData);
                    cmd.Parameters.AddWithValue("@uid", sessionUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void MoveToWishlistFromCart(string remove, string sessionUser)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string pname = "", pprice = "", delprice = "";
                byte[] imageData = null;

                string query = "SELECT * FROM Cart_tbl WHERE C_Id = @remove";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@remove", remove);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pname = reader["C_Product_Name"].ToString();
                        pprice = reader["C_Price"].ToString();
                        delprice = reader["C_Del_Price"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("C_Product_image")))
                        {
                            imageData = (byte[])reader["C_Product_image"];
                        }
                    }
                    reader.Close();
                }

                // Insert into Wishlist
                string insertQuery = "INSERT INTO Wishlist_tbl (W_Product_name, W_Price, W_Del_Price, W_Product_image, W_User_Id) VALUES (@pn, @pp, @pdp, @pi, @uid)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@pn", pname);
                    cmd.Parameters.AddWithValue("@pp", pprice);
                    cmd.Parameters.AddWithValue("@pdp", delprice);
                    cmd.Parameters.AddWithValue("@pi", imageData);
                    cmd.Parameters.AddWithValue("@uid", sessionUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveFromWishlist(string delId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "DELETE FROM Wishlist_tbl WHERE W_Id = @delId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@delId", delId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader GetWishlistData(string sessionUser)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "SELECT W_Id, W_Product_image, W_Product_name, W_Price, W_Del_Price FROM Wishlist_tbl WHERE W_User_Id=@sessionuser";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sessionuser", sessionUser);
            return cmd.ExecuteReader();
        }



        public UserClass()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }

        public DataTable GetWishlistByUser(string username)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT W_Id, W_Product_image, W_Product_name, W_Price, W_Del_Price FROM Wishlist_tbl WHERE W_User_Id=@username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void AddToWishlist(string pname, decimal price, decimal delPrice, byte[] image, string username)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "INSERT INTO Wishlist_tbl (W_Product_name, W_Price, W_Del_Price, W_Product_image, W_User_Id) VALUES (@pn, @pp, @pdp, @pi, @uid)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@pn", pname);
                    cmd.Parameters.AddWithValue("@pp", price);
                    cmd.Parameters.AddWithValue("@pdp", delPrice);
                    cmd.Parameters.AddWithValue("@pi", image);
                    cmd.Parameters.AddWithValue("@uid", username);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFromWishlist(int wishlistId)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Wishlist_tbl WHERE W_Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", wishlistId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetCartByUser(string username)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT C_Id, C_Product_image, C_Product_name, C_Price, C_Del_Price, C_Quantity, C_Total FROM Cart_tbl WHERE C_User_Id=@username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void UpdateCartQuantity(int cartId, int quantity, decimal total, decimal shippingTotal)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "UPDATE Cart_tbl SET C_Quantity = @quantity, C_Total = @total, C_ship_total = @shippingTotal WHERE C_Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@shippingTotal", shippingTotal);
                    cmd.Parameters.AddWithValue("@id", cartId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFromCart(int cartId)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "DELETE FROM Cart_tbl WHERE C_Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", cartId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public decimal GetCartTotal(string username)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT SUM(CAST(C_Total AS decimal)) FROM Cart_tbl WHERE C_User_Id=@username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
        // Method to fetch all products
        public DataTable GetAllProducts()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT Id, Product_image, Product_n1, Price, Del_Price FROM product_tbl";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Method to fetch products within a specific price range
        public DataTable GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT Id, Product_image, Product_name, Price, Del_Price FROM product_tbl WHERE Price BETWEEN @MinPrice AND @MaxPrice";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Method to fetch products above a certain price
        public DataTable GetProductsAbovePrice(decimal minPrice)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT Id, Product_image, Product_name, Price, Del_Price FROM product_tbl WHERE Price >= @MinPrice";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MinPrice", minPrice);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetUserByUsername(string username)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT * FROM user_register_tbl WHERE username = @UserName";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool UpdateUserProfile(string username, string firstName, string lastName, string email, string address, string contact, string city, string state, byte[] imageData)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "UPDATE user_register_tbl SET firstName=@FirstName, lastName=@LastName, email=@Email, address=@Address, contact=@Contact, city=@City, state=@State";

                if (imageData != null)
                    query += ", ImageData=@ImageData";

                query += " WHERE username=@Username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Username", username);

                    if (imageData != null)
                        cmd.Parameters.AddWithValue("@ImageData", imageData);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string query = "SELECT password FROM user_register_tbl WHERE username=@Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    string storedPassword = cmd.ExecuteScalar() as string;

                    if (storedPassword == oldPassword)
                    {
                        string updateQuery = "UPDATE user_register_tbl SET password=@NewPassword WHERE username=@Username";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                            updateCmd.Parameters.AddWithValue("@Username", username);
                            return updateCmd.ExecuteNonQuery() > 0;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool RegisterUser(string firstName, string lastName, string email, string username, string password, byte[] imageData)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string insertQuery = "INSERT INTO user_register_tbl (firstname, lastname, email, username, password, ImageData, Status) " +
                                     "VALUES (@FirstName, @LastName, @Email, @Username, @Password, @ImageData, @Status)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@ImageData", imageData);
                    cmd.Parameters.AddWithValue("@Status", "Active");

                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if insertion is successful
                }
            }
        }

        public (bool isAuthenticated, string status) AuthenticateUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                string query = "SELECT Password, Status FROM user_register_tbl WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString();
                            string status = reader["Status"].ToString();

                            if (password == storedPassword)
                            {
                                return (true, status); // Authentication success, return status
                            }
                        }
                    }
                }
            }
            return (false, null); // Authentication failed
        }
    }
}