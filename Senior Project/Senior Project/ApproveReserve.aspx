<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveReserve.aspx.cs" Inherits="Senior_Project.ApproveReserve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
    <link href="../Content/ApproveReserve.css" rel="stylesheet">
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
        </div>

        <div class="bg-white border rounded border-dark reserve-wrapper">
            <br />
            <div class="center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Approve" />
            &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Decline" />
                </div>
            <br />
            <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;</div>
    </form>
</body>
</html>
