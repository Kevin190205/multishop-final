<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="MultiShop.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
   
   <table style="width: 100%; border-collapse: collapse;">
    <tr>
        <!-- Left Side: Product Image -->
        <td style="width: 50%; text-align: center; vertical-align: middle;">
            <asp:Image ID="ProductImage" runat="server" Width="500px" Height="500px" />
        </td>

        <!-- Right Side: Product Details -->
        <td style="width: 50%; padding-left: 20px; vertical-align: top;">
           
            <div style="font-size: 20px; font-weight: bold;">
                <asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label>
                <asp:Label ID="N1" runat="server" Text=""></asp:Label>
            </div>

            <br />

            <div style="font-size: 20px; font-weight: bold;">
                <asp:Label ID="Label1" runat="server" Text="Detail: "></asp:Label>
                <asp:Label ID="Name" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div style="font-size: 20px; font-weight: bold;">
                <asp:Label ID="Label2" runat="server" Text="Discount Price: "></asp:Label>
                <asp:Label ID="Price" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div style="font-size: 20px; font-weight: bold; color: red;">
                <asp:Label ID="Label3" runat="server" Text="Real Price: "></asp:Label>
                <asp:Label ID="Dlprice" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div >
                <br />
                 <button class="" onclick="addToCart('<%# Eval("Id") %>');">
                        Add To Cart <i class="fa fa-shopping-cart"></i>
                 </button>
                
           </div>

<%--            <div>
                <asp:Button ID="Button2" runat="server" Text="addToCart" OnClick="addToCart('<%# Eval("Id") %>');" <i class="fa fa-shopping-cart"></i> 
            </div>--%>
            <br />
           <div >
                 <button class="" onclick="addToWishlist('<%# Eval("Id") %>');">
                         Add To wishlist <i class="far fa-heart"></i>
                 </button>
           </div>
        </td>
    </tr>
</table>


        <script>
            // Extract productId from URL query string
            const urlParams = new URLSearchParams(window.location.search);
            const productId = urlParams.get('pid'); // this will fetch `pid=20` from the URL

            function addToCart() {
                if (!productId) {
                    console.error('Product ID not found in URL.');
                    return;
                }

                $.ajax({
                    url: 'AddToCart.aspx?productId=' + productId,
                    type: 'GET',
                    success: function (response) {
                        console.log('Product added to cart successfully.');
                    },
                    error: function (xhr, status, error) {
                        console.error('Error adding product to cart:', error);
                    }
                });
            }

            function addToWishlist() {
                if (!productId) {
                    console.error('Product ID not found in URL.');
                    return;
                }

                $.ajax({
                    url: 'AddToWishlist.aspx?productId=' + productId,
                    type: 'GET',
                    success: function (response) {
                        console.log('Product added to wishlist successfully.');
                    },
                    error: function (xhr, status, error) {
                        console.error('Error adding product to wishlist:', error);
                    }
                });
            }
        </script>



            </asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
                
  <%@ Register Src="~/inc/Header.ascx" TagName="Header" TagPrefix="uc" %>
    <uc:Header runat="server" />
            </asp:Content>


