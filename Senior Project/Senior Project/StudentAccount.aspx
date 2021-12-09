<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAccount.aspx.cs" Inherits="Senior_Project.StudentAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RCOB Lab Reservation</title>
    <meta charset="utf-8">
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/studentview.css" rel="stylesheet">
    <link href="../Content/master.css" rel="stylesheet">
    <style type="text/css">
        .auto-style1 {
            width: 464px;
        }
    </style>
</head>

<body class="background">


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
                    <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="button" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="button" OnClick="LinkButton2_Click">Your Schedule</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton3" runat="server"  CssClass="button" OnClick="LinkButton3_Click">Account</asp:LinkButton>
                </div>
                                                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton4" runat="server"  CssClass="button" OnClick="LinkButton4_Click">Log Out</asp:LinkButton>
                </div>

            </div>
        </div>

        <div class="bg-white border rounded border-dark container content-wrapper">
            <table class="d-flex container justify-content-center align-content-center m-1">
                <tr>
                    <td style="padding-right:10px;">
                            <asp:Label ID="Label5" runat="server" Text="Email:" CssClass="labelspacing"></asp:Label>
                            <br />
                            <asp:Label ID="Label7" runat="server" Text="Major:" CssClass="labelspacing"></asp:Label>
                            <br />
                        <asp:Label ID="Label8" runat="server" Text="GPA:" CssClass="labelspacing"></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Address:" CssClass="labelspacing"></asp:Label>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="ZIP:" CssClass="labelspacing"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Payment Type:" CssClass="labelspacing"></asp:Label>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="Payment Info:" CssClass="labelspacing"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <div class="d-flex justify-content-center">
                        <asp:Button ID="Button1" runat="server" Text="Update" CssClass="inputspacing" OnClick="Button1_Click" />
                        </div>
                    </td>
                    <td style="padding-left:10px; padding-right:10px;" class="auto-style1">
                        <asp:Label ID="Label17" runat="server" Text="Current Password:" CssClass="labelspacing"></asp:Label>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Current Password:" CssClass="labelspacing"></asp:Label>
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="Confirm New Password:"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="inputspacing"></asp:TextBox>
                        <div class="d-flex justify-content-center">
                        <asp:Button ID="Button2" runat="server" Text="Change Password" OnClick="Button2_Click"/>
                            </div>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>

</body>
</html>
