<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login Page.aspx.cs" Inherits="Senior_Project.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RCOB Lab Reservation</title>
    <meta charset="utf-8">
    <link href="../Content/login.css" rel="stylesheet">
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
</head>

<body class="bg-image background">
    <!-- Begin login container -->
    <div class="login-box bg-white border rounded border-dark">
        <!-- Red header line -->
        <div class="header format-text border-bottom border-dark d-flex justify-content-center">
            <h2>RCOB Lab Management Portal</h2>  
        </div>
        <!-- Filler text (for now) -->
        <div class="format-text border-bottom border-dark justify-content-around p-1">
                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text 
                ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived 
                not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 
                1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like
                Aldus PageMaker including versions of Lorem Ipsum.    
        </div>
        <!-- Begin buttons/textboxes form-->
        <form id="form1" runat="server" class="container mt-1 h-100 d-flex justify-content-center align-content-end">
            <div>
                <!-- Username label -->
                <div class="d-flex justify-content-center mt-1">
                    <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
                </div>
                <!-- Username textbox -->
                <div class="d-flex justify-content-center mt-1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <!-- Password Label -->
                <div class="d-flex justify-content-center mt-1">
                    <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
                </div>
                <!-- Password textbox -->
                <div class="d-flex justify-content-center mt-1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
                <!-- Login button -->
                <div class="d-flex justify-content-center mt-2">
                    <asp:Button ID="Label3" runat="server" OnClick="Button1_Click" Text="Login" />
                </div>
                <!-- Registeration page link -->
                <div class="link-primary d-flex justify-content-center mt-2">
                    <a href="Register.aspx">Click here to register</a>
                </div>
                <!-- Reset password link -->
                <div class="link-primary d-flex justify-content-center">
                    <a href="">Reset password</a>
                </div>
            </div>
        </form>
    </div>
    <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label>
</body>
</html>
