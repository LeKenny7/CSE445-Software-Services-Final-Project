<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Proj5.Staff.Staff" %>
<%@ Register TagPrefix = "cse" TagName="loginName" src="CurrentUsername.ascx" %>
    
    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cse:loginName runat = "server" />
        <div>
            STAFF<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign Out" />
        </div>
    </form>
</body>
</html>
