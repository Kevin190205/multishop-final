<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="MultiShop.cart" %>

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
                    <span class="breadcrumb-item active">Shopping Cart</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Cart Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-8 table-responsive mb-5">
                <table class="table table-light table-borderless table-hover text-center mb-0">
                    <thead class="thead-dark">
                        <tr>
                            <th>Product Image</th>
                            <th>Products Name</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th>Total</th>
                            <th>Remove</th>
                        </tr>
                    </thead>
                    <tbody class="align-middle">
                        <asp:Repeater ID="cart_p" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="align-middle">
                                        <img src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("C_Product_image")) %>' alt="" style="width: 50px; height: 60px">
                                        </td>
                                    <td class="align-middle"><%# Eval("C_Product_name") %> </td>
                                    <td class="align-middle">$<%# Eval("C_Price")%></td>
                                    <td class="align-middle">
                                        <div class="input-group quantity mx-auto" style="width: 100px;">
                                            <div class="input-group-btn">
                                                <button class="btn btn-sm btn-primary btn-minus" onclick="minus('<%# Eval("C_Id") %>');">
                                                    <i class="fa fa-minus"></i>
                                                </button>
                                            </div>
                                            <input type="text" class="form-control form-control-sm bg-secondary border-0 text-center" value="<%# Eval("C_Quantity")%>">
                                            <div class="input-group-btn">
                                                <button class="btn btn-sm btn-primary btn-plus" onclick="plus('<%# Eval("C_Id") %>');">
                                                    <i class="fa fa-plus"></i>
                                                </button>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="align-middle">$<%# Eval("C_Total")%></td>
                                    <td class="align-middle">
                                        <button class="btn btn-sm btn-danger" onclick="removeFromCart('<%# Eval("C_Id") %>');">
                                            <i class="fa fa-times"></i>
                                        </button>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="col-lg-4">
                
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Cart Summary</span></h5>
                <div class="bg-light p-30 mb-5">
                    <div class="border-bottom pb-2">
                        <asp:Repeater ID="Repeater1" runat="server">
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
                        <asp:Button ID="btnProceedToCheckout" runat="server" CssClass="btn btn-block btn-primary font-weight-bold my-3 py-3" Text="Proceed To Checkout" OnClick="btnProceedToCheckout_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Cart End -->

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        function removeFromCart(delId) {
            // Make an AJAX request to RemoveFromCart.aspx with productId in the query string
            $.ajax({
                url: 'cart.aspx?delId=' + delId, // Use productId instead of delId
                type: 'GET',
                success: function (response) {

                    console.log('Product removed from cart successfully.');
                },
                error: function (xhr, status, error) {
                    // Handle errors if any
                    console.error('Error removing product from cart:', error);
                }
            });
        }
    </script>

    <script>
        function minus(sub) {
            $.ajax({
                url: 'cart.aspx?sub=' + sub,
                type: 'GET',
                success: function (response) {
                    // Handle the response if needed
                    console.log('Product added to cart successfully.');
                },
                error: function (xhr, status, error) {
                    // Handle errors if any
                    console.error('Error adding product to cart:', error);
                }
            });
        }

        function plus(add) {
            $.ajax({
                url: 'cart.aspx?add=' + add,
                type: 'GET',
                success: function (response) {
                    // Handle the response if needed
                    console.log('Product added to wishlist successfully.');
                },
                error: function (xhr, status, error) {
                    // Handle errors if any
                    console.error('Error adding product to wishlist:', error);
                }
            });
        }
    </script>


</asp:Content>

<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>

