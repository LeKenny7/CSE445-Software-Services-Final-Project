<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrentUsername.ascx.cs" Inherits="Proj5.CurrentUsername" %>
<div>
<asp:Label ID="currentUserLabel" runat="server" Text="Welcome, [User]"></asp:Label>
    <br />
<asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
</div>