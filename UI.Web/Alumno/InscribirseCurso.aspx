<%@ Page Title="" Language="C#" MasterPageFile="~/Basico/Site.Master" AutoEventWireup="true" CodeBehind="InscribirseCurso.aspx.cs" Inherits="UI.Web.Alumno.InscribirseCurso" %>
<%@ MasterType VirtualPath="~/Basico/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="GridViewInsc" runat="server" AutoGenerateColumns="False" CssClass="table-striped" DataKeyNames="ID" HorizontalAlign="Center" OnSelectedIndexChanged="GridViewInsc_SelectedIndexChanged" style="align-self: center; position: relative; font-size: 20px; left: -321px; top: 36px;">
    <Columns>
        <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
        <asp:BoundField DataField="DescComision" HeaderText="Comision" />
        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
    </Columns>
    <SelectedRowStyle BackColor="Black" ForeColor="White" />
</asp:GridView>
<asp:GridView ID="GridViewCurso" runat="server" AutoGenerateColumns="False" CssClass="table-striped" HorizontalAlign="Right" style="align-self: center; position: relative; font-size: 20px; left: -644px; top: 42px; margin-top: 0px;">
    <Columns>
        <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
        <asp:BoundField DataField="DescComision" HeaderText="Comision" />
        <asp:BoundField DataField="Nota" HeaderText="Nota" />
        <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
    </Columns>
</asp:GridView>
<asp:Button ID="btnInscribir" runat="server" CssClass="btn-primary" OnClick="btnInscribir_Click" style="align-self: center; position: relative; font-size: 20px; left: 27px; top: 222px;" Text="Inscribirse" />
</asp:Content>

