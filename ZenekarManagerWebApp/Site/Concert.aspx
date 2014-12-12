<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Concert.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Concert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <b>Koncert</b></p>
    <p>
        Helyszín:
        <asp:TextBox ID="TextBox1" runat="server">B aula</asp:TextBox>
    </p>
    <p>
        Időpont:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    </p>
    <p>
        <asp:TextBox ID="txtTime" runat="server" Width="90px" Text="19:00"></asp:TextBox>
    </p>
    <p>
        Műsor:</p>
    <asp:BulletedList ID="BulletedList1" runat="server">
        <asp:ListItem Text="Beethoven: 9. szimfónia" />
        <asp:ListItem Text="Mozart: Varázsfuvola nyitány" />
    </asp:BulletedList>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Műsor módosítása" />
    </p>
</asp:Content>
