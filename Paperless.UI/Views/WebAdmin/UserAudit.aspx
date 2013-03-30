<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<Paperless.UI.Models.UserAuditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
<h2>Auditoría de usuarios:</h2>
<p>Consulta de las acciones de usuarios específicos.</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <form id="Form1" action="SearchUsers" runat="server">
    <h2>Parámetros de búsqueda</h2>
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "La búsqueda no fue exitosa. Por favor intente de nuevo") %>
        <div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.UserName) %>
            </div>
            
            <p>
                <input type="submit" value="Buscar documentos" class="boton" name="_BtnSearch" />
            </p>
        </div>
    <% } %>
    </form>
</asp:Content>
