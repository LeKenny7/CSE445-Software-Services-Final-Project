<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zipcode.aspx.cs" Inherits="WebsiteStringUI._Default" %>

<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Assignment 8 Try It Page</h1>
    <div class = "URLContent">
        <p>
            <strong>Open Weather Map Service</strong></p>
        <p>
            The service takes a zipcode and returns weather information such as temperature, humidity, and weather description.</p>
        <p>
            string GetWeatherData(string zipcode)</p>
        <p>
            &nbsp;</p>
        <p>
            <strong>Map Quest Service   </strong>   <p>
            This service takes a zipcode and finds the associated city so that the city name can be used in the WAQI Service.</p>
        <p>
            <strong>WAQI Service</strong></p>
        <p>
            This service takes a city name and returns the air quality index of the city.</p>
        <p>
            string GetPollutionData(string zipcode)</p>

        <asp:Button ID="zipcodeButton" runat="server" OnClick="zipcodeButton_Click" Text="Enter Zipcode" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="zipcodeTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="zipcodeLabel" runat="server" Text="Label"></asp:Label>
        <br />
        <p>
            <asp:Label ID="weatherInfoLabel" runat="server" Text="Weather Info:"></asp:Label>
        </p>
        <p>
            Pollution Info:</p>
        <p>
            <asp:Label ID="PollutionInfoLabel" runat="server"></asp:Label>
        </p>
    </div>

</asp:Content>
