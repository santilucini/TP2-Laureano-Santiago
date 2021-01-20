<%@ Page Title="" Language="C#" MasterPageFile="~/Basico/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Admin.Usuarios" %>
<%@ MasterType VirtualPath="~/Basico/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server" style="border: 1px solid #000; width: 100%; height:80%; left:0%;position:relative;">
        <div runat="server" class="form-inline" height="100%" padding="0%" position="absolute" width="100%">
            <asp:Panel runat="server">
                <asp:Panel ID="gridPanel" runat="server">
                    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" CssClass="table-striped" DataKeyNames="ID" Font-Names="Montserrat" ForeColor="#3333FF" OnSelectedIndexChanged="GridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" style="align-self:center;position:relative;font-size:20px; margin-top: 0px;">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                        </Columns>
                        <HeaderStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <SelectedRowStyle BackColor="Black" ForeColor="White" />
                    </asp:GridView>
                    <asp:Panel ID="gridActionPanel" runat="server" HorizontalAlign="Center">
                        <asp:LinkButton ID="btnEditar0" runat="server" BackColor="#CCCCCC" BorderStyle="Outset" Font-Bold="True" Font-Names="Montserrat" Font-Underline="False" ForeColor="Aqua" OnClick="btnEditar_Click" Width="60px">Editar</asp:LinkButton>
                        <asp:LinkButton ID="btnEliminar0" runat="server" BackColor="#CCCCCC" BorderStyle="Outset" Font-Bold="True" Font-Names="Montserrat" Font-Underline="False" ForeColor="#66FFFF" OnClick="btnEliminar_Click" Width="82px">Eliminar</asp:LinkButton>
                        <asp:LinkButton ID="btnNuevo0" runat="server" BackColor="#CCCCCC" BorderStyle="Outset" Font-Bold="True" Font-Names="Montserrat" Font-Underline="False" ForeColor="#66FFFF" OnClick="btnNuevo_Click" Width="66px">Nuevo</asp:LinkButton>
                    </asp:Panel>
                </asp:Panel>
    <br />
                <asp:Panel ID="formPanel" runat="server" HorizontalAlign="Center" Visible="false">
                    <div class="form-group">
                        <asp:Label ID="lblNombre0" runat="server" Font-Names="Montserrat" Text="Nombre: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqNombre" runat="server" controltovalidate="txtNombre" Enabled="false" errormessage="Nombre Invalido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblApellido" runat="server" Font-Names="Montserrat" Text="Apellido: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqApellido" runat="server" controltovalidate="txtApellido" Enabled="false" errormessage="Apellido Invalido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblHabilitado" runat="server" Font-Names="Montserrat" Text="Habilitado" BorderStyle="Inset"></asp:Label>
                        <asp:CheckBox ID="checkHabilitado" runat="server" Font-Names="Montserrat" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblNombreUsuario" runat="server" Font-Names="Montserrat" Text="Usuario: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqNombUsuario" runat="server" controltovalidate="txtNombreUsuario" Enabled="false" errormessage="Nombre Usuario Invalido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" Font-Names="Montserrat" Text="Email: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqEmail" runat="server" controltovalidate="txtEmail" Enabled="false" errormessage="Email Invalido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblTelefono" runat="server" Font-Names="Montserrat" Text="Telefono: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqTelefono" runat="server" controltovalidate="txtTelefono" Enabled="false" errormessage="Telefono Invalido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblDireccion" runat="server" Font-Names="Montserrat" Text="Direccion: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Font-Names="Montserrat"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqDireccion" runat="server" controltovalidate="txtDireccion" Enabled="false" errormessage="Direccion Invalida" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblPlan" runat="server" Font-Names="Montserrat" Text="Plan: " BorderStyle="Inset"></asp:Label>
                        <asp:DropDownList ID="dwPlan" runat="server" Font-Names="Montserrat">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblFechaNac" runat="server" Font-Names="Montserrat" Text="Fecha Nacimiento: " BorderStyle="Inset" style="margin-left: 0px"></asp:Label>
            <br />
                        <asp:Calendar ID="CalFechaNac" runat="server" Font-Names="Montserrat" style="margin-left: 324px" Width="466px"></asp:Calendar>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblTipoPersona" runat="server" Font-Names="Montserrat" Text="Tipo Persona: " BorderStyle="Inset"></asp:Label>
                        <asp:DropDownList ID="dwTiposPersonas" runat="server" Font-Names="Montserrat">
                        </asp:DropDownList>
            <br />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblClave" runat="server" Font-Names="Montserrat" Text="Clave: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" Font-Names="Montserrat" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqClave" runat="server" controltovalidate="txtClave" Enabled="false" errormessage="Clave Invalida" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblRepetirClave" runat="server" Font-Names="Montserrat" Text="Repetir Clave: " BorderStyle="Inset"></asp:Label>
                        <asp:TextBox ID="txtRepetirClave" runat="server" CssClass="form-control" Font-Names="Montserrat" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqRepetirClave" runat="server" controltovalidate="txtRepetirClave" Enabled="false" errormessage="" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
                    </div>
                    <asp:Panel runat="server">
                        <div class="form-group">
            <br/>
                            <asp:LinkButton ID="btnAceptar" runat="server" Font-Names="Montserrat" OnClick="btnAceptar_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Bold="True" ForeColor="#66FFFF">Aceptar</asp:LinkButton>
                            <asp:LinkButton ID="btnCancelar" runat="server" Font-Names="Montserrat" OnClick="btnCancelar_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Bold="True" ForeColor="#66FFFF">Cancelar</asp:LinkButton>
                        </div>
                    </asp:Panel>
                    <div class="form-group">
                        <asp:ValidationSummary ID="vsUsuario" runat="server" Font-Names="Montserrat" ValidationGroup="1" BackColor="Silver" BorderColor="Red" BorderStyle="Outset" Font-Bold="True" ForeColor="Red" />
                    </div>
        <br />
                </asp:Panel>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
