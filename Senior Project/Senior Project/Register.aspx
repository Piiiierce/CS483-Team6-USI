<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Senior_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body style="height: 938px">
    <form id="form1" runat="server">
        <div>

            <table align="center" style="width: 700px; height: 600px; background-color: #6699FF">
                <tr>
                    <td colspan="2" align="center"><h2>Sign Up</h2></td>
                </tr>
                <tr>
                    <td style="width:50%"><b>First Name:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Last Name:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Student ID:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%">Email<b>:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Height="31px" Width="211px" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%">Password<b>:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Height="31px" Width="211px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Confirm Password:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Height="31px" Width="211px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Gender:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="220px">
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Type:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList4" runat="server" Width="220px">
                            <asp:ListItem>Select Type</asp:ListItem>
                            <asp:ListItem>Student</asp:ListItem>
                            <asp:ListItem>Researcher</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Date of Birth:</b></td>
                    <td>
                        
                        <asp:TextBox ID="TextBox11" runat="server" Height="31px" Width="211px" TextMode="Date"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Major:</b></td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="220px">
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
                    <td style="width:50%"><b>Enrollment Date:</b></td>
                    <td>
                        
                        <asp:TextBox ID="TextBox12" runat="server" Height="31px" Width="211px" TextMode="Date"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>GPA:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" Height="31px" Width="211px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Address:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>ZIP:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" Height="31px" Width="211px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%"><b>Payment Type:</b></td>
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
                    <td style="width:50%"><b>Payment Info:</b></td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" Height="31px" Width="211px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
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
    </form>
</body>
</html>
