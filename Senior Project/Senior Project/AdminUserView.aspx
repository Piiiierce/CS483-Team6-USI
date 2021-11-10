<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUserView.aspx.cs" Inherits="Senior_Project.AdminUserView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Approve/Deny</asp:LinkButton>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SubjectID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SubjectID" HeaderText="SubjectID" ReadOnly="True" SortExpression="SubjectID" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:CheckBoxField DataField="Recruited" HeaderText="Recruited" SortExpression="Recruited" />
                    <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" SortExpression="PaymentType" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="DateofBirth" HeaderText="DateofBirth" SortExpression="DateofBirth" />
                    <asp:BoundField DataField="Major" HeaderText="Major" SortExpression="Major" />
                    <asp:BoundField DataField="EnrollmentDate" HeaderText="EnrollmentDate" SortExpression="EnrollmentDate" />
                    <asp:BoundField DataField="GPA" HeaderText="GPA" SortExpression="GPA" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="ZIP" HeaderText="ZIP" SortExpression="ZIP" />
                    <asp:BoundField DataField="PaymentInfo" HeaderText="PaymentInfo" SortExpression="PaymentInfo" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT SubjectID, FirstName, LastName, Recruited, PaymentType, Type, Email, Password, Gender, DateofBirth, Major, EnrollmentDate, GPA, Address, ZIP, PaymentInfo FROM [User] WHERE (Type != N'admin')"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;</div>
    </form>
</body>
</html>
