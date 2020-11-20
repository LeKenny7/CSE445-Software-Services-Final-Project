<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Proj5.Staff.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            STAFF<br />
            Access to this page is given by the administrator, who adds a staff member’s username and password into an XML file called Staff.xml. You can either use a GUI for the administrator to add the credentials, or let the administrator to open the Staff.xml to add the credentials. For allowing the TA to test this page, you must allow this staff credential to test this page: User name: “TA” and Password: “Cse445ta!”, excluding the quotes.
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign Out" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="View Members" />
            <br />
            <br />
            <asp:Label ID="xml" runat="server" Font-Overline="False"></asp:Label>
        </div>
    </form>
</body>
</html>
