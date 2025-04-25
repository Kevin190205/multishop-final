<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="myorder.aspx.cs" Inherits="MultiShop.detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .order_status {
            padding: 5px 10px;
            border-radius: 5px;
            background-color: green;
            color: white;
        }

        .Deactivate {
            padding: 5px 10px;
            border-radius: 5px;
            background-color: skyblue;
            color: white;
        }

        .delete {
            padding: 5px 10px;
            border-radius: 5px;
            background-color: deepskyblue;
            color: white;
        }

        .pdf {
            padding: 5px 10px;
            border-radius: 5px;
            background-color: yellowgreen;
            color: white;        
        }

        .order_status_processing {
            color: green; /* or any color you prefer */
        }

        .order_status_cancelled {
            color: red; /* or any color you prefer */
        }

        .order_status_shipped {
            color: yellowgreen;
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
                    <a class="breadcrumb-item text-dark" href="Miltishop.aspx">Home</a>
                    <a class="breadcrumb-item text-dark" href="shop.aspx">Shop</a>
                    <span class="breadcrumb-item active">My Order</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->

    <!-- Products Start -->
    <div class="container-fluid">
        <div class="row px-xl-5">
            <div class="col-lg-12 table-responsive mb-5">
                <table class="table table-hover border" style="min-width: 2200px;">
                    <thead class="thead-dark">
                        <tr>
                            <th>Order Id</th>
                            <th>Payment Id</th>
                            <th>Amount</th>
                            <th>Payment Status</th>
                            <th>Date Time</th>
                            <th>Order Status</th>
                            <th>Cancle Order</th>
                            <th>Invoice PDF</th>
                            <th>FirstName</th>
                            <th>Lastname</th>
                            <th>Email</th>
                            <th>Mobile No</th>
                            <th>Address1</th>
                            <th>Address2</th>
                            <th>Country</th>
                            <th>State</th>
                            <th>City</th>
                            <th>Pincode</th>
                        </tr>
                    </thead>
                    <tbody class="align-middle">
                        <asp:Repeater ID="myorder" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td><%# Eval("Orderid") %></td>
                                    <td><%# Eval("Paymentid") %></td>
                                    <td><%# Eval("Amount") %></td>
                                    <td><%# Eval("Status") %></td>
                                    <td><%# Eval("Date_Time") %></td>
                                    <td class='<%# GetOrderStatusColor(Eval("order_status")) %>'><%# Eval("order_status") %>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass='<%# GetButtonColor(Eval("order_status")) %>' OnClick="LinkButton1_Click " Enabled='<%# IsDeleteEnabled(Eval("order_status")) %>'>Cancel</asp:LinkButton>
                                    </td>
                                    <td align="center"> 
                                        <asp:Button ID="btnDownloadPDF" runat="server" Text="Download PDF Invoice" CommandArgument='<%# Eval("Id") %>' CssClass="pdf" OnClick="btnDownloadPDF_Click" />
                                    </td>
                                    <td><%# Eval("Firstname") %></td>
                                    <td><%# Eval("Lastname") %></td>
                                    <td><%# Eval("Email") %></td>
                                    <td><%# Eval("Mobile_no") %></td>
                                    <td><%# Eval("Address_1") %></td>
                                    <td><%# Eval("Address_2") %></td>
                                    <td><%# Eval("Country") %></td>
                                    <td><%# Eval("State") %></td>
                                    <td><%# Eval("City") %></td>
                                    <td><%# Eval("Pincode") %></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>                                                                                          
            </div>
            <div class="col-lg-4">
            </div>
        </div>
    </div>
    <!-- Products End -->






</asp:Content>


<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>



