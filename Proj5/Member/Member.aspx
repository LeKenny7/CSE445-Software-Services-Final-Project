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
            <h1>Member Page</h1>
            <asp:Button ID="Button1" runat="server" Text="Home" OnClick="Button1_Click" />
            <br />
            <br />
            Thank you for signing up for our services as a Member we are happy to have you! Our services include a timezone and weather service that takes in a zipcode to provide you with the current timezone and weather details, as well as a population service that takes in a city name to return the current population of that city.
            <br />
            <br />
            <strong>Testing for zipcode services:</strong><br />
            - sample input: &quot;85233&quot;, &quot;85281&quot;, and/or &quot;85353&quot;<br />
            <br />
            <strong>Testing for population service:</strong><br />
            - sample input: &quot;Redding&quot;<br />
            <br />
            <asp:Label ID="zipcodeLabel" runat="server"></asp:Label>
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
    <br />
        Please Enter City:<asp:TextBox ID="CityBox" runat="server"></asp:TextBox>
          &nbsp;<asp:Button ID="CityButton" runat="server" Text="Get Pop" OnClick="CityButton_Click" />
         <br />
        <br />
         City Population:&nbsp;<asp:Label ID="PopOutput" Text="" runat="server"></asp:Label>
                     
                     
                </tr>
                </table>
    </form>
</body>
</html>
