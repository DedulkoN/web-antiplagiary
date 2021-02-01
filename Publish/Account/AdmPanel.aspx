<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Главная страница" AutoEventWireup="true" CodeBehind="AdmPanel.aspx.cs" Inherits="web_antiplagiary.Account.AdmPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">        
       <div class="row">
            <asp:LoginView runat="server" ViewStateMode="Disabled">
                <RoleGroups>
               <asp:RoleGroup Roles="Odmin">
                        <ContentTemplate>
                           <div class="col-md-4">
                                   <asp:Button ID="ButtonAddNew" CssClass="btn btn-primary" runat="server" Text="Добавить пользователя" Height="100%" Width="100%" PostBackUrl="~/Account/AddNewUser.aspx" />
                               </div>
                               <div class="col-md-4">
                                   <asp:Button ID="ButtonBlock" CssClass="btn btn-primary" runat="server" Text="Управление блокировкой"  Height="100%" Width="100%" PostBackUrl="~/Account/blockManager.aspx"/>
                               </div>
                               <div class="col-md-4">
                                   <asp:Button ID="ButtonRoled" CssClass="btn btn-primary" runat="server" Text="Смена роли пользователя" Height="100%" Width="100%"  PostBackUrl="~/Account/RolesManager.aspx"/>
                               </div>
                        </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Moderator">
                        <ContentTemplate>
                           <div class="col-sm-6">
                                   <asp:Button ID="ButtonAddNew" CssClass="btn btn-primary" runat="server" Text="Добавить пользователя" Height="100%" Width="100%" PostBackUrl="~/Account/AddNewUser.aspx"/>
                               </div>
                               <div class="col-sm-6">
                                   <asp:Button ID="ButtonBlock" CssClass="btn btn-primary" runat="server" Text="Управление блокировкой"  Height="100%" Width="100%" PostBackUrl="~/Account/blockManager.aspx"/>
                               </div>                               
                        </ContentTemplate>
                    </asp:RoleGroup>
           </RoleGroups>
                </asp:LoginView>
       </div>
         <table style="width:100%" class="table table-hover">
             <caption>Список пользователей</caption>
             <tr>
                <th scope="col">Логин</th>
                <th scope="col">Пароль</th>
                <th scope="col">Роль</th>
                <th scope="col">Блокировка</th>
             </tr>
             <%: new HtmlString(TableText.ToString())%>
             </table>

    </div>
  

</asp:Content>
