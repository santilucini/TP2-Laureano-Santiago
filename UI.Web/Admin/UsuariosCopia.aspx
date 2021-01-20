<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Basico/Site.Master" AutoEventWireup="true" CodeBehind="UsuariosCopia.aspx.cs" Inherits="UI.Web.Usuarios" %>
<%@ MasterType VirtualPath="~/Basico/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server"
        SelectRowStyle-BackColor="Black" DataKeyNames="ID"
        SelectRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:academiaConnectionString %>" SelectCommand="SELECT [nombre], [apellido], [email], [nombre_usuario], [habilitado] FROM [usuarios]"></asp:SqlDataSource>
    </asp:Panel>

    <p>
    </p>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
    <asp:Checkbox ID="habilitadoCheckBox" runat="server" /><br />
    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="claveLabel" runat="server" text="Clave : "></asp:Label>
    <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave:"></asp:Label>
    <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>



        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>


    <br />
    </asp:Panel>


    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>



</asp:Content>

