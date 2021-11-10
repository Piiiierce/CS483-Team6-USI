<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminApprove.aspx.cs" Inherits="Senior_Project.AdminApprove" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">User View</asp:LinkButton>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Sessions" HeaderText="Sessions" SortExpression="Sessions" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="Occupancy" HeaderText="Occupancy" SortExpression="Occupancy" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [User].FirstName, [User].LastName, Project.Name, Project.Sessions, Reservation.Date, Reservation.StartTime, Reservation.EndTime, Reservation.Occupancy FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID INNER JOIN Reservation ON Project.ProjectID = Reservation.ProjectID INNER JOIN Notify ON [User].SubjectID = Notify.UserID AND Reservation.ReservationId = Notify.ReservationID WHERE (Reservation.ManagerApprove = 0)" UpdateCommand="UPDATE Reservation SET ReservationId = @ReservationId">
                <UpdateParameters>
                    <asp:Parameter Name="ReservationId" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Approve" Visible="False" OnClick="Button1_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Decline" Visible="False" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;</div>
    </form>
</body>
</html>
