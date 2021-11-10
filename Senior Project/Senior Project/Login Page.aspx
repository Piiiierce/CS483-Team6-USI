<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login Page.aspx.cs" Inherits="Senior_Project.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign In" />
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register</asp:LinkButton>
            <br />
            <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
        &nbsp;</div>
    </form>
</body>
</html>
