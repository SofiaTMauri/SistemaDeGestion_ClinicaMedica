<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="Vistas.ModificarMeidco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 214px;
        }
        .auto-style3 {
            width: 100%;
            height: 158px;
        }
        .auto-style4 {
            width: 296px;
        }
        .auto-style5 {
            width: 211px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Medicos.aspx">Volver</asp:LinkButton>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>
                    <asp:Label ID="LblUsuarioLogueado" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Modificar usuario de Medico"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style3">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Ingrese Usuario:</td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Width="220px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Ingrese la nueva contraseña:</td>
                <td>
                    <asp:TextBox ID="txtContraseña" runat="server" Width="220px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Ingrese una contraseña" ForeColor="Red" ValidationGroup="grupo1">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Repita la contraseña:</td>
                <td>
                    <asp:TextBox ID="txtContraseña2" runat="server" Width="220px"></asp:TextBox>
                    <asp:CompareValidator ID="cmpContraseña" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtContraseña2" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" ValidationGroup="grupo1">*</asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="group1" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Modificar Usuario" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
