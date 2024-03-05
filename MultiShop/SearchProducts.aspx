<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="SearchProducts.aspx.cs" Inherits="MultiShop.SearchProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder1">

<%@ Register Src="~/inc/Header.ascx" TagName="Header" TagPrefix="uc" %>
    <uc:Header runat="server" />
                
</asp:Content>

<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder3">

<%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />
                 
</asp:Content>


<asp:Content ID="Content7" runat="server" contentplaceholderid="ContentPlaceHolder2">
<body>
    <div class="container-fluid pt-5 pb-3">
        <h2 class="section-title position-relative text-uppercase mx-xl-5 mb-4"><span class="bg-secondary pr-3">Search Products</span></h2>
        <div class="row px-xl-5">
            <asp:Repeater ID="ProductRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 col-sm-6 pb-1">
                        <div class="product-item bg-light mb-4">
                            <div class="product-img position-relative overflow-hidden">
                                <img class="img-fluid w-100" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                <div class="product-action">
                                    <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                        <i class="fa fa-shopping-cart"></i>
                                    </button>&nbsp;&nbsp;
                                    <button class="btn btn-outline-dark btn-square" onclick="addToWishlist('<%# Eval("Id") %>');">
                                        <i class="far fa-heart"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="text-center py-4">
                                <a class="h6 text-decoration-none text-truncate" href=""><%# Eval("Product_name") %></a>
                                <div class="d-flex align-items-center justify-content-center mt-2">
                                    <h5><%# Eval("Price") %></h5>
                                    <h6 class="text-muted ml-2"><del><%# Eval("Del_Price") %></del></h6>
                                </div>
                                <div class="d-flex align-items-center justify-content-center mb-1">
                                    <small class="fa fa-star text-primary mr-1"></small>
                                    <small class="fa fa-star text-primary mr-1"></small>
                                    <small class="fa fa-star text-primary mr-1"></small>
                                    <small class="far fa-star text-primary mr-1"></small>
                                    <small class="far fa-star text-primary mr-1"></small>
                                    <small>(99)</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="NoProductsMessage" runat="server" Visible="false"></asp:Literal>
        </div>
    </div>
</body>         
    


    
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script>
    function addToCart(productId) {
        // Make an AJAX request to AddToCart.aspx with productId in the query string
        $.ajax({
            url: 'AddToCart.aspx?productId=' + productId,
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

    function addToWishlist(productId) {
        // Make an AJAX request to AddToWishlist.aspx with productId in the query string
        $.ajax({
            url: 'AddToWishlist.aspx?productId=' + productId,
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





