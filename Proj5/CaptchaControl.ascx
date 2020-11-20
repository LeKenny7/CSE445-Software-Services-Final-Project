<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaptchaControl.ascx.cs" Inherits="Proj5.CaptchaControl" %>
    <p>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="CaptchaCode">
            Retype the characters from the picture:
            </asp:Label>
            <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" 
                           UserInputID="CaptchaCode" runat="server" />
            <p>
            <asp:TextBox ID="CaptchaCode" runat="server" />

            <asp:Label ID="captchaLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="verifyButton" runat="server" OnClick="verifyButton_Click" Text="Verify" />
        </p>