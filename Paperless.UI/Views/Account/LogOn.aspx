<%@ Page Language="C#" MasterPageFile="~/Views/Shared/SiteNoBar.Master" Inherits="System.Web.Mvc.ViewPage<Paperless.UI.Models.LogOnModel>" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <h2>Iniciar sesion</h2>
    <p>Ingrese con su nombre de usuario y contraseña.</p>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <form id="formLogIn" action="LogOn" runat="server">
    <h2>
        Ingresar
    </h2>
    <p>
        Por favor ingrese su usuario y contraseña.
        <a href="/Account/Register">Registrese</a> si no posee cuenta.
    </p>



    <div>
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.") %>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                <p>
                    <input type="submit" value="Ingresar" class="boton" />
                </p>
    </div>
    <% } %>
    </form>
</asp:Content>
