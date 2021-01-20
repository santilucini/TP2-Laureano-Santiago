<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UI.Web.login" MasterPageFile="~/Basico/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="../CSS/LoginStyle3.css"/>	
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" style="height: 45px"></td>
                <td class="auto-style2" style="height: 45px"></td>
                <td style="height: 45px">
<div class="titulo">
    
   
    <asp:Label ID="lblBienvenido" runat="server" Text="    ¡Bienvenido al Sistema!" BackColor="#66FFFF" BorderColor="#000066" BorderStyle="Groove" Font-Bold="True" Font-Names="Montserrat" Font-Overline="False" Font-Size="Large" Width="225px" CssClass="separator"></asp:Label>
          
</div>




                    </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" BorderStyle="Inset" Font-Bold="True" Font-Names="Montserrat"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtUsuario" runat="server" Font-Names="Montserrat"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
        <asp:Label ID="lblClave" runat="server" Text="Clave" BorderStyle="Inset" Font-Bold="True" Font-Names="Montserrat"></asp:Label>
                </td>
                <td class="auto-style1">
        <asp:TextBox ID="txtClave" runat="server" Font-Names="Montserrat"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <button id="BtnIngresar" runat="server" type="submit">
                        Ingresar
                    </button>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" style="height: 45px">
                    </td>
                <td class="auto-style2" style="height: 45px"></td>
                <td style="height: 45px">
                    </td>
            </tr>
        </table>
    
 </asp:Content>

