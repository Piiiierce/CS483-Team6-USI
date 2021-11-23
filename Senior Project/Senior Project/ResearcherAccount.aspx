<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResearcherAccount.aspx.cs" Inherits="Senior_Project.ResearcherAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
    <link href="../Content/studentview.css" rel="stylesheet">
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
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" OnClick="LinkButton1_Click">Calendar</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button" OnClick="LinkButton2_Click">Your Schedule</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="button" OnClick="LinkButton3_Click">Create Reservation</asp:LinkButton>
                </div>
                <div class="d-flex sidecontent">
                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="button" OnClick="LinkButton4_Click">Your Projects</asp:LinkButton>
                </div>
            </div>
        </div>

        <div class="bg-white border rounded border-dark container content-wrapper">
            <table class="container justify-content-center">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Major:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="Address:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label10" runat="server" Text="ZIP:"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
                    </td>


                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Current Password:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label19" runat="server" Text="New Password:"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="Confirm New Password:"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        <br />
                        <br />

                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Change Password" />
                    </td>
                </tr>
            </table>
        </div>
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
        
   
    </form>
</body>
</html>
