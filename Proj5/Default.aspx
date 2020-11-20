<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proj5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
    <br />
    MAIN</p>
    <p>
        Default page. This is a public page. You must introduce clearly what functionality the application offers, how end users can sign up for the services, how the users (TA) can test this application, and what are the test cases/inputs. The page must contain a button to access the “Member” page and a button to access the “Staff” page. Login redirection must be implemented in the access controls: If the user is not logged in, the Login page will be activated. If the user has already logged in, the user should not see the Login page. In addition, all the components and services used in the application must be listed in a “Service Directory”, similar to the one that you created in Project 3. The directory must include: provider name (member who is responsible for the component), component type (Web service, DLL function, user control, etc.), operation name, parameters and their types, return type, function description, and link to a TryIt page (or an item in the web application) if the test 
        interface is not explicitly implemented in the web application page. You can combine the TryIt pages into your application GUI and distribute them into the required pages (Default, Member, and Staff, and other GUI pages that you create) listed in this question. </p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Member Page" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Staff Page" />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Admin Page" />
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sign out" />
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Login" />
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Member Register" />
</p>

</asp:Content>
