
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace MultiShop
{
    public partial class shop : System.Web.UI.Page
    {
        private UserClass productDAL = new UserClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            if (CheckBox1.Checked)
                BindRepeater(ProductRepeater, Label7, productDAL.GetAllProducts());
            else
                ClearRepeater(ProductRepeater, Label7);

            if (CheckBox2.Checked)
                BindRepeater(Repeater1, Label8, productDAL.GetProductsByPriceRange(0, 400));
            else
                ClearRepeater(Repeater1, Label8);

            if (CheckBox3.Checked)
                BindRepeater(Repeater2, Label9, productDAL.GetProductsByPriceRange(400, 500));
            else
                ClearRepeater(Repeater2, Label9);

            if (CheckBox4.Checked)
                BindRepeater(Repeater3, Label10, productDAL.GetProductsByPriceRange(500, 700));
            else
                ClearRepeater(Repeater3, Label10);

            if (CheckBox5.Checked)
                BindRepeater(Repeater4, Label11, productDAL.GetProductsByPriceRange(700, 1000));
            else
                ClearRepeater(Repeater4, Label11);

            if (CheckBox6.Checked)
                BindRepeater(Repeater5, Label12, productDAL.GetProductsAbovePrice(1000));
            else
                ClearRepeater(Repeater5, Label12);
        }

        private void BindRepeater(Repeater repeater, Label label, DataTable data)
        {
            repeater.DataSource = data;
            repeater.DataBind();
            label.Text = repeater.Items.Count.ToString();
        }

        private void ClearRepeater(Repeater repeater, Label label)
        {
            repeater.DataSource = null;
            repeater.DataBind();
            label.Text = "0";
        }

        protected void ProductRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "cmd_detail")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Detail.aspx?pid=" + id);
            }
        }
    }
}