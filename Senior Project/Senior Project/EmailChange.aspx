<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailChange.aspx.cs" Inherits="Senior_Project.EmailChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
        <link href="../Content/EmailChange.css" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
                <div>
            <div class="sideheader d-flex justify-content-center align-content-center">
                <h1>Hello                
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </h1>
            </div>
            <div class="sidebar">
            </div>

            <div class="bg-white border rounded border-dark emailchange-wrapper">
                <div class="center">
                    <asp:Label ID="Label5" runat="server" Text="Label">You have successfully changed your email!</asp:Label>
                </div>
            <br />
            <br />
            <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;</div>
    </form>
</body>
</html>
