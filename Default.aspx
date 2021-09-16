<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InfogesEmape._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>INFOGES - Informado para Gestionar </title>
    <link href="Styles/style01.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .formRow
    {
        float: left;
        border-right: solid 1px #cbcbcb;
        height: 200px;
    }
    br
    {
        clear: both; 
    }
    h5
    {
        font: bold 26px Verdana, Arial, Sans-serif;
        color: #7f97c0;
    }
    .titleLogin
    {
        font: bold 12px Verdana, Arial, Sans-serif;
        color: #7b7b7b;
    }
    .skinTextPwd {
        BORDER: #7f97c0 1px solid; 
    }
        .style1
        {
            width: 149px;
        }
        .style2
        {
            width: 238px;
            height: 54px;
        }
        .style3
        {
            width: 281px;
            height: 54px;
        }
        .style4
        {
            height: 54px;
        }
    </style>    
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <center>
    
        <br /><br /><br />
        <table width="70%">
            <tr>
                <td align="left" class="style2">&nbsp;</td>
                <td align="left" class="style3">
                    </td><td align="center" class="style4"><h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h2></td>
            </tr>
        </table>
        <br />
        <br />
        <table width="70%">
            <tr>
                <td colspan="3" valign="top" align="left">&nbsp;<h2></h2></td>
            </tr>
            <tr>
                <td valign="top" align="left"><br /><br /><img src="Images/logo_action.png" 
                        style="height: 263px; width: 501px" /></td>
                <td width="50px;">&nbsp;</td>
                <td align="left">
                <div>
                <center><table width="40%" cellpadding="5" cellspacing="5">
                    <tr><td align="left" colspan="2"><br /><br /><span class="titleLogin">Ingrese sus credenciales de acceso USUARIO :9999 PASWORD:1</span><br /><br /></td></tr>
                    <tr>    
                        <td align="left">Usuario:</td>
                        <td align="left" class="style1"><asp:TextBox ID="TextBox1" runat="server" 
                                MaxLength="20" Width="137px" Font-Bold="True" Font-Names="Tahoma" 
                                Font-Size="Medium" CssClass="skinTextPwd"></asp:TextBox>&nbsp;</td>
                    </tr>
                    <tr>    
                        <td align="left">Contraseña:</td>
                        <td align="left" class="style1"><asp:TextBox ID="TextBox2" runat="server" CssClass="skinTextPwd" Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium" TextMode="Password" MaxLength="20" Width="137px"></asp:TextBox>&nbsp;</td>
                    </tr>    
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="Button1" CssClass="buttonDefault" runat="server" Text="Ingresar" OnClick="Button1_Click" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                ErrorMessage="Se requiere usuario de acceso."></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                ErrorMessage="Se requiere contraseña de acceso."></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr><td colspan="2">&nbsp;<asp:Label ID="lblMessageLogin" runat="server" Font-Bold="True" ForeColor="#C00000"
                            Text="Error al acceder!!" Visible="False"></asp:Label></td></tr>
                </table></center>
                </div>
               &nbsp;</td>
            </tr>
        </table>
        </center>    
    
    </div>
    </form>
</body>
</html>
