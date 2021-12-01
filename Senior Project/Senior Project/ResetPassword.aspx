<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Senior_Project.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.2/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../Content/master.css" rel="stylesheet">
    <link href="../Content/ResetPassword.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial" class="center">
            <table style="border: 1px solid black; width:300px" class="bg-white border rounded border-dark schedule-wrapper">
                <tr>
                    <td colspan="2">
                        <b>Reset my password</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:
                    </td>    
                    <td>
                        <asp:TextBox ID="txtUserName" Width="150px" runat="server">
                        </asp:TextBox>
                    </td>    
                </tr>
                <tr>
                    <td>
                    
                    </td>    
                    <td>
                        <asp:Button ID="btnResetPassword" runat="server" 
                        Width="150px" Text="Reset Password" onclick="btnResetPassword_Click" />
                    </td>    
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
