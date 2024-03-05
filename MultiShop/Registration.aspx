<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MultiShop.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

  <%@ Register Src="~/inc/Header.ascx" TagName="Header" TagPrefix="uc" %>
     <uc:Header runat="server" />

</asp:Content>


<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    
    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
     <uc:Footer runat="server" />  

</asp:Content>
<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

    <!-- Breadcrumb Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-12">
                <nav class="breadcrumb bg-light mb-30">
                    <a class="breadcrumb-item text-dark" href="MultiShop.aspx">Home</a>
                    <span class="breadcrumb-item active">Registration Form</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Registration Form Start -->
    <div class="container" align="center">
        <h2 class="section-title position-relative text-uppercase mx-auto mb-4"><span class="bg-secondary pr-3">User Registration</span></h2>
        <div class="row justify-content-center">
            <div class="col-lg-7 mb-5">
                <div class="contact-form bg-light p-30">
                    <div id="success"></div>
                    <asp:Panel runat="server" CssClass="container-xl py-5">
                        <div class="row g-3">
                            <div class="col-md-6">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="firstName" placeholder="First Name"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="lastName" placeholder="Last Name"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="email" TextMode="Email" placeholder="Your Email"></asp:TextBox>
                                    <br />
                                </div>
                            </div>                           
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="username" placeholder="Username"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="password" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="confirmPassword" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                             <div class="col-12">
                                <div class="form-floating">
                                    Select Your Profile Picture :
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <br />
                                </div>
                            </div>
                            <div class="col-12">
                                <asp:Literal runat="server" ID="messageLiteral" Visible="false"></asp:Literal>
                            </div> 
                            <div class="col-12 text-center">
                                <br />
                                <asp:ImageButton runat="server" Style="mix-blend-mode: multiply;" AlternateText="Submit" ImageUrl="~/image/register2.png" ID="registerbutton" Height="90px" Width="300px" OnClick="registerbutton_Click" />
                            </div>
                            <div class="col-12 text-center mt-3">
                                <p>Already have an account?
                                    <asp:HyperLink ID="HyperLinkLogin" runat="server" NavigateUrl="~/Login.aspx"     Text="Login now"></asp:HyperLink></p>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- Registration Form End -->

</asp:Content>

