<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCalendar.aspx.cs" Inherits="Senior_Project.AdminCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Approve/Deny</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">User View</asp:LinkButton>
                        <br />
            <asp:Calendar ID="Calendar1" runat="server" CssClass="auto-style1" Height="335px" OnDayRender="Calendar1_DayRender" Width="431px"></asp:Calendar>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
