<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="web_antiplagiary.Account.AddNewUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container"> 
        <asp:Label ID="LabelInfo" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="row">
            <div class="col-md-4">
                Имя пользователя
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </div>            
        </div>
        <div class="row">
            <div class="col-md-4">
                Пароль
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="TextBoxPass" runat="server"></asp:TextBox>
            </div>            
        </div>
        <div class="row">
            <div class="col-md-4">
                Роль
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="DropDownListRole" runat="server"></asp:DropDownList>
            </div>            
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="ButtonReg" runat="server" Text="Создать пользователя" OnClick="ButtonReg_Click" />
            </div>
            <div class="col-md-8">
               
            </div>            
        </div>

    </div>
</asp:Content>
