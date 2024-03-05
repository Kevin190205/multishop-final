<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="MultiShop.admin.inc.user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
</asp:Content>
<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%@ Register Src="~/admin/inc/header.ascx" TagName="Header" TagPrefix="uc" %>
    <uc:Header runat="server" />
</asp:Content>
<asp:Content ID="Content8" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

    <!DOCTYPE html>
    <html>
    <head>
        <title>Admin Panel - Users</title>
        <style>
            .Activate {
                padding: 5px 10px;
                border-radius: 5px;
                background-color: green; 
                color: white; 
            }

            .Deactivate {
                padding: 5px 10px;
                border-radius: 5px;
                background-color: red; 
                color: white; 
            }
             .delete {
                padding: 5px 10px;
                border-radius: 5px;
                background-color: skyblue; 
                color: white; 
            }
        </style>
    </head>
    <body>
        <div class="container-fluid admin-panel-rooms__main-content" id="admin-panel-content">
            <div class="row main-content">
                <div class="col-lg-10 ms-auto p-4">
                    <h3 class="mb-4">Users</h3>
                    <div class="card border-0 shadow-sm mb-4">
                        <div class="card-body">
                            <!-- serach box -->
                            <div class="text-end mb-3">
                                <input type="text" oninput="search_user(this.value)" class="form-control shadow-none w-25 ms-auto" placeholder="type to search...">
                            </div>
                            <div class="table-responsive">
                                <table class="table table-hover border" style="min-width: 1300px;">
                                    <thead class="sticky-top">
                                        <tr class="bg-dark text-light">
                                            <th>#</th>
                                            <th>profile</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Email</th>
                                            <th>address</th>
                                            <th>contact</th>
                                            <th>city</th>
                                            <th>state</th>
                                            <th>Status</th>
                                            <th>Username</th>
                                            <th>password</th>
                                            <th>Remove User</th>
                                        </tr>
                                    </thead>
                                    <tbody id="users-data">
                                        <asp:Repeater ID="UserRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("Id") %></td>
                                                    <td>
                                                        <img src='data:image/jpeg;base64,<%# Convert.ToBase64String((byte[])Eval("ImageData")) %>' alt="Profile Image" style="max-width: 40px; max-height: 50px;" />
                                                    </td>
                                                    <td><%# Eval("firstname") %></td>
                                                    <td><%# Eval("lastname") %></td>
                                                    <td><%# Eval("email") %></td>
                                                    <td><%# Eval("address") %></td>
                                                    <td><%# Eval("contact") %></td>
                                                    <td><%# Eval("city") %></td>
                                                    <td><%# Eval("state") %></td>
                                                    <td>
                                                        <asp:LinkButton ID="StatusButton" runat="server"
                                                            Text='<%# GetButtonCssClass(Eval("Status")) %>'
                                                            CommandName="ToggleStatus"
                                                            CommandArgument='<%# Eval("Id") %>'
                                                            CssClass='<%# GetButtonCssClass(Eval("Status")) %>'
                                                            OnCommand="StatusButton_Command" />

                                                    </td>
                                                    <td><%# Eval("username") %></td>
                                                    <td><%# Eval("password") %></td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%# Eval("Id") %>' CssClass="delete" >Delete</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
    </html>
                                                        
                                                        

</asp:Content>






