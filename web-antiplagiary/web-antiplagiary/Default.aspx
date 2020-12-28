<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_antiplagiary._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        
        <div class="col-md-4">
         <asp:FileUpload ID="FileUpload1"  runat="server" AllowMultiple="True" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
            </div>
    </div>
    <div class ="col-12">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>
