<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Proj5.Admin.Admin" %>
<%@ Register TagPrefix = "cse" TagName="loginName" src="~/CurrentUsername.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            font-size: medium;
            text-decoration: underline;
        }
        .auto-style1 {
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <cse:loginName runat = "server" />
        <div>
            <h1>Administration Creating Staff Accounts</h1>
            *Only for Admin to add staff user credentials (Username and Password) to Staff.XML<br />
            *Current/Only admin is <strong>Username:</strong> <em>TA</em> and <strong>Password:</strong> <em>Cse445ta!<br />
            </em>
            <p class="auto-style2">
                Testing</p>
            <p class="auto-style1">
                - If the account already exists then the program will cause an event that is handled by the Global.asax to redirect to an error page explaing the Duplicate Account Error.</p>
            <p class="auto-style1">
                - If account information is unique it will add the credentials to the corresponding xml file</p>
            <br />
            Username:<br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Staff Member" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
        </div>
    </form>
</body>
</html>
