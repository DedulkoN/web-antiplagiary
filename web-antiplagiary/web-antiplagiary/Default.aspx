<%@ Page Title="Главная страница" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_antiplagiary._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container"> 
        <br />
        <div class="col-md-1"></div>
        <div class="col-md-10">
                <p>  Автоматизированная система «Проверка работ студентов на заимствования» предназначена для организации в учебном заведении целостного процесса 
            проверки студенческих работ на наличие заимствований.</p> 
            <br />
            <p> Основная цель системы «Проверка работ студентов на заимствования» - это повышение качества образования и побуждение студентов 
                к самостоятельному написанию текстов. Для преподавателей этот проекта стал отличным помощником, так как они с легкостью могут определять уникальность работы 
                студента.</p>

            <br />
             <p>Для более уверенного начала работы с системой рекомендуем вам ознакомиться с <a runat="server" href="~/UserGuide.pdf">руководством пользователя</a> </p>
               <asp:LoginView runat="server" >
               <AnonymousTemplate>
                  <p>Если у вас уже есть данные учетной записи вы можете <a runat="server" href="~/Account/Login">Войти в учетную запись</a> </p>
                </AnonymousTemplate>
                </asp:LoginView>   

            </div>
        <div class="col-md-1"></div>
        <br />
    </div>
  <br />

</asp:Content>
