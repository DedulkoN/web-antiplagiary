﻿<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="web_antiplagiary.Account.AddNewUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label ID="LabelInfo" runat="server" Text="" ForeColor="Red"></asp:Label>
    <div class="container"> 
       
        <div class="row">
            <div class="col-md-4 text-right" >
                Имя пользователя
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="TextBoxName" runat="server" Width="100%"></asp:TextBox>
            </div>         
            <div class="col-md-2">
                <asp:Button ID="ButtonNameGenerate" CssClass="btn-primary"  runat="server" Text="Сгенерировать" OnClick="ButtonNameGenerate_Click" Width="100%"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 text-right">
                Пароль
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="TextBoxPass" runat="server"  Width="100%"></asp:TextBox>
            </div>  
            <div class="col-md-2">
                <asp:Button ID="ButtonPassGenerate" runat="server" CssClass="btn-primary"  Text="Сгенерировать" OnClick="ButtonPassGenerate_Click" Width="100%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 text-right">
                Роль
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="DropDownListRole" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
            </div>            
        </div>
        <div class="row">
            <div class="col-md-4">
              
            </div>
            <div class="col-md-4">
                 <asp:Button ID="ButtonReg" runat="server" CssClass="btn btn-primary"  Text="Создать пользователя" OnClick="ButtonReg_Click" Width="100%" />
            </div>            
        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Visible="false"/>
    </div>
</asp:Content>
