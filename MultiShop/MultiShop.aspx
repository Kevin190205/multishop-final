<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="MultiShop.aspx.cs" Inherits="MultiShop.MultiShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-img-container {
            width: 200px; /* Set your desired width */
            height: 200px; /* Set your desired height */
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
    <!-- Carousel Start -->
    <div class="container-fluid mb-3">
        <div class="row px-xl-5">
            <div class="col-lg-8">
                <div id="header-carousel" class="carousel slide carousel-fade mb-30 mb-lg-0 " data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#header-carousel" data-slide-to="0" class="active"></li>
                        <li data-target="#header-carousel" data-slide-to="1"></li>
                        <li data-target="#header-carousel" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="carousel-item position-relative active" style="height: 430px;">
                            <img class="position-absolute w-100 h-100" src="img/carousel-1.jpg" style="object-fit: cover;">
                            <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                                <div class="p-3" style="max-width: 700px;">
                                    <h1 class="display-4 text-white mb-3 animate__animated animate__fadeInDown">Men Fashion</h1>
                                    <p class="mx-md-5 px-5 animate__animated animate__bounceIn">
                                        Lorem rebum magna amet lorem magna erat diam stet. Sadips duo stet amet amet ndiam elitr ipsum diam
                                    </p>
                                    <a class="btn btn-outline-light py-2 px-4 mt-3 animate__animated animate__fadeInUp" href="shop.aspx">Shop Now</a>
                                </div>
                            </div>
                        </div>
                        <div class="carousel-item position-relative" style="height: 430px;">
                            <img class="position-absolute w-100 h-100" src="img/carousel-2.jpg" style="object-fit: cover;">
                            <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                                <div class="p-3" style="max-width: 700px;">
                                    <h1 class="display-4 text-white mb-3 animate__animated animate__fadeInDown">Women Fashion</h1>
                                    <p class="mx-md-5 px-5 animate__animated animate__bounceIn">
                                        Lorem rebum magna amet lorem magna erat diam stet. Sadips duo stet amet amet ndiam elitr ipsum diam
                                    </p>
                                    <a class="btn btn-outline-light py-2 px-4 mt-3 animate__animated animate__fadeInUp" href="shop.aspx">Shop Now</a>
                                </div>
                            </div>
                        </div>
                        <div class="carousel-item position-relative" style="height: 430px;">
                            <img class="position-absolute w-100 h-100" src="img/carousel-3.jpg" style="object-fit: cover;">
                            <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                                <div class="p-3" style="max-width: 700px;">
                                    <h1 class="display-4 text-white mb-3 animate__animated animate__fadeInDown">Kids Fashion</h1>
                                    <p class="mx-md-5 px-5 animate__animated animate__bounceIn">
                                        Lorem rebum magna amet lorem magna erat diam stet. Sadips duo stet amet amet ndiam elitr ipsum diam
                                    </p>
                                    <a class="btn btn-outline-light py-2 px-4 mt-3 animate__animated animate__fadeInUp" href="shop.aspx">Shop Now</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="product-offer mb-30" style="height: 200px;">
                    <img class="img-fluid" src="img/offer-1.jpg" alt="">
                    <div class="offer-text">
                        <h6 class="text-white text-uppercase">Save 20%</h6>
                        <h3 class="text-white mb-3">Special Offer</h3>
                        <a href="shop.aspx" class="btn btn-primary">Shop Now</a>
                    </div>
                </div>
                <div class="product-offer mb-30" style="height: 200px;">
                    <img class="img-fluid" src="img/offer-2.jpg" alt="">
                    <div class="offer-text">
                        <h6 class="text-white text-uppercase">Save 20%</h6>
                        <h3 class="text-white mb-3">Special Offer</h3>
                        <a href="shop.aspx" class="btn btn-primary">Shop Now</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Carousel End -->


    <!-- Featured Start -->
    <div class="container-fluid pt-5">
        <div class="row px-xl-5 pb-3">
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center bg-light mb-4" style="padding: 30px;">
                    <h1 class="fa fa-check text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">Quality Product</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center bg-light mb-4" style="padding: 30px;">
                    <h1 class="fa fa-shipping-fast text-primary m-0 mr-2"></h1>
                    <h5 class="font-weight-semi-bold m-0">Free Shipping</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center bg-light mb-4" style="padding: 30px;">
                    <h1 class="fas fa-exchange-alt text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">14-Day Return</h5>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-12 pb-1">
                <div class="d-flex align-items-center bg-light mb-4" style="padding: 30px;">
                    <h1 class="fa fa-phone-volume text-primary m-0 mr-3"></h1>
                    <h5 class="font-weight-semi-bold m-0">24/7 Support</h5>
                </div>
            </div>
        </div>
    </div>
    <!-- Featured End -->


    <!-- Categories Start -->
    <div class="container-fluid pt-5">
        <h2 class="section-title position-relative text-uppercase mx-xl-5 mb-4"><span class="bg-secondary pr-3">Categories</span></h2>
        <div class="row px-xl-5 pb-3">


            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" ID="shirt" CssClass="text-decoration-none" OnClick="Unnamed2_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="img/s1.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>Man's shirts</h6>
            </div>
            </div>
                </asp:LinkButton>
            </div>

            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed2_Click1">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/jeans.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>Jeans</h6>
            </div>
            </div>
                </asp:LinkButton>
            </div>

            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed3_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/swim.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>Swimwear</h6>
            </div>
            </div>
                </asp:LinkButton>
            </div>


           

            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed5_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/sport.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>SportsWear</h6>
            </div>
            </div>
                </asp:LinkButton>
            </div>


            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed6_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/jumo.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>JumpSuits</h6>
            </div>
            </div>
                </asp:LinkButton>
            </div>


            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed7_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/blazer.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>Blazers</h6>

            </div>
            </div>
                </asp:LinkButton>
            </div>


            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed8_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/jackets.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>Jackets</h6>
            </div>
            </div>
                </asp:LinkButton>
            </div>


            <div class="col-lg-3 col-md-4 col-sm-6 pb-1">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="Unnamed9_Click">
            <div class="cat-item img-zoom d-flex align-items-center mb-4">
            <div class="overflow-hidden" style="width: 100px; height: 100px;">
            <img class="img-fluid" src="image/shoes.jpeg" alt="">
            </div>
            <div class="flex-fill pl-3">
            <h6>Shoes</h6>

            </div>
            </div>
                </asp:LinkButton>
            </div>


            



        </div>
    </div>
    <!-- Categories End -->


    
    <!-- Products Start -->
    <div class="container-fluid pt-5 pb-3">
        <h2 class="section-title position-relative text-uppercase mx-xl-5 mb-4"><span class="bg-secondary pr-3">Recent Products</span></h2>
        <div class="row px-xl-5">
            <asp:Repeater ID="ProductRepeater" runat="server" OnItemCommand="ProductRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                        <div class="product-item bg-light mb-4">
                            <div class="product-img-container position-relative overflow-hidden">
                                <img class="product-img img-fluid"
                                    src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("Product_image")) %>'
                                    alt="Product Image" />

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

                                
                                                                    <div>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# 
                                        Eval("Id") %>' CommandName="cmd_detail" >View Details</asp:LinkButton> 
                                    </div>

                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!-- Products End --

    <!-- Offer Start -->
    <div class="container-fluid pt-5 pb-3">
        <div class="row px-xl-5">
            <div class="col-md-6">
                <div class="product-offer mb-30" style="height: 300px;">
                    <img class="img-fluid" src="img/offer-1.jpg" alt="">
                    <div class="offer-text">
                        <h6 class="text-white text-uppercase">Save 20%</h6>
                        <h3 class="text-white mb-3">Special Offer</h3>
                        <a href="shop.aspx" class="btn btn-primary">Shop Now</a>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="product-offer mb-30" style="height: 300px;">
                    <img class="img-fluid" src="img/offer-2.jpg" alt="">
                    <div class="offer-text">
                        <h6 class="text-white text-uppercase">Save 20%</h6>
                        <h3 class="text-white mb-3">Special Offer</h3>
                        <a href="shop.aspx" class="btn btn-primary">Shop Now</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Offer End -->

>


        <!-- Products Start -->
    <div class="container-fluid pt-5 pb-3">
        <h2 class="section-title position-relative text-uppercase mx-xl-5 mb-4"><span class="bg-secondary pr-3">Featured Products</span></h2>
        <div class="row px-xl-5">
            <asp:Repeater ID="featureRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-2 col-md-4 col-sm-6 pb-1">
                        <div class="product-item bg-light mb-4">
                            <div class="product-img position-relative overflow-hidden">
                                <img class="img-fluid w-100" src='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("F_Product_image")) %>' alt="Product Image" style="max-width: 500px; max-height: 550px;" />
                                <div class="product-action">
                                </div>
                            </div>
                            <div class="text-center py-4">
                                <a class="h6 text-decoration-none text-truncate" href=""><%# Eval("F_Product_name") %></a>
                                <div class="d-flex align-items-center justify-content-center mt-2">
                                    <h5>$<%# Eval("F_Price") %></h5>
                                    <h6 class="text-muted ml-2"><del>$<%# Eval("F_Del_Price") %></del></h6>
                                </div>
                                <div class="d-flex align-items-center justify-content-center mb-1">
                                    <small class="fa fa-star text-primary mr-1"></small><small class="fa fa-star text-primary mr-1"></small><small class="fa fa-star text-primary mr-1"></small><small class="fa fa-star text-primary mr-1"></small><small class="fa fa-star text-primary mr-1"></small><small>(99)</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!-- Products End -->


    <!-- Vendor Start -->
    <div class="container-fluid py-5">
        <div class="row px-xl-5">
            <div class="col">
                <div class="owl-carousel vendor-carousel">
                    <div class="bg-light p-4">
                        <img src="img/vendor-1.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-2.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-3.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-4.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-5.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-6.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-7.jpg" alt="">
                    </div>
                    <div class="bg-light p-4">
                        <img src="img/vendor-8.jpg" alt="">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Vendor End -->




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

        function AddToProduct(productId)
        {
            $.ajax({
                url: 'AddToWishlist.aspx?productId=' + productId,
                type: 'GET',
                success: function (response) {
                    // Handle the response if needed
                    <asp:HyperLink ID="HyperLinkLogin" runat="server" NavigateUrl="~/Detail.aspx"></asp:HyperLink></p >

                },
                error: function (xhr, status, error) {
                    // Handle errors if any
                    console.error('Error Find product ', error);
                }
            });
        }
    </script>



</asp:Content>
<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>

