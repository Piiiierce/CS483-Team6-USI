<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchReservation.aspx.cs" Inherits="Senior_Project.ResearchReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Calendar</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Projects</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Your Schedule</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">Account</asp:LinkButton>
            <br />
            <br />
            <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID WHERE ([User].Email = @Email)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label4" Name="Email" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name, Reservation.Date, Reservation.StartTime, Reservation.EndTime FROM Project INNER JOIN Reservation ON Project.ProjectID = Reservation.ProjectID WHERE (Reservation.Date = @Date) AND (Reservation.ManagerApprove = 1)" InsertCommand="INSERT INTO Reservation(ReservationId, StartTime, EndTime, Status, isRecruit, isEmail, ProjectID, ManagerApprove, Date, Occupancy) VALUES (@ReservationId, @StartTime, @EndTime, @Status, @isRecruit, @isEmail, @ProjectID, @ManagerApprove, @Date, @Occupancy)">
                <InsertParameters>
                    <asp:Parameter Name="ReservationId" />
                    <asp:Parameter Name="StartTime" />
                    <asp:Parameter Name="EndTime" />
                    <asp:Parameter Name="Status" />
                    <asp:Parameter Name="isRecruit" />
                    <asp:Parameter Name="isEmail" />
                    <asp:Parameter Name="ProjectID" />
                    <asp:Parameter Name="ManagerApprove" />
                    <asp:Parameter Name="Date" />
                    <asp:Parameter Name="Occupancy" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="Date" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Date:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Start Time:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Time" format="HH:mm"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="End Time:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Time" format="HH:mm"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Occupancy:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
