<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Proj5.Staff.Staff" %>
<%@ Register TagPrefix = "cse" TagName="loginName" src="~/CurrentUsername.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

b,
strong {
  font-weight: bold;
}
* {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}
  *,
  *:before,
  *:after {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
    box-shadow: none !important;
  }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <cse:loginName runat = "server" />
        <div>
            <h1>Staff Page</h1>
            <p>
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Home" />
            </p>
            <p>&nbsp;</p>
            Thank you for signing up for our services as a Staff we are happy to have you! As Staff, you are allowed access to the Members page with our services and the Staff page where you can see the full list of Members; specifically, their username and encrypted password (for real-world security preferences). If no Staff accounts have been created, Admin (<strong>Username</strong>: <em>TA</em> <strong>Password</strong>: <em>Cse445ta!</em>) must login and create Staff accounts.<br />
            <br />
            <strong>Testing for Staff Page:</strong><br />
            - Press &quot;View Members&quot; to view a list of all current members and their encrypted passwords.<br style="font-weight: 700" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="View Members" />
            <br />
            <br />
            <asp:Label ID="xml" runat="server" Font-Overline="False"></asp:Label>
        </div>
    </form>
</body>
</html>
