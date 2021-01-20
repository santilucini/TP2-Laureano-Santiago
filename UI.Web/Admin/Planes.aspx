<%@ Page Title="" Language="C#" MasterPageFile="~/Basico/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Admin.Planes" %>
<%@ MasterType VirtualPath="~/Basico/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server">
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" CssClass="table-striped" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="GridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" style="align-self:center;position:relative;font-size:20px;" Font-Names="Montserrat" ForeColor="#3333FF">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Plan" />
                <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <HeaderStyle BackColor="#CCCCCC" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionPanel" runat="server" HorizontalAlign="Center">
        <asp:LinkButton ID="btnEditar" runat="server" OnClick="btnEditar_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua">Editar</asp:LinkButton>
        <asp:LinkButton ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua">Nuevo</asp:LinkButton>
    </asp:Panel>
    <br />
    <asp:Panel ID="formPanel" runat="server" HorizontalAlign="Center" Visible="false">
        <div class="form-group">
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion:" BorderStyle="Inset" Font-Names="Montserrat"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDescripcion" runat="server" controltovalidate="txtDescripcion" errormessage="Descripcion Invalida" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" BorderStyle="Inset" Font-Names="Montserrat"></asp:Label>
            <div class="dropdown">
                <asp:DropDownList ID="dwEspecialidades" runat="server" CssClass="btn btn-primary dropdown-toggle" Font-Names="Montserrat">
                </asp:DropDownList>
            </div>
        </div>
        <asp:Panel runat="server">
            <div class="form-group">
                <br/>
                <br/>
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua">Cancelar</asp:LinkButton>
            </div>
        </asp:Panel>
        <div class="form-group">
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Campos erroneos" ValidationGroup="1" BackColor="Silver" BorderColor="Red" BorderStyle="Solid" Font-Bold="True" Font-Names="Montserrat" ForeColor="Red" />
        </div>
        <br />
    </asp:Panel>
</asp:Panel>
</asp:Content>
