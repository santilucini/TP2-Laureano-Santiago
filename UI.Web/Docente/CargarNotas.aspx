<%@ Page Title="" Language="C#" MasterPageFile="~/Basico/Site.Master" AutoEventWireup="true" CodeBehind="CargarNotas.aspx.cs" Inherits="UI.Web.Docente.CargarNotas" %>
<%@ MasterType VirtualPath="~/Basico/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" CssClass="table-striped" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="GridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" style="align-self:center;position:relative;font-size:20px;" Font-Names="Montserrat" ForeColor="#3333FF">
            <Columns>
                <asp:BoundField DataField="NombreAlumno" HeaderText="Nombre" />
                <asp:BoundField DataField="ApellidoAlumno" HeaderText="Apellido" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:BoundField DataField="descMateria" HeaderText="Materia" ReadOnly="True" SortExpression="descMateria" />
                <asp:BoundField DataField="descComision" HeaderText="Comision" SortExpression="descComision" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <HeaderStyle BackColor="#CCCCCC" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Panel ID="gridActionPanel" runat="server" HorizontalAlign="Center">
            <asp:LinkButton ID="btnCorregir" runat="server" OnClick="btnCorregir_Click" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua">Cargar</asp:LinkButton>
        </asp:Panel>
        <br/>
        <asp:Panel ID="formPanel" runat="server" CssClass="align-content-center" HorizontalAlign="Center" Visible="false">
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" BorderStyle="Inset" Font-Names="Montserrat"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:" BorderStyle="Inset" Font-Names="Montserrat"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <br />
            <div class="form-group">
                <asp:Label ID="lblNota" runat="server" Text="Nota:" BorderStyle="Inset" Font-Names="Montserrat"></asp:Label>
                <asp:TextBox ID="txtNota" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNota" runat="server" controltovalidate="txtNota" Enabled="false" errormessage="Valor ingresado no es numerico" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            </div>
            <br/>
            <div class="form-group">
                <br/>
                <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua"></asp:LinkButton>
                <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" BackColor="#CCCCCC" BorderStyle="Outset" Font-Names="Montserrat" ForeColor="Aqua"></asp:LinkButton>
            </div>
        </asp:Panel>
        <asp:Panel ID="gridPanelFormCorregir" runat="server" HorizontalAlign="Center" Visible="false">
        </asp:Panel>
        <div class="form-group">
            <asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="1" BackColor="Silver" BorderColor="Red" BorderStyle="Solid" Font-Bold="True" Font-Names="Montserrat" ForeColor="Red" />
        </div>
    </asp:Panel>
</asp:Content>
