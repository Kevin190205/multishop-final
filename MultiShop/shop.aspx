<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="MultiShop.shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-img-container {
            width: 150px; /* Set your desired width */
            height: 150px; /* Set your desired height */
            overflow: hidden; /* Ensure that images don't exceed the container */
        }

        .product-img {
            width: 100%; /* Make the image fill the container horizontally */
            height: 100%; /* Make the image fill the container vertically */
            object-fit: cover; /* Maintain aspect ratio while covering the container */
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
                    <a class="breadcrumb-item text-dark" href="#">Shop</a>
                    <span class="breadcrumb-item active">Shop List</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->


    <!-- Shop Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <!-- Shop Sidebar Start -->
            <div class="col-lg-3 col-md-4">
                <!-- Price Start -->
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by price</span></h5>
                <div class="bg-light p-4 mb-30">
                    <form>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True" />
                            <label for="CheckBox1">All Price</label>
                            <span class="badge border font-weight-normal" runat="server" id="Label1">
                                <asp:Label ID="Label7" runat="server"></asp:Label></span>
                        </div>

                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" />
                            <label for="CheckBox2">$0 - $400</label>
                            <span class="badge border font-weight-normal" runat="server" id="Label2">
                                <asp:Label ID="Label8" runat="server"></asp:Label></span>
                        </div>

                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" />
                            <label for="CheckBox3">$400 - $500</label>
                            <span class="badge border font-weight-normal" runat="server" id="Label3">
                                <asp:Label ID="Label9" runat="server"></asp:Label></span>
                        </div>

                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:CheckBox ID="CheckBox4" runat="server" AutoPostBack="True" />
                            <label for="CheckBox4">$500 - $700</label>
                            <span class="badge border font-weight-normal" runat="server" id="Label4">
                                <asp:Label ID="Label10" runat="server"></asp:Label></span>
                        </div>

                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True" />
                            <label for="CheckBox5">$700 - $1000</label>
                            <span class="badge border font-weight-normal" runat="server" id="Label5">
                                <asp:Label ID="Label11" runat="server"></asp:Label></span>
                        </div>

                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between">
                            <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="True" />
                            <label for="CheckBox6">$1000 Above</label>
                            <span class="badge border font-weight-normal" runat="server" id="Label6">
                                <asp:Label ID="Label12" runat="server"></asp:Label></span>
                        </div>
                    </form>
                </div>


                <!-- Price End -->

                <!-- Color Start 
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by color</span></h5>
                <div class="bg-light p-4 mb-30">
                    <form>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" checked id="color-all">
                            <label class="custom-control-label" for="price-all">All Color</label>
                            <span class="badge border font-weight-normal">1000</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="color-1">
                            <label class="custom-control-label" for="color-1">Black</label>
                            <span class="badge border font-weight-normal">150</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="color-2">
                            <label class="custom-control-label" for="color-2">White</label>
                            <span class="badge border font-weight-normal">295</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="color-3">
                            <label class="custom-control-label" for="color-3">Red</label>
                            <span class="badge border font-weight-normal">246</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="color-4">
                            <label class="custom-control-label" for="color-4">Blue</label>
                            <span class="badge border font-weight-normal">145</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between">
                            <input type="checkbox" class="custom-control-input" id="color-5">
                            <label class="custom-control-label" for="color-5">Green</label>
                            <span class="badge border font-weight-normal">168</span>
                        </div>
                    </form>
                </div>
                 Color End -->

                <!-- Size Start 
                <h5 class="section-title position-relative text-uppercase mb-3"><span class="bg-secondary pr-3">Filter by size</span></h5>
                <div class="bg-light p-4 mb-30">
                    <form>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" checked id="size-all">
                            <label class="custom-control-label" for="size-all">All Size</label>
                            <span class="badge border font-weight-normal">1000</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="size-1">
                            <label class="custom-control-label" for="size-1">XS</label>
                            <span class="badge border font-weight-normal">150</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="size-2">
                            <label class="custom-control-label" for="size-2">S</label>
                            <span class="badge border font-weight-normal">295</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="size-3">
                            <label class="custom-control-label" for="size-3">M</label>
                            <span class="badge border font-weight-normal">246</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between mb-3">
                            <input type="checkbox" class="custom-control-input" id="size-4">
                            <label class="custom-control-label" for="size-4">L</label>
                            <span class="badge border font-weight-normal">145</span>
                        </div>
                        <div class="custom-control custom-checkbox d-flex align-items-center justify-content-between">
                            <input type="checkbox" class="custom-control-input" id="size-5">
                            <label class="custom-control-label" for="size-5">XL</label>
                            <span class="badge border font-weight-normal">168</span>
                        </div>
                    </form>
                </div>

                 Size End -->
            </div>
            <!-- Shop Sidebar End -->


            <!-- Shop Product Start -->
            <div class="col-lg-9 col-md-8">
                <div class="row pb-3">
                    <div class="col-12 pb-1">
                        <div class="d-flex align-items-center justify-content-between mb-4">
                            <div class="ml-2">
                            </div>
                        </div>
                    </div>
                    <asp:Repeater ID="ProductRepeater" runat="server" OnItemCommand="ProductRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img-container position-relative overflow-hidden">
                                        <img class="product-img" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                        <div class="product-action">
                                            <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                                <i class="fa fa-shopping-cart"></i>
                                            </button>
                                            &nbsp;&nbsp;
                                    <button class="btn btn-outline-dark btn-square" onclick="addToWishlist('<%# Eval("Id") %>');">
                                        <i class="far fa-heart"></i>
                                    </button>
                                        </div>
                                    </div>
                                    <div class="text-center py-4">
                                        <a class="h6 text-decoration-none text-truncate" href=""><%# Eval("Product_n1") %></a>
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
                                    <diav>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# 
                                        Eval("Id") %>' CommandName="cmd_detail" >View Details</asp:LinkButton> 
                                    </diav>



                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img-container position-relative overflow-hidden">
                                        <img class="product-img" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                        <div class="product-action">
                                            <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                                <i class="fa fa-shopping-cart"></i>
                                            </button>
                                            &nbsp;&nbsp;
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
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img-container position-relative overflow-hidden">
                                        <img class="product-img" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                        <div class="product-action">
                                            <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                                <i class="fa fa-shopping-cart"></i>
                                            </button>
                                            &nbsp;&nbsp;
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
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img-container position-relative overflow-hidden">
                                        <img class="product-img" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                        <div class="product-action">
                                            <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                                <i class="fa fa-shopping-cart"></i>
                                            </button>
                                            &nbsp;&nbsp;
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
                    <asp:Repeater ID="Repeater4" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img-container position-relative overflow-hidden">
                                        <img class="product-img" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                        <div class="product-action">
                                            <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                                <i class="fa fa-shopping-cart"></i>
                                            </button>
                                            &nbsp;&nbsp;
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
                    <asp:Repeater ID="Repeater5" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                                <div class="product-item bg-light mb-4">
                                    <div class="product-img-container position-relative overflow-hidden">
                                        <img class="product-img" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                        <div class="product-action">
                                            <button class="btn btn-outline-dark btn-square" onclick="addToCart('<%# Eval("Id") %>');">
                                                <i class="fa fa-shopping-cart"></i>
                                            </button>
                                            &nbsp;&nbsp;
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
                </div>
            </div>
            <!-- Shop Product End -->
        </div>
    </div>
    <!-- Shop End -->

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


<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>



