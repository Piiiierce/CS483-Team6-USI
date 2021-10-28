<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarStudent.aspx.cs" Inherits="Senior_Project.CalendarStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name, [User].Email, Reservation.Date, Reservation.StartTime, Reservation.EndTime FROM [User] INNER JOIN Notify ON [User].SubjectID = Notify.UserID INNER JOIN Reservation ON Notify.ReservationID = Reservation.ReservationId INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Reservation.ProjectID = Project.ProjectID AND Recruit.ProjectID = Project.ProjectID WHERE (Reservation.ReservationId = @ReservationId)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label3" Name="ReservationId" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
