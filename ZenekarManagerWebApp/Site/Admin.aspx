<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" runat="server" Height="30px" Width="290px">
        <asp:ListItem Text="Felhasználók" Value="0"></asp:ListItem>
        <asp:ListItem Text="Kották" Value="1"></asp:ListItem>
        <asp:ListItem Text="Koncertek" Value="2"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="UserView" runat="server">
        <asp:ListView ID="ListView2" OnSelectedIndexChanged="ListView2_SelectedIndexChanged" DataKeyNames="email" runat="server" DataSourceID="Users" EnablePersistedSelection="True">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("jogkör") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("hangszerek") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <SelectedItemTemplate>
               <tr style="background-color:#ff6a00;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("jogkör") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("hangszerek") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </SelectedItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("jogkör") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("hangszerek") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Név</th>
                                    <th runat="server">Email</th>
                                    <th runat="server">Jogkör</th>
                                    <th runat="server">Hangszerek</th>
                                    <th runat="server">Módosítás</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="Users" runat="server" SelectMethod="getUsers" TypeName="ZenekarManagerWebApp.Site.Admin"></asp:ObjectDataSource>
    </asp:View>
    <asp:View ID="SheetView" runat="server">
        <asp:ListView ID="SheetListView" OnSelectedIndexChanged="SheetListView_SelectedIndexChanged" DataKeyNames="ID" runat="server" EnablePersistedSelection="True" DataSourceID="ObjectDataSource1">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("Composer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:HyperLink ID="Jogkor_idLabel" runat="server" Text="kotta" NavigateUrl='<%# Eval("Link") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="HangszerekLabel" runat="server" Enabled="true" Checked='<%# Eval("Inrepertoar") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <SelectedItemTemplate>
               <tr style="background-color:#ff6a00;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("Composer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:HyperLink ID="Jogkor_idLabel" runat="server" Enabled="true" Text="kotta" NavigateUrl='<%# Eval("Link") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="HangszerekLabel" runat="server" Checked='<%# Eval("Inrepertoar") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </SelectedItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("Composer") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <asp:HyperLink ID="Jogkor_idLabel" runat="server" Text="kotta" NavigateUrl='<%# Eval("Link") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="HangszerekLabel" runat="server" Enabled="true" Checked='<%# Eval("Inrepertoar") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Szerző</th>
                                    <th runat="server">Cím</th>
                                    <th runat="server">Kotta</th>
                                    <th runat="server">Próbarepertoár</th>
                                    <th runat="server">Módosítás</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getPieces" TypeName="ZenekarManagerWebApp.Site.Admin"></asp:ObjectDataSource>
        <asp:Button ID="Button1" runat="server" Text="Új kotta" />
    </asp:View>
    <asp:View ID="ConcertView" runat="server">
        <asp:ListView ID="ConcertListView" OnSelectedIndexChanging="ConcertListView_SelectedIndexChanging" OnSelectedIndexChanged="ConcertListView_SelectedIndexChanged" DataKeyNames="ID" runat="server" EnablePersistedSelection="True">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("starttime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("endtime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("helyszin") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <SelectedItemTemplate>
               <tr style="background-color:#ff6a00;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("starttime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("endtime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("helyszin") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </SelectedItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="Users_idLabel" runat="server" Text='<%# Eval("starttime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Users_emailLabel" runat="server" Text='<%# Eval("endtime") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("helyszin") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Módosítás" CommandName="Select" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Kezdőidőpont</th>
                                    <th runat="server">Végidőpont</th>
                                    <th runat="server">Helyszín</th>
                                    <th runat="server">Módosítás</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:Button ID="AddConcert" runat="server" Text="Új koncert" OnClick="AddConcert_Click" />
    </asp:View>
</asp:MultiView>
</asp:Content>
