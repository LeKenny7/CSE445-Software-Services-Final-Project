<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaptchaForm.aspx.cs" Inherits="Proj5.CaptchaForm" %>

<%@ Register Src="~/CaptchaControl.ascx" TagName="CaptchaWebControl" TagPrefix="TCaptchaWebControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <TCaptchaWebControl:CaptchaWebControl ID="Header" runat="server" />
</asp:Content>
