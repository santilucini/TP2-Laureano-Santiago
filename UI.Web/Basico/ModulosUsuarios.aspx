<%@ Page Title="" Language="C#" MasterPageFile="~/Basico/Site.Master" AutoEventWireup="true" CodeBehind="ModulosUsuarios.aspx.cs" Inherits="UI.Web.ModulosUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="idmodulo" HeaderText="ID Modulo" />                               
                <asp:BoundField DataField="idusuario" HeaderText="ID Usuario" />
                <asp:BoundField DataField="alta" HeaderText="Alta" />
                <asp:BoundField DataField="baja" HeaderText="Baja" />                 
                <asp:BoundField DataField="modificacion" HeaderText="Modificacion" /> 
                <asp:BoundField DataField="consulta" HeaderText="Consulta" /> 
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="idLabel" runat="server" Text="ID: "></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server" ReadOnly="True"></asp:TextBox> 
        <br />
        <asp:Label ID="idModuloLabel" runat="server" Text="ID Modulo: "></asp:Label>
        <asp:DropDownList ID="idModuloDropDownList" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="idUsuarioLabel" runat="server" Text="ID Usuario: "></asp:Label>
        <asp:DropDownList ID="idUsuarioDropDownList" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="altaLabel" runat="server" Text="Alta: "></asp:Label>
        <asp:Checkbox ID="altaCheckBox" runat="server" /><br />
        <br />
        <asp:Label ID="bajaLabel" runat="server" Text="Baja: "></asp:Label>
        <asp:Checkbox ID="bajaCheckbox" runat="server" /><br />
        <br />
        <asp:Label ID="modificacionLabel" runat="server" Text="Modificacion: "></asp:Label>
        <asp:Checkbox ID="modificacionCheckbox" runat="server" /><br />
        <br />
        <asp:Label ID="consultaLabel" runat="server" Text="Consulta: "></asp:Label>
        <asp:Checkbox ID="consultaCheckbox" runat="server" /><br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
</asp:Content>
