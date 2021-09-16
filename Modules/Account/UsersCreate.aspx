<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsersCreate.aspx.cs" Inherits="InfogesEmape.Modules.Account.UsersCreate"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

	    <span class="labelTitleNormal">Puedes registrar los datos del usuario haciendo click en Guardar.</span>
	    <br />
        <table border="0" width="95%" class="label" cellspacing="4">
	        <tr>
		        <td width="17%">usuario</td>
		        <td width="83%" colspan="2"><asp:TextBox id="txtUserName" runat="server" CssClass="textEnabled"  ></asp:TextBox>
			        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Deberá de ingresar el nombre de usuario"
				        ControlToValidate="txtUserName">*</asp:RequiredFieldValidator></td>
	        </tr>
	        <tr>
		        <td width="17%">Descripción</td>
		        <td width="83%" colspan="2"><input type="text" name="txtDescription" size="42" id="txtDescription" runat="server" CssClass="textEnabled"  Enabled="false"  />
			        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Deberá de ingresar la descripción"
				        ControlToValidate="txtDescription">*</asp:RequiredFieldValidator></td>
	        </tr>
	        <tr>
		        <td width="17%">Email</td>
		        <td width="83%" colspan="2"><input id="txtEmailAddress" type="text" size="42" name="txtEmailAddress" runat="server" CssClass="textEnabled"  Enabled="false" >
			        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress"
				        ErrorMessage="Ingrese un correo valido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
			        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailAddress"
				        ErrorMessage="Ingrese un correo valido">*</asp:RequiredFieldValidator></td>
	        </tr>
	        <tr>
		        <td width="17%">Estado</td>
		        <td width="34%"><select size="1" name="cboStatus" id="cboStatus" style="FONT-SIZE: 8pt; WIDTH: 96px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 23px"
				        runat="server">
				        <option selected value="ACTIVO">ACTIVO</option>
				        <option value="INACTIVO">INACTIVO</option>
			        </select></td>
		        <td width="49%">&nbsp;&nbsp;&nbsp;</td>
	        </tr>
	        <tr>
		        <td width="17%" valign="top">Roles</td>
		        <td width="83%" colspan="2">
			        <table border="0" width="400" bordercolor="#cccccc" cellpadding="3" cellspacing="0">
				        <tr>
					        <td style="WIDTH: 177px"><b><font color="#467020" face="Verdana" size="2">Roles 
								        Seleccionados</font></b></td>
					        <td></td>
					        <td style="WIDTH: 179px"><b><font color="#467020" face="Verdana" size="2">Roles&nbsp;Disponibles</font></b></td>
				        </tr>
				        <tr>
					        <td valign="top" style="WIDTH: 177px">
						        <select id="cboUserRoles" style="FONT-SIZE: 8pt; WIDTH: 168px; FONT-FAMILY: Arial; HEIGHT: 80px"
							        size="5" name="cboUserRoles" runat="server">
						        </select></td>
					        <td>
						        <table border="0">
							        <tr>
								        <td><asp:Button ID="Button2" runat="server" Text="&lt;&lt;" 
                                                CssClass="buttonDefault" onclick="Button2_Click" /></td>
							        </tr>
							        <tr>
								        <td><asp:Button ID="Button3" runat="server" Text="&gt;&gt;" 
                                                CssClass="buttonDefault" onclick="Button3_Click" /></td>
							        </tr>
						        </table>
					        </td>
					        <td valign="top" style="WIDTH: 179px"><select size="5" name="cboRoles" style="FONT-SIZE: 8pt; WIDTH: 177px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 80px"
							        id="cboRoles" runat="server">
						        </select></td>
				        </tr>
			        </table>
		        </td>
	        </tr>
        </table>
        <br />
        <table border="0" width="100%" class="label">
	        <tr>
		        <td width="25%" valign="top" visible="false">Contraseña&nbsp;</td>
		        <td width="25%" valign="top" visible="false"><input type="password" id="txtPassword01" name="txtPassword01" size="15" runat="server" class="textDefault">
			        <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Password must be the same" ControlToValidate="txtPassword02"
				        ControlToCompare="txtPassword01">*</asp:CompareValidator>
			        <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword02"
				        ErrorMessage="Must be between 6 and 8 characters or numerics digits" ValidationExpression="^[a-zA-Z0-9]{6,8}$">*</asp:RegularExpressionValidator></td>
		        <td width="25%" valign="top" visible="false">Confirmar&nbsp;Contraseña</td>
		        <td width="25%" valign="top" visible="false"><input type="password" id="txtPassword02" name="txtPassword02" size="15" runat="server" class="textDefault"></td>
	        </tr>
	        <tr>
		        <td width="55%" valign="top" colspan="3">
			        <asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
			        <asp:Label id="lblMessage" runat="server" CssClass="sys-font-body-Text" ForeColor="Red"></asp:Label></td>
		        <td width="45%" valign="top" align="right">&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Grabar" CssClass="buttonDefault" />&nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" CssClass="buttonDefault" 
                        onclick="Button4_Click" Text="Cancelar" CausesValidation="False" />&nbsp;
		        </td>
	        </tr>
        </table>
        <br />
        
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
