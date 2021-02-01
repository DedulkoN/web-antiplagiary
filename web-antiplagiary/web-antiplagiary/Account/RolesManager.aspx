<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesManager.aspx.cs" Inherits="web_antiplagiary.Account.RolesManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:Label ID="LabelRez" CssClass="text-warning" runat="server" Text="" ForeColor="Red"></asp:Label>
    <div class="container">
        
        <div class="row">
            <div class="col-md-4 text-right">
                Пользователь
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="DropDownListUser" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 text-right">
                Роль
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="DropDownListRole" Width="100%" runat="server"></asp:DropDownList>
            </div>
        </div>
            <div class="row">
                <div class="col-md-4">                    
                </div>

                <div class="col-md-4">
                    <asp:Button ID="ButtonGo" CssClass="btn btn-primary" Width="100%" runat="server" Text="Сменить" OnClick="ButtonGo_Click" />
                </div>
            </div>
        

        
    </div>


</asp:Content>
