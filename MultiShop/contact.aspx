<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="MultiShop.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <%@ Register Src="~/inc/Header.ascx" TagName="Header" TagPrefix="uc" %>
    <uc:Header runat="server" />

</asp:Content>
<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

    <!-- Breadcrumb Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-12">
                <nav class="breadcrumb bg-light mb-30">
                    <a class="breadcrumb-item text-dark" href="#">Home</a>
                    <span class="breadcrumb-item active">Contact</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Contact Start -->
    <div class="container-fluid">
        <h2 class="section-title position-relative text-uppercase mx-xl-5 mb-4"><span class="bg-secondary pr-3">Contact Us</span></h2>
        <div class="row px-xl-5">
            <div class="col-lg-7 mb-5">
                <div class="contact-form bg-light p-30">
                    <div id="success"></div>
                    <asp:Panel runat="server" ID="contactForm">
                        <asp:TextBox ID="name" CssClass="form-control" placeholder="Your Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameValidator" ControlToValidate="name" CssClass="help-block text-danger" runat="server" ErrorMessage="Please enter your name"></asp:RequiredFieldValidator>

                        <asp:TextBox ID="email" CssClass="form-control" placeholder="Your Email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="emailValidator" ControlToValidate="email" CssClass="help-block text-danger" runat="server" ErrorMessage="Please enter your email"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="emailFormatValidator" ControlToValidate="email" CssClass="help-block text-danger" runat="server" ErrorMessage="Please enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                        <asp:TextBox ID="subject" CssClass="form-control" placeholder="Subject" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="subjectValidator" ControlToValidate="subject" CssClass="help-block text-danger" runat="server" ErrorMessage="Please enter a subject"></asp:RequiredFieldValidator>

                        <asp:TextBox ID="message" CssClass="form-control" TextMode="MultiLine" Rows="8" placeholder="Message" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="messageValidator" ControlToValidate="message" CssClass="help-block text-danger" runat="server" ErrorMessage="Please enter your message"></asp:RequiredFieldValidator>

                        <div>
                            <asp:Button ID="sendMessageButton" CssClass="btn btn-primary py-2 px-4" Text="Send Message" runat="server" OnClick="sendMessageButton_Click" />
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="col-lg-5 mb-5">
                <div class="bg-light p-30 mb-30">
                    <iframe style="width: 100%; height: 250px;"
                        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3001156.4288297426!2d-78.01371936852176!3d42.72876761954724!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4ccc4bf0f123a5a9%3A0xddcfc6c1de189567!2sNew%20York%2C%20USA!5e0!3m2!1sen!2sbd!4v1603794290143!5m2!1sen!2sbd"
                        frameborder="0" style="border: 0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
                </div>
                <div class="bg-light p-30 mb-3">
                    <p class="mb-2"><i class="fa fa-map-marker-alt text-primary mr-3"></i>123 Street, New York, USA</p>
                    <p class="mb-2"><i class="fa fa-envelope text-primary mr-3"></i>info@example.com</p>
                    <p class="mb-2"><i class="fa fa-phone-alt text-primary mr-3"></i>+012 345 67890</p>
                </div>
            </div>
        </div>
    </div>
    <!-- Contact End -->


</asp:Content>
<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>

