<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <h2>Eventos irregulares</h2>
    <p>Eventos registrados que presentan alguna irregularidad en el sistema.</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewEventos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de evento"></asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion"></asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha y hora"></asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario"></asp:TemplateField>
            <asp:TemplateField HeaderText="Documento"></asp:TemplateField>
            <asp:CheckBoxField HeaderText="Revisado" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="BotonGuardar" runat="server" Text="Guardar" CssClass="boton"/>
</asp:Content>
