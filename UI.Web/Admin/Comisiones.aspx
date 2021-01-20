﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="anioespecialidad" HeaderText="Año Especialidad" />                
                <asp:BoundField DataField="idplan" HeaderText="ID Plan" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="idLabel" runat="server" Text="ID: "></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server" ReadOnly="True"></asp:TextBox> 
        <br />
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año Especialidad: "></asp:Label>
        <asp:TextBox ID="anioEspecialidadTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="idPlanLabel" runat="server" Text="ID Plan: "></asp:Label>
        <asp:DropDownList ID="idPlanDropDownList" runat="server"></asp:DropDownList>
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
