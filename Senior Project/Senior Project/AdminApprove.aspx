<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminApprove.aspx.cs" Inherits="Senior_Project.AdminApprove" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
                <link href="../Content/AdminApprove.css" rel="stylesheet" />
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
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button" OnClick="LinkButton2_Click">Approve/Deny</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="button" OnClick="LinkButton3_Click">User View</asp:LinkButton>
                </div>
                                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="button" OnClick="LinkButton4_Click">Log Out</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="bg-white border rounded border-dark adminapprove-wrapper">
            <br />
            <div class ="center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" PageSize="8">
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
                </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [User].FirstName, [User].LastName, Project.Name, Project.Sessions, Reservation.Date, Reservation.StartTime, Reservation.EndTime, Reservation.Occupancy FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID INNER JOIN Reservation ON Project.ProjectID = Reservation.ProjectID INNER JOIN Notify ON [User].SubjectID = Notify.UserID AND Reservation.ReservationId = Notify.ReservationID WHERE (Reservation.ManagerApprove = 0)" UpdateCommand="UPDATE Reservation SET ReservationId = @ReservationId">
                <UpdateParameters>
                    <asp:Parameter Name="ReservationId" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <div class="center">
            <asp:Button ID="Button1" runat="server" Text="Approve" Visible="False" OnClick="Button1_Click1" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Decline" Visible="False" OnClick="Button2_Click" />
                </div>
            <br />
            <br />
            <br />
            <br />
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;
        </div>
    </form>
</body>
</html>
