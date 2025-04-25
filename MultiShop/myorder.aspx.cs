using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

using CrystalDecisions.Shared;


namespace MultiShop
{
    public partial class detail : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection con;
        SqlCommand cmd;

        private CrystalDecisions.CrystalReports.Engine.ReportDocument cr = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        static string Crypath = "";


        void getcon()
        {
            con = new SqlConnection(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
            if (!IsPostBack)
            {
                LoadUserData();
            }
        }
        private void LoadUserData()
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string username = Session["Username"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM buy_product_tbl WHERE [User] = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);

                DataTable dataTable = new DataTable();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                myorder.DataSource = dataTable;
                myorder.DataBind();
            }
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;


            string orderId = button.CommandArgument;

         
            string updateQuery = "UPDATE buy_product_tbl SET order_status = @newStatus WHERE Id = @orderId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@newStatus", "Cancel Order");
                    command.Parameters.AddWithValue("@orderId", orderId);

                    connection.Open();

                    command.ExecuteNonQuery();
                    LoadUserData();
                }
            }
        }
        protected bool IsDeleteEnabled(object orderStatus)
        {
            if (orderStatus != null && orderStatus.ToString() == "Processing")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected string GetOrderStatusColor(object orderStatus)
        {
            if (orderStatus != null)
            {
                string status = orderStatus.ToString();
                if (status.Equals("Processing", StringComparison.OrdinalIgnoreCase))
                {
                    return "order_status_processing";
                }
                else if (status.Equals("cancel order", StringComparison.OrdinalIgnoreCase))
                {
                    return "order_status_cancelled";
                }
                else if (status.Equals("shipped", StringComparison.OrdinalIgnoreCase))
                {
                    return "order_status_shipped";
                }
            }
            return "";
        }
        protected string GetButtonColor(object orderStatus)
        {
            if (orderStatus != null && orderStatus.ToString() == "Processing")
            {
                return "delete";
            }
            else
            {
                return "Deactivate";
            }
        }

        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string oId = button.CommandArgument;
          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM buy_product_tbl WHERE [Id] = @oId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@oId", oId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    string firstname = reader["Firstname"].ToString();
                    string lastname = reader["Lastname"].ToString();
                    string email = reader["Email"].ToString();
                    string mobileNo = reader["Mobile_no"].ToString();
                    string address1 = reader["Address_1"].ToString();
                    string address2 = reader["Address_2"].ToString();
                    string country = reader["Country"].ToString();
                    string city = reader["City"].ToString();
                    string state = reader["State"].ToString();
                    string pincode = reader["Pincode"].ToString();
                    string status = reader["Status"].ToString();
                    string amount = reader["Amount"].ToString();
                    string dateTime = reader["Date_Time"].ToString();
                    string user = reader["User"].ToString();
                    string orderId = reader["OrderId"].ToString();
                    string paymentId = reader["PaymentId"].ToString();
                    string orderStatus = reader["order_status"].ToString();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        Document doc = new Document();
                        PdfWriter.GetInstance(doc, ms);
                        doc.Open();

                        Paragraph title = new Paragraph("Invoice");
                        title.Alignment = Element.ALIGN_CENTER;
                        title.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18f, BaseColor.BLUE);
                        doc.Add(title);

                        doc.Add(new Paragraph("\n"));

                        PdfPTable table = new PdfPTable(2); 
                        table.WidthPercentage = 80;
                        table.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.DefaultCell.Border = Rectangle.NO_BORDER;

                        AddCell(table, "Order ID:", orderId);
                        AddCell(table, "Payment ID:", paymentId);
                        AddCell(table, "Amount:", amount);
                        AddCell(table, "Payment Status:", status);
                        AddCell(table, "Date Time:", dateTime);
                        AddCell(table, "Order Status:", orderStatus);
                        AddCell(table, "User:", user);
                        AddCell(table, "First Name:", firstname);
                        AddCell(table, "Last Name:", lastname);
                        AddCell(table, "Email:", email);
                        AddCell(table, "Mobile No.:", mobileNo);
                        AddCell(table, "Delivery Address:", address1);
                        AddCell(table, "Address:", address2);
                        AddCell(table, "City:", city);
                        AddCell(table, "State:", state);
                        AddCell(table, "Pin Code:", pincode);
                        AddCell(table, "Downloaded Invoice:", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));

                        doc.Add(table);
                        doc.Close();

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Invoice.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(ms.ToArray());
                        Response.End();
                    }
                }
                else
                {
                }
            }
        }

        private void AddCell(PdfPTable table, string header, string value)
        {
            PdfPCell cellHeader = new PdfPCell(new Phrase(header, FontFactory.GetFont(FontFactory.HELVETICA_BOLD)));
            cellHeader.Border = Rectangle.NO_BORDER;
            PdfPCell cellValue = new PdfPCell(new Phrase(value));
            cellValue.Border = Rectangle.NO_BORDER;
            table.AddCell(cellHeader);
            table.AddCell(cellValue);
        }

    }
}