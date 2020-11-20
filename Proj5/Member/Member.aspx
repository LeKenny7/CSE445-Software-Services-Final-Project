<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Proj5.Member.Member" %>
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
            MEMBER<br />
            <asp:Button ID="Button1" runat="server" Text="Home" />
            <asp:Button ID="Button2" runat="server" Text="Sign Out" />
        </div>
    </form>
</body>
</html>
