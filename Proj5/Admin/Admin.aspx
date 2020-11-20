<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Proj5.Admin.Admin" %>
<%@ Register TagPrefix = "cse" TagName="loginName" src="../CurrentUsername.ascx" %>

    
    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cse:loginName runat = "server" />
        <div>
            ADMIN<br />
            Add username and passwords to staff.xml<br />
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
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sign Out" />
        </div>
    </form>
</body>
</html>
