<%@ Page Language="C#"  MasterPageFile="~/Site.Master" Title="Управление блокировками" AutoEventWireup="true" CodeBehind="blockManager.aspx.cs" Inherits="web_antiplagiary.Account.blockManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                Пользователь
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="DropDownListStudent" runat="server" Width="100%" OnSelectedIndexChanged="DropDownListStudent_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="ButtonBlock" runat="server" Text="Блокировать" Width="100%" OnClick="ButtonBlock_Click" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="ButtonUnBlock" runat="server" Text="Разблокировать" Width="100%" OnClick="ButtonUnBlock_Click" />
            </div>
        </div>
    </div>

</asp:Content>
