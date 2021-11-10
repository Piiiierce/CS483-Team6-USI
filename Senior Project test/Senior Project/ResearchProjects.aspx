<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearchProjects.aspx.cs" Inherits="Senior_Project.ResearchProjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Your Schedule</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Create Reservation</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Account</asp:LinkButton>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Sessions" HeaderText="Sessions" SortExpression="Sessions" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Project.Name, Project.Sessions FROM [User] INNER JOIN Recruit ON [User].SubjectID = Recruit.SubjectID INNER JOIN Project ON Recruit.ProjectID = Project.ProjectID WHERE ([User].SubjectID = (SELECT SubjectID FROM [User] AS User_1 WHERE (Email = @Email)))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Label4" Name="Email" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Project" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete Project" Visible="False" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
