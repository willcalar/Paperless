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

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

