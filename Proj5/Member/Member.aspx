<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Proj5.Member.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Page</h1>
            <br />
            In this page, you must introduce (explain) clearly what functions this page offers. You must allow users to register (self-subscribe) to obtain access to this page. For example, the account information page or the shopping cart page can be Member pages. An image verifier must be used when a new user signs up. You must create your own access control component and store the credentials in an XML file called Member.xml. Only the authenticated members can access this page. The password must be encrypted or hashed when adding into the XML files. You must use a local encryption/decryption or hash function that your team developed as a DLL library function. Calling the encryption/decryption/hashing Web service is not acceptable, as the password may be sent to the server in clear text. <br />
            <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Sign Out" OnClick="Button2_Click1" />
            <br />
            <br />
            <asp:Label ID="zipcodeLabel" runat="server" Text="Label"></asp:Label>
            <br />
            Please Enter Zipcode:<asp:TextBox ID="zipcodeTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Enter" runat="server" OnClick="Enter_Click" Text="Enter!" />
            <br />
            <br />
            Timezone:</div>
        <asp:Label ID="tz" runat="server"></asp:Label>
        <br />
        <asp:Label ID="weatherInfoLabel" runat="server" Text="Weather Info:"></asp:Label>
        <br />
    </form>
</body>
</html>
