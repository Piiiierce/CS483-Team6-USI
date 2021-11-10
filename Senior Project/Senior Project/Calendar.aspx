﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Senior_Project.Calendar" %>

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
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" DataFormatString="{0:hh':'mm}" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [User].FirstName, [User].LastName, Project.Name, Reservation.Date, Reservation.StartTime, Reservation.EndTime FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID INNER JOIN Reservation ON Project.ProjectID = Reservation.ProjectID WHERE (Reservation.ManagerApprove = 1) AND (Reservation.Date = @Date)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="Date" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>