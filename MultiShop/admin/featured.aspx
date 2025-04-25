<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="featured.aspx.cs" Inherits="MultiShop.admin.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Style for the popup */
        .popup {
            display: none;
            position: fixed;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            z-index: 9999;
        }

        /* Style for the popup content */
        .popup-content {
            background-color: #fefefe;
            margin: 10% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
            max-width: 400px;
        }
        .Submit {
                padding: 5px 10px;
                border-radius: 5px;
                background-color: green; 
                color: white; 
            }
        .delete {
                padding: 5px 10px;
                border-radius: 5px;
                background-color: skyblue; 
                color: white; 
            }
    </style>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%@ Register Src="~/admin/inc/header.ascx" TagName="Header" TagPrefix="uc" %>
    <uc:Header runat="server" />
</asp:Content>

<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

    <div class="container-fluid admin-panel-rooms__main-content" id="admin-panel-content">
        <div class="row main-content">
            <div class="col-lg-10 ms-auto p-4">
                <h3 class="mb-4">Featured Product</h3>
                <div class="card border-0 shadow-sm mb-4">
                    <div class="card-body">
                        <div class="text-end mb-3">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark shadow-none btn-sm" Text="Add" OnClientClick="openPopup(); return false;" />
                        </div>
                        <div class="table-responsive-lg" style="height: 450px; overflow-y: scroll;">
                            <table class="table table-hover border">
                                <thead class="sticky-top">
                                    <tr class="bg-dark text-light">
                                        <th scope="col">#</th>
                                        <th scope="col">Product image</th>
                                        <th scope="col">Product name</th>
                                        <th scope="col">Price</th>
                                        <th scope="col">del Price</th>
                                        <th scope="col">Remove Product</th>
                                    </tr>
                                </thead>
                                <tbody id="rooms-table-body">
                                    <asp:Repeater ID="UserRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Id") %></td>
                                                <td>
                                                    <img src='data:image/jpeg;base64,<%# Convert.ToBase64String((byte[])Eval("F_Product_image")) %>' alt="Product Image" style="max-width: 60px; max-height: 70px;" />
                                                </td>
                                                <td><%# Eval("F_Product_name") %></td>
                                                <td><%# Eval("F_Price") %></td>
                                                <td><%# Eval("F_Del_Price") %></td>
                                                <td>
                                                     <asp:LinkButton ID="LinkButton2" runat="server"  CommandArgument='<%# Eval("Id") %>' CssClass="delete" OnClick="LinkButton2_Click">Delete</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>                            
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





    <div id="loginPopup" class="popup">
    <div class="popup-content">
        <div class="modal-body">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBox1" Text="Product Name"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBox2" Text="Price"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBox3" Text="Del Price"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group"><br />
                <asp:Label ID="Label4" runat="server" Text="Product Image"></asp:Label><br />
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
            </div>
        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" onclick="closePopup()">Close</button>&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-primary" OnClick="LinkButton1_Click">Submit</asp:LinkButton>
        </div>
    </div>
</div>



    <script>
        // Function to open the popup
        function openPopup() {
            document.getElementById('loginPopup').style.display = 'block';
        }

        // Function to close the popup
        function closePopup() {
            document.getElementById('loginPopup').style.display = 'none';
        }
    </script>

</asp:Content>


<asp:Content ID="Content7" runat="server" contentplaceholderid="ContentPlaceHolder3">

</asp:Content>



