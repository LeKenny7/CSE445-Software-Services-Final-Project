<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Proj5.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
        .auto-style2 {
            font-size: medium;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member
            Registration</h1>
            *Register as a member to recieve access to our Members Page!<br />
            <p class="auto-style2">
                Testing</p>
            <p>
                <span class="auto-style1">- If the account already exists then the program will cause an event that is handled by the Global.asax to redirect to an error page explaing the Duplicate Account Error.</span><br class="auto-style1" />
            </p>
            <p>
                <span class="auto-style1">- If account information is unique it will add the credentials to the corresponding xml file</span><br />
            <br />
            Username:<br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
                <br />
            <br />
            </p>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Have an Account? Login!</asp:LinkButton>
    </form>
</body>
</html>
