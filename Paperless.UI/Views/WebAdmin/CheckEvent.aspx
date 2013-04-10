<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<Paperless.UI.WebService.Evento>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%if (Model.Origen == "Documento"){ %>
    <h1>
    El Documento con el id <span><% Model.IDReferencia %></span>  ya fue 
    </h1>
    <%} %>
</asp:Content>
