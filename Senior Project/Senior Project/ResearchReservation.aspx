<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchReservation.aspx.cs" Inherits="Senior_Project.ResearchReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Visible="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" DataFormatString="{0:hh':'mm}" />
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
            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="StartTime" DataValueField="StartTime" DataFormatString="{0:hh':'mm}"></asp:ListBox>
            <br />
            <br />
            <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource1" DataTextField="EndTime" DataValueField="EndTime" DataFormatString="{0:hh':'mm}"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            &nbsp;<br />
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Date:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Please Select a Date from the Calendar" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Start Time:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Time" format="HH:mm"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Please Enter Start Time" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="End Time:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Time" format="HH:mm"></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" Text="Please Enter End Time" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Occupancy:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Reservation" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
