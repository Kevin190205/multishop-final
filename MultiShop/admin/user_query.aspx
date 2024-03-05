<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="user_query.aspx.cs" Inherits="MultiShop.admin.user_query" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .delete {
            padding: 5px 10px;
            border-radius: 5px;
            background-color: skyblue;
            color: white;
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
                    <h3 class="mb-4">User Queries</h3>
                    <div class="card general-settings border-0 shadow-sm mb-4">
                        <div class="card-body">
                            <div class="text-end mb-4">
                                <asp:LinkButton ID="lnkDeleteAll" runat="server" CssClass="btn btn-danger rounded-pill shadow-none"
                                    OnClick="lnkDeleteAll_Click">
                                    <i class="bi bi-trash-fill"></i> Delete All
                                </asp:LinkButton>
                            </div>
                            <div class="table-responsive-md" style="height: 450px; overflow-y: scroll;">
                                <table class="table table-hover border">
                                    <thead class="sticky-top">
                                        <tr class="bg-dark text-light">
                                            <th scope="col">#</th>
                                            <th scope="col">Name</th>
                                            <th scope="col">Email</th>
                                            <th scope="col" width="20%">Subject</th>
                                            <th scope="col" width="20%">Message</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="users-data">
                                        <asp:Repeater ID="UserRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("Id") %></td>
                                                    <td><%# Eval("Name") %></td>
                                                    <td><%# Eval("Email") %></td>
                                                    <td><%# Eval("Subject") %></td>
                                                    <td><%# Eval("Message") %></td>
                                                    <td>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%# Eval("Id") %>' CssClass="delete">Delete</asp:LinkButton>
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

</asp:Content>


