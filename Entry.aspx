<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="Entry_Management_System.Entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entry Details</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center><h1>Enter Check-in Details</h1></center>
    <table style="margin-left:15%;margin-top:8%; background-color:#f2f2f2">
        <tr>
            <td style="width:20%"></td>
            <td colspan="3" style="height:36px">
               <center> <b>Enter your details</b> </center>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height:36px">
                Name
            </td>
            <td style="width:30%"></td>
            <td style="height:36px;width:22%">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="vis_name" CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="vis_name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height:36px">
                E-mail address
            </td>
            <td></td>
            <td style="height:36px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="vis_email" CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="vis_email" ErrorMessage="Enter a valid email address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height:36px">
                Phone No
            </td>
            <td></td>
            <td style="height:36px">
                +91<asp:TextBox ID="vis_phno" runat="server"  CssClass="txt" MaxLength="11"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Phone no. cannot be empty" ControlToValidate="vis_phno" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
        </tr>

        <tr>
            <td></td>
            <td colspan="3">
             <center><b>  Enter host details</b></center>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height:36px">
                Name
            </td>
            <td></td>
            <td style="height:36px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="host_name"  CssClass="txt" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Name cannot be empty" ControlToValidate="host_name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height:36px">
                E-mail address
            </td>
            <td></td>
            <td style="height:36px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="host_email" CssClass="txt"  runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="host_email" ErrorMessage="Enter a valid email address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="height:36px">
                Phone No
            </td>
            <td></td>
            <td style="height:36px">
                +91<asp:TextBox ID="host_phno" runat="server" CssClass="txt"  MaxLength="11"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Phone no. cannot be empty" ControlToValidate="host_phno" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <center>
                <br />
                    <asp:Button ID="entry_submit" runat="server" Text="Submit" CssClass="button button4" OnClick="entry_submit_Click" />
                    </center>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
