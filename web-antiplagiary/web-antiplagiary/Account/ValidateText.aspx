<%@ Page Title="Проверка работы" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidateText.aspx.cs" Inherits="web_antiplagiary.Account.ValidateText" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <div class="container">
        <div class="row">
             <div class="col-lg-4 p-2 my-2">
                 Тип проверяемой работы
                 </div>
             <div class="col-lg-8 p-2 my-2">
                 <asp:DropDownList ID="DropDownListTypeWork" runat="server" Width="100%">
                    <asp:ListItem Value="0" Text="Курсовая работа/курсовой проект" Selected="True"> </asp:ListItem>
                     <asp:ListItem Value ="1" Text="Дипломная работа/проект"></asp:ListItem>
                     <asp:ListItem Value ="2" Text="Магистерские рефераты/работы"></asp:ListItem>
                     <asp:ListItem Value ="3" Text="Научные работы"></asp:ListItem>
                 </asp:DropDownList>
                 </div>
       </div>
       <div class="row">
            <div class="col-lg-4 p-2 my-2">
                 Файл с работой
                 </div>
            <div class="col-lg-8 col-12 p-2 my-2">
                 <asp:FileUpload ID="FileUpload1"  runat="server" AllowMultiple="False" CssClass="col-12"/>
                <asp:RegularExpressionValidator ID="RegUpload" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="Тoлько файлы с расширением .docx" CssClass="text-danger" Display="Dynamic"
                        ValidationExpression="(.*\.([Dd][Oo][Cc][Xx])$)"></asp:RegularExpressionValidator>
                </div>
        </div>
        <div class="row">
                <div class="col-lg-8 col-12 p-2 my-2">
                <asp:Button ID="ButtonStart" runat="server" Text="Проверить работу" OnClick="ButtonStart_Click"/>
                    </div>
            </div>
         <div class="row">
            <div class ="col-lg-6 col-12 p-2 my-2" style ="font:larger ">
                <%: new HtmlString( htmlResult ) %>
            </div>
         </div>

    </div>

    </asp:Content>
