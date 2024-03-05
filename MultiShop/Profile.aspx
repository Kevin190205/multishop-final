<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MultiShop.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <a class="breadcrumb-item text-dark" href="MultiShop.aspx">Home</a>
                    <span class="breadcrumb-item active">Profile</span>
                </nav>
            </div>
        </div>
    </div>
    <!-- Breadcrumb End -->

    <!-- Profile Update Form -->
    <div class="container" align="center">
        <h2 class="section-title position-relative mx-auto mb-4"><span class="bg-secondary pr-3">User Profile</span></h2>
        <h6>Update Your Personal Details Below.</h6>
    </div>

    <div class="container-xl py-5">
        <div class="row">
            <!-- Edit Profile Section (Left Column) -->
            <div class="col-md-6">
                <h1>Edit Profile</h1>
                <br />
                <br />

                <div class="form-group">
                    <asp:Literal runat="server" ID="Literal1" Visible="true"></asp:Literal>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <!-- Profile Picture -->
                        <div class="text-center">
                            <asp:Image ID="Image1" runat="server" Height="80" Width="80" Style="border-radius: 50%; overflow: hidden;" />
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <asp:FileUpload ID="fileUploadControl" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <!-- Username Input -->
                        <div class="form-group">
                            <label for="username">UserName</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="username"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />

                <div class="form-group">
                    <label for="firstName">First Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="firstName"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="lastName">Last Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="lastName"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="email">Your Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="email" TextMode="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="address">Address</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="address"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="contactNo">Contact Number</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="contactNo"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="city">City</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="city"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="state">State</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="state"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Literal runat="server" ID="messageLiteral" Visible="false"></asp:Literal>

                </div>
                <div class="text-center">
                    <asp:Button runat="server" ID="updateButton" Text="Update Profile" CssClass="btn btn-primary" OnClick="updateButton_Click" />
                </div>
            </div>

            <!-- Change Password Section (Right Column) -->
            <div class="col-md-6">
                <asp:Panel runat="server" CssClass="container-xl py-6">
                    <div class="col-md-12 mx-auto">
                        <h1>Change Password</h1>
                        <br />
                        <br />
                        <div class="form-group">
                            <label for="oldPassword">Old Password</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="oldPassword" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="newPassword">New Password</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="newPassword" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="confirmPassword">Confirm Password</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="confirmPassword" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Literal runat="server" ID="messageLiteral2" Visible="true"></asp:Literal>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="changePasswordButton" Text="Change Password" CssClass="btn btn-primary" OnClick="changePasswordButton_Click" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function displaySelectedImage() {
            var fileUploadControl = document.getElementById('<%= fileUploadControl.ClientID %>');
        var image = document.getElementById('<%= Image1.ClientID %>');
            if (fileUploadControl.files && fileUploadControl.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    image.src = e.target.result;
                };
                reader.readAsDataURL(fileUploadControl.files[0]);
            }
        }
    </script>


</asp:Content>

<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <%@ Register Src="~/inc/Footer.ascx" TagName="Footer" TagPrefix="uc" %>
    <uc:Footer runat="server" />

</asp:Content>



