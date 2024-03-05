using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiShop
{
    public partial class OnlinePaymentPage : System.Web.UI.Page
    {
        private const string _key = "rzp_test_GDMFMRAC3bnneR";
        private const string _secret = "3svy4mtWsTfNFzOrzGEpCmU5";
        private const decimal registrationAmount = 100;
        string firstName;
        string lastName;
        string email;
        string mobile;
        string ship;
        protected void Page_Load(object sender, EventArgs e)
        {
            string firstName = Request.QueryString["fn"] ?? "Null Value";
            string lastName = Request.QueryString["ln"] ?? "Null Value";
            string email = Request.QueryString["em"] ?? "Null Value";
            string mobile = Request.QueryString["mo"] ?? "Null Value";
            string address1 = Request.QueryString["ad1"] ?? "Null Value";
            string address2 = Request.QueryString["ad2"] ?? "Null Value";
            string country = Request.QueryString["co"] ?? "Null Value";
            string city = Request.QueryString["ci"] ?? "Null Value";
            string state = Request.QueryString["st"] ?? "Null Value";
            string pincode = Request.QueryString["pn"] ?? "Null Value";
            string shiptotal = Request.QueryString["ship"] ?? "Null Value";
            ship = Request.QueryString["ship"] ?? registrationAmount.ToString();


           
            decimal shipAmount = decimal.Parse(ship);
            decimal amountInSubunits = shipAmount * 100;
            string currency = "INR";
            string name = "Skynet";
            string description = "Razorpay Payment Gateway Demo";
            string imageLogo = "";
            string profileName = firstName;
            string profileMobile = mobile;
            string profileEmail = email;
            Dictionary<string, string> notes = new Dictionary<string, string>()
            {
                { "note 1", "this is a payment note" }, { "note 2", "here another note, you can add max 15 notes" }
            };

            string orderId = CreateOrder(amountInSubunits, currency, notes);

            string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountInSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + profileName + "', '" + profileEmail + "', '" + profileMobile + "' , '" + shiptotal + "' , '" + country + "' , '" + state + "' , '" + city + "' , '" + lastName + "' , '" + address1 + "' , '" + address2 + "' , '" + pincode + "' , '" + JsonConvert.SerializeObject(notes) + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);

        }
        private string CreateOrder(decimal amountInSubunits, string currency, Dictionary<string, string> notes)
        {
            try
            {
                int paymentCapture = 1;

                RazorpayClient client = new RazorpayClient(_key, _secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", amountInSubunits);
                options.Add("currency", currency);
                options.Add("payment_capture", paymentCapture);
                options.Add("notes", notes);

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.Expect100Continue = false;

                Order orderResponse = client.Order.Create(options);
                var orderId = orderResponse.Attributes["id"].ToString();
                return orderId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}