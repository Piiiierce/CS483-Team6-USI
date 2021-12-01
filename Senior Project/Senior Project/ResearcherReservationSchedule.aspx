<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearcherReservationSchedule.aspx.cs" Inherits="Senior_Project.ResearcherReservationSchedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
            <link href="../Content/researcherview.css" rel="stylesheet" />
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
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button" OnClick="LinkButton2_Click">Your Projects</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="button" OnClick="LinkButton3_Click">Your Schedule</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="button" OnClick="LinkButton4_Click">Create Reservation</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="button" OnClick="LinkButton5_Click">Your Account</asp:LinkButton>
                </div>
                                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton6" runat="server" CssClass="button" OnClick="LinkButton6_Click">Log Out</asp:LinkButton>
                </div>

            </div>
        </div>

        <div class="bg-white border rounded border-dark researcher-schedule-wrapper">
            <br />
            <div class ="center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" AllowPaging="True" PageSize="5">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" DataFormatString="{0:hh':'mm}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="isRecruit" HeaderText="isRecruit" SortExpression="isRecruit" />
                    <asp:BoundField DataField="isEmail" HeaderText="isEmail" SortExpression="isEmail" />
                    <asp:BoundField DataField="Occupancy" HeaderText="Occupancy" SortExpression="Occupancy" />
                </Columns>
                <PagerSettings PageButtonCount="5" />
            </asp:GridView>
                </div>
            &nbsp;&nbsp;<br />
            <div class ="center">
            <asp:Label ID="Label11" runat="server" Text="Amount of Applicants"></asp:Label>
                </div>
            <div class ="center">

            <asp:TextBox ID="TextBox3" runat="server" BorderStyle="Solid" ReadOnly="True"></asp:TextBox>
                </div>
            <br />
            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name, Reservation.Date, Reservation.StartTime, Reservation.EndTime, Reservation.Status, Reservation.isRecruit, Reservation.isEmail, Reservation.Occupancy FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID INNER JOIN Reservation ON Project.ProjectID = Reservation.ProjectID WHERE ([User].SubjectID = (SELECT SubjectID FROM [User] AS User_1 WHERE (Email = @Email))) ORDER BY Reservation.Status DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label4" Name="Email" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <div class ="center">
            <asp:Button ID="Button2" runat="server" Text="Recruit" Visible="False" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" CssClass="auto-style3" OnClick="Button5_Click" Text="View Roster" Visible="False" />
                </div>
            <br />
            <div class ="center">
            <asp:ListBox ID="ListBox1" runat="server" CssClass="auto-style1" DataSourceID="SqlDataSource2" DataTextField="FirstName" DataValueField="Email" Height="224px" SelectionMode="Multiple" Visible="False" Width="184px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT FirstName, LastName, Email FROM [User] WHERE (Type = N'student')"></asp:SqlDataSource>
                </div>
            <br />
            <div class ="center">
            <asp:Button ID="Button4" runat="server" Text="Send Email" Visible="False" OnClick="Button4_Click" />
            <br />
                </div>
            <br />
            <div class ="center">
            <asp:ListBox ID="ListBox2" runat="server" CssClass="auto-style2" DataSourceID="SqlDataSource3" DataTextField="FirstName" DataValueField="Email" Height="213px" Visible="False" Width="187px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [User].FirstName, [User].LastName, [User].Email FROM [User] INNER JOIN StudentReserve ON [User].SubjectID = StudentReserve.StudentID WHERE (StudentReserve.ReservationID = @ReservationID) AND ([User].Type = N'student')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox2" Name="ReservationID" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
                </div>
            <br />
            <div class ="center">
            <asp:Button ID="Button3" runat="server" Text="Send Reminder Email" Visible="False" OnClick="Button3_Click" />
                </div>
            <br />
            <br />
            <br />
            <br />
            <div class ="center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel" Visible="False" />
                </div>
            <br />
            <br />
            <br />
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
        </div>
    </form>
</body>
</html>
