<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="MultiShop.admin.inc.header" %>

<!-- Remove the <head> tag from this file -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    

<!-- Bootstrap -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css" rel="stylesheet">
<!-- Google font: Merienda & Poppins -->
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Merienda:wght@400;700&family=Poppins:wght@400;500;600&display=swap" rel="stylesheet">
<!-- SwiperJs -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@8/swiper-bundle.min.css"/>

<!-- My CSS -->
<link href="stylesheet/global.css" rel="stylesheet" type="text/css"/>


<style>
    #admin-panel-menu {
        position: fixed;
        height: 100%;
    }        
</style>

<body>
    
        <div>
            <!-- Your form content goes here -->
            <div class="container-fluid bg-dark text-light p-3 d-flex justify-content-between align-items-center sticky-top">
                <a class="navbar-brand me-5 fw-bold fs-3 h-font" href="index.php">BOOKME</a>
                <a href="Logout.aspx" class="btn btn-light btn-sm">LOG OUT</a>
            </div>

            <div class="col-lg-2 bg-dark border-top border-3 border-secondary admin-panel-dashboard__menu z-index-big" id="admin-panel-menu">
                <nav class="navbar navbar-expand-lg navbar-dark" id="admin-panel-navbar">
                    <div class="container-fluid flex-lg-column align-items-stretch">
                        <h4 class="mt-2 text-light">ADMIN PANEL</h4>
                        <button class="navbar-toggler shadow-none" type="button" data-bs-toggle="collapse" data-bs-target="#adminDropdown" aria-controls="adminDropdown" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse flex-column align-items-stretch mt-2 gap-3" id="adminDropdown">
                            <ul class="nav nav-pills flex-column">
                                <li class="nav-item">
                                    <a class="nav-link text-white" href="Buy_Product.aspx"> Orders</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-white" href="Product.aspx">Product</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-white" href="featured.aspx">Featured Product</a>
                                </li>
                                
                                <li class="nav-item">
                                    <a class="nav-link text-white" href="user_query.aspx">User Queries</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link text-white" href="user.aspx">Users</a>
                                </li>
                                
                                <li class="nav-item">
                                    <a class="nav-link text-white" href="Setting.aspx">Settings</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
        </div>
    
</body>
