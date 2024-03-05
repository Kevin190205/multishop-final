<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="MultiShop.admin.Setting" %>

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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%@ Register Src="~/admin/inc/header.ascx" TagName="Header" TagPrefix="uc" %>
    <uc:Header runat="server" />
</asp:Content>

<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

    <body>

        <div class="container-fluid admin-panel-dashboard__main-content" id="admin-panel-content">
            <div class="row main-content">
                <div class="col-lg-10 ms-auto p-4">
                    <h3 class="mb-4">SETTINGS</h3>

                    <!-- GENERAL SETTINGS -->
                    <div class="card general-settings border-0 shadow-sm mb-4">
                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between mb-3">
                                <h5 class="card-title mb-0">General Settings</h5>
                                <div class="text-end mb-3">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark shadow-none btn-sm" Text="Edit" OnClientClick="openPopup(); return false;" />
                                </div>
                            </div>
                            <div class="d-flex flex-column gap-2 ">
                                <div>
                                    <h6 class="card-subtitle mb-1 fw-bold">Site Title</h6>
                                    <p class="card-text" id="site-title-content">
                                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label><asp:Label ID="Label9" runat="server" Text=""></asp:Label></p>
                                </div>
                                <div>
                                    <h6 class="card-subtitle mb-1 fw-bold">About us</h6>
                                    <p class="card-text" id="site-about-content">
                                        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></p>
                                </div>
                            </div>
                        </div>
                    </div>



                    <!-- CONTACT SETTINGS -->
                    <div class="card general-settings border-0 shadow-sm mb-4">
                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between mb-3">
                                <h5 class="card-title mb-0">Contact Settings</h5>
                                <div class="text-end mb-3">
                                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-dark shadow-none btn-sm" Text="Edit" OnClientClick="openPopup1(); return false;" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="mb-4">
                                        <h6 class="card-subtitle mb-2 fw-bold">Location</h6>
                                        <p class="card-text" id="address">
                                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></p>
                                    </div>
                                    
                                    <div class="mb-4">
                                        <h6 class="card-subtitle mb-2 fw-bold">Phone Numbers</h6>
                                        <div class="d-flex flex-column gap-1">
                                            <p class="card-text m-0" id="phone">
                                                <i class="bi bi-telephone-fill"></i>
                                                <span id="pn1">
                                                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></span>
                                            </p>
                                            
                                        </div>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-subtitle mb-2 fw-bold">Email</h6>
                                        <p class="card-text" id="email">
                                            <i class="bi bi-envelope-fill"></i>
                                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                        </p>
                                    </div>
                                    <div class="mb-4">
                                        <h6 class="card-subtitle mb-2 fw-bold">Customer Services Phone Number</h6>
                                        <div class="d-flex flex-column gap-1">
                                            <p class="card-text m-0" id="phone">
                                                <i class="bi bi-telephone-fill"></i>
                                                <span id="pn1">
                                                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></span>
                                            </p>
                                            
                                        </div>
                                    </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    <!--Newsletter-->
                    <div class="card general-settings border-0 shadow-sm mb-4">
                        <div class="card-body">
                            <div class="d-flex align-items-center justify-content-between mb-3">
                                <h5 class="card-title mb-0">General Settings</h5>
                                <div class="text-end mb-3">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-dark shadow-none btn-sm" Text="Edit" OnClientClick="openPopup2(); return false;" />
                                </div>
                            </div>
                            <div class="d-flex flex-column gap-2 ">
                                <div>
                                    <h6 class="card-subtitle mb-1 fw-bold">Newsletter</h6>
                                    <p class="card-text" id="site-title-content1">
                                        <asp:Label ID="Label15" runat="server" Text=""></asp:Label></p>
                                </div>
                                
                                <br /><br />

                                <div class="table-responsive-lg" style="height: 450px; overflow-y: scroll;">
                            <table class="table table-hover border">
                                <thead class="sticky-top">
                                    <tr class="bg-dark text-light">
                                        <th scope="col">#</th>
                                        <th scope="col">Email</th>                                      
                                        <th scope="col">Remove Email</th>
                                    </tr>
                                </thead>
                                <tbody id="rooms-table-body">
                                    <asp:Repeater ID="UserRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Id") %></td>
                                                <td><%# Eval("Email") %></td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton3" runat="server"  CommandArgument='<%# Eval("Id") %>' CssClass="delete" OnClick="LinkButton3_Click">Delete</asp:LinkButton>
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
           </div>
    </body>


    <!-- GENERAL SETTINGS MODAL -->
<div id="loginPopup" class="popup">
    <div class="popup-content">
        <div class="modal-body">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBox1" Text="Site Title1"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>           
                <div class="form-group">
                <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBox3" Text="Site Title2"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>  
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBox2" Text="Get In Touch"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>   
           </div>
        </div><br />
        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" onclick="closePopup()">Close</button>&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-primary" OnClick="LinkButton1_Click">Update</asp:LinkButton>
        </div>
    </div>
</div>

    <!-- CONTACT SETTINGS MODAL -->
<div id="about" class="popup">
    <div class="popup-content">
        <div class="modal-body">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" AssociatedControlID="TextBox4" Text="Location"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" AssociatedControlID="TextBox5" Text="Email"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" AssociatedControlID="TextBox6" Text="Contact"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" AssociatedControlID="TextBox7" Text="Customer Service"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div><br />
        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" onclick="closePopup1()">Close</button>&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-primary" OnClick="LinkButton2_Click">Update</asp:LinkButton>
        </div>
    </div>
</div>
     



    <!-- GENERAL Newsletter MODAL -->
<div id="Newsletter" class="popup">
    <div class="popup-content">
        <div class="modal-body">
            <div class="form-group">
                <asp:Label ID="Label16" runat="server" AssociatedControlID="TextBox8" Text="Newsletter"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
            </div>           
        </div><br />
        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" onclick="closePopup2()">Close</button>&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton4" runat="server"  CssClass="btn btn-primary" OnClick="LinkButton4_Click">Update</asp:LinkButton>
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

    <script>
        // Function to open the popup
        function openPopup1() {
            document.getElementById('about').style.display = 'block';
        }

        // Function to close the popup
        function closePopup1() {
            document.getElementById('about').style.display = 'none';
        }
    </script>

    <script>
        // Function to open the popup
        function openPopup2() {
            document.getElementById('Newsletter').style.display = 'block';
        }

        // Function to close the popup
        function closePopup2() {
            document.getElementById('Newsletter').style.display = 'none';
        }
    </script>


</asp:Content>


