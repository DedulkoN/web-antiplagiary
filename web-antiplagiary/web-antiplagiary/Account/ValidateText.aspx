<%@ Page Title="Проверка работы" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidateText.aspx.cs" Inherits="web_antiplagiary.Account.ValidateText" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <h3 class="text-center">Проверка работы</h3>
    <div class="container">
        <div class="row">
             <div class="col-md-4 text-right" >
                 Тип проверяемой работы
                 </div>
             <div class="col-md-8">
                 <asp:DropDownList ID="DropDownListTypeWork" CssClass="form-control" runat="server" Width="100%">
                    <asp:ListItem Value="0" Text="Курсовая работа/курсовой проект" Selected="True"> </asp:ListItem>
                     <asp:ListItem Value ="1" Text="Дипломная работа/проект"></asp:ListItem>
                     <asp:ListItem Value ="2" Text="Магистерские диссертации"></asp:ListItem>
                     <asp:ListItem Value ="3" Text="Научные работы"></asp:ListItem>
                 </asp:DropDownList>
                 </div>
       </div>
       <div class="row">
            <div class="col-md-4 text-right">
                 Файл с работой
                 </div>
            <div class="col-md-8 col-12">
                 <asp:FileUpload ID="FileUpload1" CssClass="form-control"  runat="server" AllowMultiple="False" accept=".docx"/>
                <asp:RegularExpressionValidator ID="RegUpload" runat="server" ControlToValidate="FileUpload1"
                        ErrorMessage="Тoлько файлы с расширением .docx" CssClass="text-danger" Display="Dynamic"
                        ValidationExpression="(.*\.([Dd][Oo][Cc][Xx])$)"></asp:RegularExpressionValidator>
                </div>
        </div>
        <%--<div class="row">
            <div class="col-md-4 text-right">
                Печать результата в pdf
                 </div>
            <div class="col-md-8 col-12">
                <asp:CheckBox ID="CheckPrint" runat="server" />
                </div>
        </div>--%>


        <div class="row">
            <div class="col-md-4 "></div>
                <div class="col-md-4 ">
                <asp:Button ID="ButtonStart" CssClass="btn btn-primary" runat="server" Text="Проверить работу" OnClick="ButtonStart_Click"/>
                    </div>
            </div>
         <div class="row">
             <div class="col-md-3"></div>
            <div class ="col-md-6 col-12 " style ="font:larger ">
                <%: new HtmlString( htmlResult ) %>
              
            </div>
             <div class="col-md-3"></div>
         </div>

    </div>

    </asp:Content>
