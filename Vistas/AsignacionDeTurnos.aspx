<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionDeTurnos.aspx.cs" Inherits="Vistas.Turnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style8 {
            height: 18px;
        }
        .auto-style20 {
            margin-right: 4px;
        }
        .auto-style24 {
            width: 168px;
        }
        .auto-style25 {
            width: 168px;
            height: 23px;
        }
        .auto-style26 {
            width: 168px;
            height: 26px;
        }
        .auto-style27 {
            width: 102px;
        }
        .auto-style28 {
            width: 102px;
            height: 23px;
        }
        .auto-style29 {
            width: 102px;
            height: 26px;
        }
        .auto-style33 {
            height: 23px;
            width: 160px;
        }
        .auto-style34 {
            height: 26px;
            width: 160px;
        }
        .auto-style35 {
            width: 168px;
            height: 27px;
        }
        .auto-style36 {
            width: 102px;
            height: 27px;
        }
        .auto-style38 {
            height: 27px;
            width: 160px;
        }
        .auto-style40 {
            width: 89px;
        }
        .auto-style41 {
            width: 89px;
            height: 23px;
        }
        .auto-style42 {
            width: 89px;
            height: 27px;
        }
        .auto-style43 {
            width: 89px;
            height: 26px;
        }
        .auto-style47 {
            width: 265px;
            height: 23px;
        }
        .auto-style48 {
            width: 265px;
            height: 27px;
        }
        .auto-style49 {
            width: 265px;
            height: 26px;
        }
        .auto-style50 {
            width: 278px;
            height: 23px;
        }
        .auto-style51 {
            width: 278px;
            height: 27px;
        }
        .auto-style52 {
            width: 278px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style24">
                        <asp:HyperLink ID="hlPaginaPrincipal" runat="server" NavigateUrl="~/VistaAdmin.aspx">Volver</asp:HyperLink>
                    </td>
                    <td class="auto-style27">&nbsp;</td>
                    <td class="auto-style40">&nbsp;</td>
                    <td colspan="3">&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:Label ID="lblUsuarioLogueado" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8" colspan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblUsuarioMed" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Asignacion de Turnos"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <br />
                        <asp:Label ID="lblBuscar1" runat="server" Text="Especialidad:"></asp:Label>
                        </td>
                    <td class="auto-style28">
                        <br />
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style41">
                        <br />
                    </td>
                    <td class="auto-style33">
                        <br />
                    </td>
                    <td class="auto-style47">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style35">
                        <br />
                        <asp:Label ID="lblBuscar2" runat="server" Text="Medico:"></asp:Label>
                        </td>
                    <td class="auto-style36">
                        <br />
                        <asp:DropDownList ID="DropDownList4" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style42">&nbsp;</td>
                    <td class="auto-style38">&nbsp;</td>
                    <td class="auto-style48"></td>
                    <td class="auto-style51"></td>
                </tr>
                <tr>
                    <td class="auto-style25">
                        <br />
                        <asp:Label ID="lblBuscar" runat="server" Text="Dia:"></asp:Label>
                        </td>
                    <td class="auto-style28">
                        <br />
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="auto-style20">
                            <asp:ListItem>Lunes</asp:ListItem>
                            <asp:ListItem>Martes</asp:ListItem>
                            <asp:ListItem>Miercoles</asp:ListItem>
                            <asp:ListItem>Jueves</asp:ListItem>
                            <asp:ListItem>Viernes</asp:ListItem>
                            <asp:ListItem>Sabado</asp:ListItem>
                            <asp:ListItem>Domingo</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                    <td class="auto-style41">
                        <br />
                    </td>
                    <td class="auto-style33">&nbsp;</td>
                    <td class="auto-style47">&nbsp;</td>
                    <td class="auto-style50">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">
                        <br />
                        <asp:Label ID="lblBuscar0" runat="server" Text="Horario:"></asp:Label>
                        </td>
                    <td class="auto-style29">
                        <br />
                        <asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style34"></td>
                    <td class="auto-style49">&nbsp;</td>
                    <td class="auto-style52">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">
                        <br />
                        <asp:Label ID="lblBuscar3" runat="server" Text="Ingresar DNI del Paciente:"></asp:Label>
                        </td>
                    <td class="auto-style29">
                        <br />
                        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style43">
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Asignar" />
                    </td>
                    <td class="auto-style34">&nbsp;</td>
                    <td class="auto-style49">&nbsp;</td>
                    <td class="auto-style52">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style29">
                        <br />
                    </td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style34">&nbsp;</td>
                    <td class="auto-style49">&nbsp;</td>
                    <td class="auto-style52">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
