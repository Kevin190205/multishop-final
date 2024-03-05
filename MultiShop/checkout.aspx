<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="MultiShop.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <a class="breadcrumb-item text-dark" href="#">Shop</a>
                    <span class="breadcrumb-item active">Checkout</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Checkout Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-8">
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Shipping Address</span></h5>
                <div class="bg-light p-30 mb-5">
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="First Name"></asp:Label>
                            <asp:TextBox ID="f" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="Last Name"></asp:Label>
                            <asp:TextBox ID="l" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="E-mail"></asp:Label>
                            <asp:TextBox ID="e" runat="server" CssClass="form-control" placeholder="example@email.com"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="Mobile No"></asp:Label>
                            <asp:TextBox ID="m" runat="server" CssClass="form-control" placeholder="+123 456 789"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="Address Line 1"></asp:Label>
                            <asp:TextBox ID="a1" runat="server" CssClass="form-control" placeholder="123 Street"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="Address Line 2"></asp:Label>
                            <asp:TextBox ID="a2" runat="server" CssClass="form-control" placeholder="123 Street"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="Country"></asp:Label>
                            <asp:DropDownList ID="dd" runat="server" CssClass="custom-select">
                                <asp:ListItem Text="India" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Afghanistan"></asp:ListItem>
                                <asp:ListItem Text="Albania"></asp:ListItem>
                                <asp:ListItem Text="Algeria"></asp:ListItem>
                                <asp:ListItem>United States</asp:ListItem>
                                <asp:ListItem>US</asp:ListItem>
                                <asp:ListItem>UK</asp:ListItem>
                                <asp:ListItem>Canada</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="City"></asp:Label>
                            <asp:TextBox ID="c" runat="server" CssClass="form-control" placeholder="Rajkot"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="State"></asp:Label>
                            <asp:TextBox ID="s" runat="server" CssClass="form-control" placeholder="Gujarat"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label runat="server" Text="Pin Code"></asp:Label>
                            <asp:TextBox ID="p" runat="server" CssClass="form-control" placeholder="360020"></asp:TextBox>
                        </div>
                    </div>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                </div>
            </div>
            <div class="col-lg-4">
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Order Total</span></h5>
                <div class="bg-light p-30 mb-5">
                    <div class="border-bottom">
                        <h6 class="mb-3">Products</h6>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between">
                                    <p><%# Eval("C_Product_name") %></p>
                                    <p>$<%# Eval("C_Price")%></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="border-bottom pt-3 pb-2">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between mb-3">
                                    <h6>Subtotal</h6>
                                    <h6>$<%# Eval("TotalSum") %></h6>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="d-flex justify-content-between">
                            <h6 class="font-weight-medium">Shipping</h6>
                            <h6 class="font-weight-medium">$60</h6>
                        </div>
                    </div>
                    <div class="pt-2">
                        <div class="d-flex justify-content-between mt-2">
                            <h5>Total</h5>
                            <h5>$<asp:Label ID="lblTotalWithShipping" runat="server"></asp:Label></h5>
                        </div>
                    </div>
                </div>
                <div class="mb-5">
                    <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Payment</span></h5>
                    <div class="bg-light p-30">
                        <asp:RadioButtonList ID="paymentMethodRadio" runat="server" CssClass="form-group">
                            <asp:ListItem Text="Online Payment"></asp:ListItem>
                            <asp:ListItem Text="Cash_On_Delivery"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Button ID="placeorder" runat="server" Text="Place Order" CssClass="btn btn-block btn-primary font-weight-bold py-3" OnClick="placeorder_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Checkout End -->

</asp:Content>


<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>



