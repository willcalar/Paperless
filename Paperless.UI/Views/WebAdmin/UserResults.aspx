<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Paperless.UI.WebService.Usuario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<h2>Resultados de búsqueda</h2>
    <p>Muestra los resultados de acuerdo al nombre de usuario elegido.</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>UserResults</h2>

    <table>
        <tr>
            <th>
                Detalles
            </th>
            <th>
                Departamento
            </th>
            <th>
                NombreUsuario
            </th>
            <th>
                PrimerApellido
            </th>
            <th>
                SegundoApellido
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Ver", "DetallesUsuario", new {  id=item.NombreUsuario }) %>
            </td>
            <td>
                <%: item.Departamento %>
            </td>
            <td>
                <%: item.NombreUsuario %>
            </td>
            <td>
                <%: item.PrimerApellido %>
            </td>
            <td>
                <%: item.SegundoApellido %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Volver", "UserAudit") %>
    </p>


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


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.dialog.js" type="text/javascript"></script>
</asp:Content>
