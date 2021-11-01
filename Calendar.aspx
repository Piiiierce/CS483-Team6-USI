<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Senior_Project.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Your Projects</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Your Schedule</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Create Reservation</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Account</asp:LinkButton>
            <br />
            <asp:Calendar ID="Calendar1" runat="server" CssClass="auto-style1" Height="335px" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Width="431px"></asp:Calendar>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
