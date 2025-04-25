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
        private readonly UserClass userClass = new UserClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartData();
                LoadTotalPrice();
                LoadTotalWithShipping();
                HandleQueryParameters();
            }
        }

        private void LoadCartData()
        {
            string sessionUser = Session["Username"]?.ToString();

            if (string.IsNullOrEmpty(sessionUser))
            {
                Response.Redirect("Login.aspx");
                return;
            }

            DataTable dt = userClass.GetCartByUser(sessionUser);
            cart_p.DataSource = dt;
            cart_p.DataBind();
        }

        private void LoadTotalPrice()
        {
            string sessionUser = Session["Username"]?.ToString();

            if (!string.IsNullOrEmpty(sessionUser))
            {
                decimal totalSum = userClass.GetCartTotal(sessionUser);
                DataTable dt = new DataTable();
                dt.Columns.Add("TotalSum", typeof(decimal));
                dt.Rows.Add(totalSum);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        private void LoadTotalWithShipping()
        {
            string sessionUser = Session["Username"]?.ToString();

            if (!string.IsNullOrEmpty(sessionUser))
            {
                decimal total = userClass.GetCartTotal(sessionUser) + 60;
                lblTotalWithShipping.Text = total.ToString();
            }
            else
            {
                lblTotalWithShipping.Text = "0";
            }
        }

        private void HandleQueryParameters()
        {
            string delId = Request.QueryString["delId"];
            if (!string.IsNullOrEmpty(delId))
            {
                userClass.DeleteFromCart(int.Parse(delId));
            }

            string sub = Request.QueryString["sub"];
            if (!string.IsNullOrEmpty(sub))
            {
                AdjustCartQuantity(int.Parse(sub), -1);
            }

            string add = Request.QueryString["add"];
            if (!string.IsNullOrEmpty(add))
            {
                AdjustCartQuantity(int.Parse(add), 1);
            }
        }

        private void AdjustCartQuantity(int cartId, int adjustment)
        {
            DataTable dt = userClass.GetCartByUser(Session["Username"].ToString());
            DataRow row = dt.Select($"C_Id = '{cartId}'").FirstOrDefault();

            if (row != null)
            {
                int quantity = Convert.ToInt32(row["C_Quantity"]) + adjustment;
                decimal price = Convert.ToDecimal(row["C_Price"]);
                decimal total = Convert.ToDecimal(row["C_Total"]) + (price * adjustment);
                decimal shippingTotal = total + 60;

                if (quantity > 0)
                {
                    userClass.UpdateCartQuantity(cartId, quantity, total, shippingTotal);
                }
                else
                {
                    userClass.DeleteFromCart(cartId);
                }
            }
        }

        protected void btnProceedToCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }

    }
}