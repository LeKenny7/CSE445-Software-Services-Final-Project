<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Proj5.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1">Custom Error Page From Global.asax EventHandler! Unable to make Duplicate Accounts! </h1>
        </div>
        <p style="text-align: center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
        </p>
    </form>
</body>
</html>
