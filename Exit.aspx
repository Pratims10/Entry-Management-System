<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exit.aspx.cs" Inherits="Entry_Management_System.Exit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Enter check out time</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br /><br />
        <center>
            <h1>Enter Check-out details</h1>
    <table style="margin-left:9%;margin-top:10%;background-color:#f2f2f2">
        <tr><td colspan="5"><br /></td></tr>
        <tr>
            <td style="width:25%"></td>
            <td>
                Enter the meeting id sent to your email
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:TextBox ID="meeting_id" CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Meeting id cannot be empty" ControlToValidate="meeting_id" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            </tr>
        <tr>
            <td colspan="5">
                <br />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                Enter the check out time
            </td>
            <td></td>
            <td>
                    <input type="time"  id="chkout_time" runat="server" required/>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <center>
                <asp:Button ID="Button1" class="button button4" runat="server" Text="Submit" OnClick="Button1_Click" />
                    </center>
            </td>
        </tr>
    </table>
            </center>
    </div>
    </form>
</body>
</html>
