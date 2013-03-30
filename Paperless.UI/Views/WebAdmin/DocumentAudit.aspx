<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<Paperless.UI.Models.DocumentAuditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.11.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.datepicker-es.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
<h2>Auditoría de Documentos</h2>
<p>Consulta de documentos registrados en el sistema según diferentes criterios e historial de acciones.</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <form id="Form1" action="SearchDocuments" runat="server">
    <h2>Parámetros de búsqueda</h2>
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "La búsqueda no fue exitosa. Por favor intente de nuevo") %>
        <div>
            <fieldset class="multicolumn3">
                
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserSender) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserSender) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserReciever) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserReciever) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Department) %>
                </div>
                <div class="editor-field">
                    <%: Html.DropDownListFor(m => m.Department, new SelectList(""))%>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.DocumentType) %>
                </div>
                <div class="editor-field">
                    <%: Html.DropDownListFor(m => m.DocumentType, new SelectList(""))%>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.IssueDate)%>
                </div>
                <div class="editor-field">
                    <script>
                        $(function () {
                            $("#datepicker").datepicker();
                        });
	                </script>
                    <input type="text" id="datepicker" />
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ReceptionDate)%>
                </div>
                <div class="editor-field">
                    <script>
                        $(function () {
                            $("#datepicker1").datepicker();
                        });
	                </script>
                    <input type="text" id="datepicker1" />
                </div>
            </fieldset>
            <p>
                <input type="submit" value="Buscar documentos" class="boton" name="_BtnSearch" />
            </p>
        </div>
    <% } %>
    </form>
</asp:Content>