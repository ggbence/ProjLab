<%@ Page Title="Profilom" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ZenekarManagerWebApp.Account.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    E-mail cím:<br />
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <br />
    Név:<br />
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    <br />
    Hangszerek:<br />
    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Value" DataValueField="Key" Height="87px" SelectionMode="Multiple" Width="238px"></asp:ListBox>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getInstruments" TypeName="User"></asp:ObjectDataSource>
    <br />
    <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="Frissít" />
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</asp:Content>
