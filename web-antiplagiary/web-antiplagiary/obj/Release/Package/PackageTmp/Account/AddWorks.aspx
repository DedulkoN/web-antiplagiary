<%@ Page Title="Добавление работ в базу данных" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddWorks.aspx.cs" Inherits="web_antiplagiary.Account.AddWorks" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h3 class="text-center">Добавление работ в Базу Данных</h3>
    <div class="container">
        <div class="row">
             <div class="col-md-4 text-right">
                 Тип добавляемых работ
                 </div>
             <div class="col-md-8">
                 <asp:DropDownList ID="DropDownListTypeWork" CssClass="form-control select" runat="server" Width="100%">
                    <asp:ListItem Value="0" Text="Курсовая работа/курсовой проект" Selected="True"> </asp:ListItem>
                     <asp:ListItem Value ="1" Text="Дипломная работа/проект"></asp:ListItem>
                     <asp:ListItem Value ="2" Text="Магистерские диссертации"></asp:ListItem>
                     <asp:ListItem Value ="3" Text="Научные работы"></asp:ListItem>
                 </asp:DropDownList>
                 </div>
       </div>
         <div class="row">
             <div class="col-md-4 text-right">
                 Файлы с работами
                 </div>
            <div class="col-md-8 col-12">
                 <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" CssClass="form-control" Width="100%" accept=".docx"/>
                <asp:RegularExpressionValidator ID="RegUpload" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="Тoлько файлы с расширением .docx" CssClass="text-danger" Display="Dynamic"
                        ValidationExpression="(.*\.([Dd][Oo][Cc][Xx])$)"></asp:RegularExpressionValidator>
                </div>
             </div>
        <div class="row">
            <div class="col-md-4">
                </div>
                <div class="col-md-8">
                <asp:Button ID="ButtonStart" CssClass="btn btn-primary" runat="server" Text="Добавить работы" OnClick="ButtonStart_Click" />
                    </div>
            </div>
         <div class="row">
             <div class="col-md-1"></div>
            <div class ="col-md-10" style ="font-size:larger">
                <%: new HtmlString( htmlResult.ToString() ) %>
            </div>
             <div class="col-md-1"></div>
         </div>

        </div> 
       </asp:Content>
