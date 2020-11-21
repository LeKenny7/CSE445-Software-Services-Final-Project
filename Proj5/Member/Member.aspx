<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Proj5.Member.Member" %>
<%@ Register TagPrefix = "cse" TagName="loginName" src="~/CurrentUsername.ascx" %>

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
            In this page, you must introduce (explain) clearly what functions this page offers. You must allow users to register (self-subscribe) to obtain access to this page. For example, the account information page or the shopping cart page can be Member pages. An image verifier must be used when a new user signs up. You must create your own access control component and store the credentials in an XML file called Member.xml. Only the authenticated members can access this page. The password must be encrypted or hashed when adding into the XML files. You must use a local encryption/decryption or hash function that your team developed as a DLL library function. Calling the encryption/decryption/hashing Web service is not acceptable, as the password may be sent to the server in clear text. <br />
            <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
