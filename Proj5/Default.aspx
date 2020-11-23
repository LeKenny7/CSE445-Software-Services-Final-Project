<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proj5._Default" %>
<%@ Register TagPrefix = "cse" TagName="loginName" src="~/CurrentUsername.ascx" %>

    
    
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<cse:loginName runat = "server" />
    <p style="font-size: x-large">
        Default Page: </p>
    <p style="font-size: small">
        Members can Login (sign up) or Register (self-subscribe) to use our services (Timezone, Weather, and Population services) that take in a zipcode to provide them with the current timezone information and weather, as well as take in a city name to return the current population. Staff accounts are allowed access to the staff page where they can see the full list of members; specifically, their username and encrypted password (for real-world security preferences). The Admin page is restricted only for the Admin Account (<strong>Username</strong>: <em>TA</em> <strong>Password</strong>: <em>Cse445ta!</em>) to add Staff accounts.</p>
    <p style="font-size: small">
        &nbsp;</p>
    <p style="font-size: x-large">
        Testing:</p>
    <p style="font-size: small">
        *Admin account is included in both Member and Staff xml to have full access and at start of application one could register as Member (or multiple members) and then login as Admin to create Staff accounts and access one of the created accounts (not necessary considering Admin has full access) to view Staff page.</p>
    <p style="font-size: small">
        - Zipcode Service: sample input = &quot;85233&quot;</p>
    <p style="font-size: small">
        - Population Service: sample input &quot;Redding&quot;</p>
    <p style="font-size: small">
        - Admin Page can only be accessed if logged in as Username: TA Password: &quot;Cse445ta!&quot;</p>
    <p style="font-size: small">
        - Members only have access to the Members page</p>
    <p style="font-size: small">
        - Staff has access to the Members and Staff pages</p>
    <p style="font-size: small">
        - Admin has access to all pages</p>
    <p style="font-size: small">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -For security purposes, when attempting to access the Admin page (unless already signed in as Admin account) it will redirect to Login.&nbsp;</p>
    <p style="font-size: small">
        &nbsp;</p>
<p>
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Login" />
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Member Register" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Member Page" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Staff Page" />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Admin Page" />
</p>

</asp:Content>
