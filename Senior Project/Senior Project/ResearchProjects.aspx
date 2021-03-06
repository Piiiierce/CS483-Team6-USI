<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchProjects.aspx.cs" Inherits="Senior_Project.ResearchProjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
    <link href="../Content/ProjectView.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            background-color: rgb(37, 150, 190);
            opacity: 1;
            position: absolute;
            width: 15%;
            height: 100vh;
            padding-top: 50px;
            left: 0px;
        }
    </style>
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

            <div class="auto-style1">
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

        <div class="bg-white border rounded border-dark projectview-wrapper">
            <br />
            <div class="center">
            <asp:GridView ID="GridView1" runat="server" CssClass=" " AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BorderStyle="Solid">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Sessions" HeaderText="Sessions" SortExpression="Sessions" />
                    <asp:BoundField DataField="RecordLocation" HeaderText="RecordLocation" SortExpression="RecordLocation" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name, Project.Sessions, Project.RecordLocation FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID WHERE ([User].SubjectID = (SELECT SubjectID FROM [User] AS User_1 WHERE (Email = @Email)))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label4" Name="Email" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
                </div>
            <br />
            <div class="center">
            <br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Project" />
                </div>
            <br />
            <div class="center">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete Project" Visible="False" />
                </div>
            <br />
            <br />
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
