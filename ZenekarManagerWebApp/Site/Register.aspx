<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    E-mail cím:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="EmailTextBox" runat="server" Height="26px" Width="161px"></asp:TextBox>
<br />
    Név:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="NameTextBox" runat="server" Height="26px" Width="161px"></asp:TextBox>
<br />
    Jelszó:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="PwTextBox" runat="server" Height="26px" Width="161px" TextMode="Password"></asp:TextBox>
<br />
    Jelszó megerősítése:&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="PwConfirmTextBox" runat="server" Height="26px" Width="161px" TextMode="Password"></asp:TextBox>
    <br />
    Aktív:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="aktiv" runat="server" />
<br />
    Koncertre jár:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="koncertrejar" runat="server" />
    <br />
    <br />
    <asp:Button ID="RegisterButton" runat="server" Text="Regisztrál" OnClick="RegisterButton_Click" />
    <br />
    <asp:Label ID="SuccessfulLabel" runat="server"></asp:Label>
</asp:Content>
