<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proj5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
    <br />
    MAIN</p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Member Page" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Staff Page" />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Admin Page" />
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sign out" />
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Login" />
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Member Register" />
</p>

</asp:Content>
