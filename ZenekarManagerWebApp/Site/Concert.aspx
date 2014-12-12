<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Concert.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Concert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <b>Koncert</b></p>
    <p>
        Helyszín:
        <asp:TextBox ID="HelyszinTextBox" runat="server">B aula</asp:TextBox>
        <asp:Label ID="HelyszinLabel" runat="server"></asp:Label>
    </p>
    <p>
        Időpont:</p>
    <p>
        <asp:TextBox ID="TimeTextBox" runat="server" Width="90px" Text="19:00"></asp:TextBox>
    &nbsp;<asp:Label ID="StartTimeLabel" runat="server"></asp:Label>
        -
        <asp:TextBox ID="TimeTextBox1" runat="server" Width="90px" Text="19:00"></asp:TextBox>
        <asp:Label ID="EndTimeLabel" runat="server"></asp:Label>
    </p>
    <p>
        Műsor:</p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="211px">
        </asp:DropDownList>
        <asp:Button ID="AddPieceButton" runat="server" Text="Darab hozzáadása" OnClick="AddPieceButton_Click" />
    </p>
    <asp:BulletedList ID="BulletedList1" runat="server">
    </asp:BulletedList>
    <p>
        Megjegyzés:</p>
    <p>
        <asp:TextBox ID="MegjegyzesTextBox" runat="server" Height="125px" TextMode="MultiLine" Width="381px"></asp:TextBox>
        <asp:Label ID="MegjegyzesLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="ConcertButton" runat="server" Text="Műsor módosítása" OnClick="ConcertButton_Click" />
    </p>
    <p>
        <asp:Label ID="AttendLabel" runat="server" Text="Részt veszek:"></asp:Label>
        <asp:CheckBox ID="AttendCheckBox" runat="server" OnCheckedChanged="AttendCheckBox_CheckedChanged" AutoPostBack="true"/>
    </p>
    <p>
        <asp:TextBox ID="AttendTextBox" runat="server" Height="138px" TextMode="MultiLine" Width="372px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="AttendMessageButton" runat="server" Text="Mentés" />
    </p>
</asp:Content>
