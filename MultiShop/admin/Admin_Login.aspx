<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="MultiShop.admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
        .admin-login-panel {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

            .admin-login-panel .login-form {
                min-width: 20rem;
                height: min-content;
            }

            .admin-login-panel .login-alert {
                position: absolute;
                bottom: 0;
            }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">

</head>
<body class="admin-login-panel bg-light">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> <!-- Add ScriptManager here -->
        <div class="login-form text-center rounded shadow bg-white overflow-hidden">
            <asp:Panel ID="LoginPanel" runat="server">
                <asp:UpdatePanel ID="LoginUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="LoginAlert" runat="server" CssClass="alert" Visible="false"></asp:Label>
                        <h4 class="bg-dark text-white py-4">ADMIN LOGIN PANEL</h4>
                        <div class="p-3">
                            <div class="mb-3">
                                <asp:TextBox ID="AdminNameTextBox" runat="server" CssClass="form-control shadow-none text-center" placeholder="Admin Name" required></asp:TextBox>
                            </div>
                            <div class="mb-4">
                                <asp:TextBox ID="AdminPassTextBox" runat="server" TextMode="Password" CssClass="form-control shadow-none text-center" placeholder="Password" required></asp:TextBox>
                            </div>
                            <asp:Button ID="LoginButton" runat="server" Text="LOGIN" BackColor="#66FF99" ForeColor="White" BorderWidth="5" BorderStyle="Double" Height="40" Width="100" OnClick="LoginButton_Click"/>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
