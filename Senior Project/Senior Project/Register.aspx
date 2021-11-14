<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Senior_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RCOB Registration</title>
    <meta charset="utf-8">
    <link href="../Content/register.css" rel="stylesheet">
    <!-- Add bootstrap; online reference for most updated version -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
</head>

<body class="background">
    <form id="form1" runat="server" class="register-box bg-white border rounded border-dark">
        <div class="container d-flex justify-content-center">

            <table class="container d-flex justify-content-center">
                <tr>
                    <td colspan="2">
                        <div class="d-flex justify-content-center mt-2 mb-2">
                            <h2>Sign Up</h2>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td>
                        <b>First Name:</b>
                    </td>
                    <td>
                            <asp:TextBox ID="TextBox1" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td><b>Last Name:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Student ID:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Email<b>:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Height="31px" Width="211px" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password<b>:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Height="31px" Width="211px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Confirm Password:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Height="31px" Width="211px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Gender:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="211px">
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><b>Type:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList4" runat="server" Width="211px">
                            <asp:ListItem>Select Type</asp:ListItem>
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Researcher</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><b>Date of Birth:</b></td>
                    <td>

                        <asp:TextBox ID="TextBox11" runat="server" Height="31px" Width="211px" TextMode="Date"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td><b>Major:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="31px" Width="211px">
                            <asp:ListItem>Select Major</asp:ListItem>
                            <asp:ListItem>Accounting</asp:ListItem>
                            <asp:ListItem>Business</asp:ListItem>
                            <asp:ListItem>Computer Science</asp:ListItem>
                            <asp:ListItem>Economics</asp:ListItem>
                            <asp:ListItem>Engineering</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><b>Enrollment Date:</b></td>
                    <td>

                        <asp:TextBox ID="TextBox12" runat="server" Height="31px" Width="211px" TextMode="Date"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td><b>GPA:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" Height="31px" Width="211px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Address:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>ZIP:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" Height="31px" Width="211px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Payment Type:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server">
                            <asp:ListItem>Select Payment Type</asp:ListItem>
                            <asp:ListItem>Cash</asp:ListItem>
                            <asp:ListItem>CashApp</asp:ListItem>
                            <asp:ListItem>Check</asp:ListItem>
                            <asp:ListItem>Paypal</asp:ListItem>
                            <asp:ListItem>Venmo</asp:ListItem>
                            <asp:ListItem>Zelle</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><b>Payment Info:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="pt-3">
                        <asp:Button ID="Button1" runat="server" Text="Register" Font-Bold="True" Font-Size="Large" Height="35px" Width="140px" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>

            </table>
        </div>
        <div class="container d-flex justify-content-center">
            <a href="Login Page.aspx">Already have an account?</a>
        </div>
    </form>
</body>
</html>
