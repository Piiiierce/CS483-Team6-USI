<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSchedule.aspx.cs" Inherits="Senior_Project.StudentSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Account</asp:LinkButton>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="RecordLocation" HeaderText="RecordLocation" SortExpression="RecordLocation" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" DataFormatString="{0:hh':'mm}" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name, Project.RecordLocation, Reservation.Date, Reservation.StartTime, Reservation.EndTime FROM [User] INNER JOIN StudentReserve ON [User].SubjectID = StudentReserve.StudentID INNER JOIN Reservation ON StudentReserve.ReservationID = Reservation.ReservationId INNER JOIN Project ON Reservation.ProjectID = Project.ProjectID WHERE ([User].SubjectID = (SELECT SubjectID FROM [User] AS User_1 WHERE (Email = @Email)))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label4" Name="Email" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
