<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes" %>

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
            width: 238px;
        }
        .auto-style4 {
            margin-left: 17px;
        }
        .auto-style5 {
            margin-left: 19px;
        }
        .auto-style6 {
            width: 131px;
        }
        .auto-style8 {
            width: 238px;
            height: 23px;
        }
        .auto-style9 {
            width: 131px;
            height: 23px;
        }
        .auto-style11 {
            height: 23px;
        }
        .auto-style12 {
            width: 257px;
        }
        .auto-style13 {
            width: 257px;
            height: 23px;
        }
        .auto-style14 {
            margin-left: 112px;
        }
        .auto-style15 {
            width: 260px;
        }
        .auto-style16 {
            width: 260px;
            height: 23px;
        }
        .auto-style17 {
            width: 201px;
        }
        .auto-style18 {
            width: 201px;
            height: 23px;
        }
        .auto-style19 {
            width: 266px;
        }
        .auto-style20 {
            width: 235px;
        }
        .auto-style21 {
            width: 235px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style19">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/VistaAdmin.aspx">Volver</asp:HyperLink>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>
                    <asp:Label ID="LblUsuarioLogueado" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Underline="False" Text="Informes"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Informe sobre presentes segun fecha"></asp:Label>
                </td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style20">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Desde:"></asp:Label>
                    <asp:DropDownList ID="ddlMesInicio" runat="server" CssClass="auto-style4">
                        <asp:ListItem>Enero</asp:ListItem>
                        <asp:ListItem>Febrero</asp:ListItem>
                        <asp:ListItem>Marzo</asp:ListItem>
                        <asp:ListItem>Abril</asp:ListItem>
                        <asp:ListItem>Mayo</asp:ListItem>
                        <asp:ListItem>Junio</asp:ListItem>
                        <asp:ListItem>Julio</asp:ListItem>
                        <asp:ListItem>Agosto</asp:ListItem>
                        <asp:ListItem>Septiembre</asp:ListItem>
                        <asp:ListItem>Octubre</asp:ListItem>
                        <asp:ListItem>Noviembre</asp:ListItem>
                        <asp:ListItem>Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlAñoInicio" runat="server">
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">
                    <asp:Label ID="Label4" runat="server" Text="Hasta:"></asp:Label>
                    <asp:DropDownList ID="ddlMesFinal" runat="server" CssClass="auto-style5">
                        <asp:ListItem>Enero</asp:ListItem>
                        <asp:ListItem>Febrero</asp:ListItem>
                        <asp:ListItem>Marzo</asp:ListItem>
                        <asp:ListItem>Abril</asp:ListItem>
                        <asp:ListItem>Mayo</asp:ListItem>
                        <asp:ListItem>Junio</asp:ListItem>
                        <asp:ListItem>Julio</asp:ListItem>
                        <asp:ListItem>Agosto</asp:ListItem>
                        <asp:ListItem>Septiembre</asp:ListItem>
                        <asp:ListItem>Octubre</asp:ListItem>
                        <asp:ListItem>Noviembre</asp:ListItem>
                        <asp:ListItem>Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAñoFinal" runat="server">
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Total de Presentes:"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="lblPresentes" runat="server"></asp:Label>
                </td>
                <td class="auto-style20">
                    <asp:Label ID="Label5" runat="server" Text="Total de Ausentes:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAusentes" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style9"></td>
                <td class="auto-style21"></td>
                <td class="auto-style11"></td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label7" runat="server" Text="Informe sobre presentes segun sexo:"></asp:Label>
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label8" runat="server" Text="Sexo:"></asp:Label>
                    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="auto-style14">
                        <asp:ListItem>Femenino</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>No binario</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Total de Presentes:</td>
                <td class="auto-style17">
                    <asp:Label ID="lblPresentesSexo" runat="server"></asp:Label>
                </td>
                <td class="auto-style15">Total de Ausentes:</td>
                <td>
                    <asp:Label ID="lblAusentesSexo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style18"></td>
                <td class="auto-style16"></td>
                <td class="auto-style11"></td>
            </tr>
        </table>
    </form>
</body>
</html>
