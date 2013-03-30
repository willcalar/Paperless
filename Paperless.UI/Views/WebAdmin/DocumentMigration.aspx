<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <h2>Migración de documentos</h2>
    <p>Migración de documentos al Centro Nacional de Archivos</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Selección de documentos:</h2>

    <asp:GridView ID="GridViewResultados" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Nombre del documento"></asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha"></asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo de documento"></asp:TemplateField>
            <asp:TemplateField HeaderText="Emisor"></asp:TemplateField>
            <asp:TemplateField HeaderText="Receptor"></asp:TemplateField>
            <asp:CheckBoxField HeaderText="Seleccionar" />
        </Columns>
    </asp:GridView>

    <asp:Button ID="BotonMigrar" runat="server" Text="Migrar documentos" CssClass="boton"/>
</asp:Content>

