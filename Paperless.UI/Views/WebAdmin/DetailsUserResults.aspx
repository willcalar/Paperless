<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Paperless.UI.WebService.Documento>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<h2>Resultados de búsqueda</h2>
    <p>Muestra los resultados de acuerdo a los filtros escogidos.</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script>
$(document).ready(function() {
    $("table").tablesorterPager({container: $("#pager")}); 
}); 
</script>

    <h2>Detalles De Documentos Del Usuario</h2>

    <table class="tablesorter" >
        <tr>
            <th>
                Fecha
            </th>
            <th>
                NombreDocumento
            </th>
            <th>
                TipoDocumento
            </th>
            <th>
                TipoEvento
            </th>
            <th>
                TipoAccion
            </th>
            <th>
                Ruta
            </th>
        </tr>
        
        <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: String.Format("{0:g}", item.Fecha) %>
            </td>
            <td>
                <%: item.NombreDocumento %>
            </td>
            <td>
                <%: item.TipoDocumento %>
            </td>
            <td>
                <%: item.TipoEvento %>
            </td>
            <td>
                <%: item.TipoAccion %>
            </td>
            <td>
                <%: item.Ruta %>
            </td>
        </tr>
    
    <% } %>
    
    </table>

    <script type="text/javascript">
        $(function () {
            // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!
            $("#dialog:ui-dialog").dialog("destroy");

            $("#dialog-message").dialog({
                modal: true,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });
	</script>
    <div id="dialog:ui-dialog" title="Mensaje">
	<p>
		<span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
		<%=ViewData["Message"]%>
	</p>
    </div>

    <div id="pager" class="pager">
	    <form>

		    <img src="../../Images/first.png" class="first"/>
		    <img src="../../Images/prev.png" class="prev"/>

		    <input type="text" class="pagedisplay"/>

		    <img src="../../Images/next.png" class="next"/>
		    <img src="../../Images/last.png" class="last"/>

		    <select class="pagesize">
			    <option selected="selected"  value="10">10</option>
			    <option value="20">20</option>
			    <option value="30">30</option>
                <option  value="40">40</option>
		    </select>
	    </form>
    </div>

    <p>
        <%: Html.ActionLink("Volver", "UserResults") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.dialog.js" type="text/javascript"></script>
</asp:Content>

