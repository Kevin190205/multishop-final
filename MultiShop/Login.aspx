 <%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MultiShop.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder3">

  <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
     <uc:Footer runat="server" />  

            </asp:Content>

<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder1">

      <%@ Register Src="~/inc/Header.ascx" TagName="Header" TagPrefix="uc" %>
     <uc:Header runat="server" />
                
</asp:Content>


<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder2">
                   
     <!-- Breadcrumb Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-12">
                <nav class="breadcrumb bg-light mb-30">
                    <a class="breadcrumb-item text-dark" href="#">Home</a>
                    <span class="breadcrumb-item active">Login Form</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- login Form Start -->
    <div class="container" align="center">
        <h2 class="section-title position-relative mx-auto mb-4"><span class="bg-secondary pr-3">Login</span></h2>
        <div class="row justify-content-center">
            <div class="col-lg-7 mb-5">
                <div class="contact-form bg-light p-30">
                    <div id="success"></div>
                    <asp:Panel runat="server" CssClass="container-xl py-5">
                        <div class="row g-2">
                            
                            </div>
                            <div class="col-12">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="username" placeholder="Username"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="password" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    <br />
                                </div>
                            </div>
                            
                            <div class="col-12">
                                <asp:Literal runat="server" ID="messageLiteral" Visible="false"></asp:Literal>
                            </div>
                            <div class="col-12 text-center">
                                <br />
                                <asp:ImageButton runat="server" Style="mix-blend-mode: multiply;" AlternateText="Submit" ImageUrl="~/image/login1.png" ID="login_button" Height="80px" Width="250px" OnClick="login_button_Click" />
                            </div>
                        <div class="col-12 text-center mt-3">
                                <p>Don't have an account yet?
                                    <asp:HyperLink ID="HyperLinkLogin" runat="server" NavigateUrl="~/Registration.aspx"     Text="Register now"></asp:HyperLink></p>
                            </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- login Form End -->

</asp:Content>

