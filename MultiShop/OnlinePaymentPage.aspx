<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="OnlinePaymentPage.aspx.cs" Inherits="MultiShop.OnlinePaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder2">
                   
    <style>
        .row {
            margin-bottom: 10px;
        }
    </style>



    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        function OpenPaymentWindow(key, amountInSubunits, currency, name, descritpion, imageLogo, orderId, profileName, profileEmail, profileMobile, shiptotal, country, state, city, pincode, lastName, address1, address2, notes) {
            notes = JSON.parse(notes);
            var options = {
                "key": key, // Enter the Key ID generated from the Dashboard
                "amount": amountInSubunits, // Amount is in currency subunits. Default currency is INR. Hence, 50000 refers to 50000 paise
                "currency": currency,
                "name": name,
                "description": descritpion,
                "image": imageLogo,
                "order_id": orderId, //This is a sample Order ID. Pass the `id` obtained in the response of Step 1
                "handler": function (response) {
                    var orderId = response.razorpay_order_id;
                    var paymentId = response.razorpay_payment_id;
                    var redirectUrl = "myorder.aspx?";
                    redirectUrl += "orderId=" + orderId;
                    redirectUrl += "&paymentId=" + paymentId;
                    redirectUrl += "&name=" + encodeURIComponent(profileName);
                    redirectUrl += "&email=" + encodeURIComponent(profileEmail);
                    redirectUrl += "&contact=" + encodeURIComponent(profileMobile);
                    redirectUrl += "&totalship=" + encodeURIComponent(shiptotal);
                    redirectUrl += "&lastn=" + encodeURIComponent(lastName);
                    redirectUrl += "&add1=" + encodeURIComponent(address1);
                    redirectUrl += "&add2=" + encodeURIComponent(address2);
                    redirectUrl += "&coun=" + encodeURIComponent(country);
                    redirectUrl += "&stat=" + encodeURIComponent(state);
                    redirectUrl += "&ci=" + encodeURIComponent(city);
                    redirectUrl += "&pin=" + encodeURIComponent(pincode);
                    window.location.href = redirectUrl;
                },
                "prefill": {
                    "name": profileName,
                    "email": profileEmail,
                    "contact": profileMobile
                },
                "notes": notes,
                "theme": {
                    "color": "#F37254"
                }
            };
            var rzp1 = new Razorpay(options);
            rzp1.open();
            rzp1.on('payment.failed', function (response) {
                console.log(response.error);
                alert("Oops, something went wrong and payment failed. Please try again later");
            });
        }

    </script>
    
</asp:Content>

