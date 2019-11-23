<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Entry_Management_System.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title>Home- Entry Management System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top:15%">
        <center>
          <h1>
            Entry Management System
        </h1>
        <table>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="button button4" Text="Enter Details" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Enter Check Out Time" CssClass="button button4" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
            </center>
    </div>
    </form>
</body>
</html>
