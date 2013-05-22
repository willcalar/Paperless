<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Paperless.UI.WebService.Documento>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<h2>Documentos por Migrar</h2>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form id="formBut" action="MigrateDocument" runat="server" method="post">


<script>
    $(document).ready(function () {
        $("table").tablesorterPager({ container: $("#pager") });
    }); 
</script>

    <h2>DocumentResults</h2>

    <table class="tablesorter" >
        <tr>
            <th style="display:none;">
                ID
            </th>
            <th>
                Nombre
            </th>
            <th>
                Fecha
            </th>
            <th>
                Tipo Documento
            </th>
            <th>
                Emisor
            </th>
            <th>
                Receptor
            </th>
            <th>
                Seleccionar
            </th>
        </tr>
        
        <% foreach (var item in Model) { %>
    
        <tr>
            <td style="display:none;">
                <%: item.IdDocumento%>
            </td>
            <td>
                <%: item.NombreDocumento%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Fecha) %>
            </td>
            <td>
                <%: item.TipoDocumento %>
            </td>
            <td>
                <%: item.NombreUsuarioEmisor %>
            </td>
            <td>
                <%: item.NombreUsuarioReceptor %>
            </td>
            <td>
                <%: Html.ActionLink("Imprimir", "MigrateDocument", new { id = item.IdDocumento })%>   
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
                <option value="40">40</option>
		    </select>
	    </form>
    </div>

        <!-- <asp:Button ID="ButtonMigrar" runat="server" Text="Migrar documentos" CssClass="boton"/> --> 
    </form>
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery.tablesorter.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.dialog.js" type="text/javascript"></script>
</asp:Content>






