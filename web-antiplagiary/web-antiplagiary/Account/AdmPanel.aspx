<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Главная страница" AutoEventWireup="true" CodeBehind="AdmPanel.aspx.cs" Inherits="web_antiplagiary.Account.AdmPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">        
       <div class="row">
            <asp:LoginView runat="server" ViewStateMode="Disabled">
                <RoleGroups>
               <asp:RoleGroup Roles="Odmin">
                        <ContentTemplate>
                           <div class="col-md-4">
                                   <asp:Button ID="ButtonAddNew" runat="server" Text="Добавить пользователя" Height="100%" Width="100%" PostBackUrl="~/Account/AddNewUser.aspx" />
                               </div>
                               <div class="col-md-4">
                                   <asp:Button ID="ButtonBlock" runat="server" Text="Управление блокировкой"  Height="100%" Width="100%"/>
                               </div>
                               <div class="col-md-4">
                                   <asp:Button ID="ButtonRoled" runat="server" Text="Смена роли пользователя" Height="100%" Width="100%" />
                               </div>
                        </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Moderator">
                        <ContentTemplate>
                           <div class="col-sm-6">
                                   <asp:Button ID="ButtonAddNew" runat="server" Text="Добавить пользователя" Height="100%" Width="100%" />
                               </div>
                               <div class="col-sm-6">
                                   <asp:Button ID="ButtonBlock" runat="server" Text="Управление блокировкой"  Height="100%" Width="100%"/>
                               </div>                               
                        </ContentTemplate>
                    </asp:RoleGroup>
           </RoleGroups>
                </asp:LoginView>
       </div>
         <table border="1" style="width:100%">
             <caption>Список пользователей</caption>
             <tr>
                <th>Логин</th>
                <th>Пароль</th>
                <th>Роль</th>
                <th>Блокировка</th>
             </tr>
             <%: new HtmlString(TableText.ToString())%>
             </table>

    </div>
  

</asp:Content>
