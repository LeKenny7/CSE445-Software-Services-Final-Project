<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebsiteStringUI.CaptchaForm1" %>

<%@ Register Src="~/CaptchaControl.ascx" TagName="CaptchaWebControl" TagPrefix="TCaptchaWebControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Service: Takes zipcode and find the weather information from that area using open weather api.<br />
    Local Components: User control to use captcha. We only need to use it here, but I can put the ascx file in any aspx file.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cookies to save the last valid zipcode into the user&#39;s hard drive.<br />
    <br />
    Try entering the incorrect captcha first. Then enter the correct one to move on to the next page.<br />
    <br />
    To find weather information based off of a zipcode, please first prove you are not a robot!<br />
    <TCaptchaWebControl:CaptchaWebControl ID="Header" runat="server" />
</asp:Content>
