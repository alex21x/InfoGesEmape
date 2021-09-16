<%@ Page CodeBehind="AccountsUsers_Edit.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="AdieraManager.Modules.MainData.AccountsUsers_Edit" %>
<HTML>
	<HEAD>
		<link REL="stylesheet" type="text/css" href="/AdieraManager/styles/scanner.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table border="0" width="95%">
				<tr>
					<td width="89%"><span class="sys-font-heading3 sys-rhp-color-title"><img border="0" src="/AdieraManager/images/Subscriber2.gif" width="30" height="30">
        Editar&nbsp;Usuario: <u><asp:Label id="lblUser" runat="server">Label</asp:Label></u></span></td>
					<td width="11%" align="right">&nbsp;<a href="/AdieraManager/Modules/MainData/AccountsUsers_List.aspx"><img border="0" src="/AdieraManager/images/Subscriber_List2.gif" alt="Return a User List"
								align="absMiddle" width="30" height="30"></a></td>
				</tr>
			</table>
			<P>
				<span class="sys-font-body-Text">
					<SPAN class="sys-font-body-Text">Puedes modificar los datos 
del usuario haciendo click en Guardar.</SPAN>&nbsp;
				</span>&nbsp;</P>
			<table border="0" width="95%" class="sys-font-body" cellspacing="4">
				<tr>
					<td width="17%">Descripción</td>
					<td width="83%" colspan="2"><input type="text" id="txtDescription" name="txtDescription" size="52" runat="server">
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Field description is required"
							ControlToValidate="txtDescription">*</asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td width="17%">Email</td>
					<td width="83%" colspan="2"><INPUT id="txtEmailAddress" type="text" size="30" name="txtEmailAddress" runat="server">
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress"
							ErrorMessage="Email Address is invalid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailAddress"
							ErrorMessage="Email address is required">*</asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td width="17%">Estado</td>
					<td width="34%"><select size="1" id="cboStatus" name="cboStatus" style="FONT-SIZE: 8pt; WIDTH: 96px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 23px"
							runat="server">
							<option selected value="ACTIVO">ACTIVO</option>
							<option value="INACTIVO">INACTIVO</option>
						</select></td>
					<td width="49%">&nbsp;&nbsp;</td>
				</tr>
				<tr>
					<td width="17%" valign="top">Roles</td>
					<td width="83%" colspan="2">
						<table border="0" width="300" bordercolor="#cccccc" cellpadding="3" cellspacing="0">
							<tr>
								<td height="24"><b><font color="#467020" face="Verdana" size="2">Roles del Usuario</font></b></td>
								<td width="55" height="24"></td>
								<td height="24"><b><font color="#467020" face="Verdana" size="2">Roles&nbsp;Disponibles</font></b></td>
							</tr>
							<tr>
								<td valign="top">
									<SELECT id="cboUserRoles" style="FONT-SIZE: 8pt; WIDTH: 144px; FONT-FAMILY: Arial; HEIGHT: 80px"
										size="5" name="cboUserRoles" runat="server">
									</SELECT></td>
								<td>
									<table border="0" height="52" width="100%" align="center">
										<tr>
											<td>
												<input class="sys-button-options" type="button" value=" << " name="cmdAdd" id="cmdAdd"
													runat="server">
											</td>
										</tr>
										<tr>
											<td>
												<input class="sys-button-options" type="button" value=" >> " name="cmdDelete" id="cmdDelete"
													runat="server">
											</td>
										</tr>
									</table>
								</td>
								<td valign="top"><select size="5" name="cboRoles" style="FONT-SIZE: 8pt; WIDTH: 144px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 80px"
										id="cboRoles" runat="server">
									</select></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<P>
				<HR width="95%" SIZE="2" color="#d3d3d3" align="left">
				<span class="sys-font-body-Text">Ingresa el nuevo password si
      deseas cambiar el anterior.</span>
			&nbsp;
			<P></P>
			<table border="0" width="95%" class="sys-font-body">
				<tr>
					<td width="25%">Nueva Contraseña
					</td>
					<td width="25%"><input type="password" id="txtPassword01" name="txtPassword01" size="15" runat="server">
						<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Password should be the same"
							ControlToValidate="txtPassword02" ControlToCompare="txtPassword01">*</asp:CompareValidator>
						<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword02"
							ErrorMessage="Must be between 6 and 8 characters or numerics digits" ValidationExpression="^[a-zA-Z0-9]{6,8}$">*</asp:RegularExpressionValidator></td>
					<td width="25%">Confirmar&nbsp;Contraseña</td>
					<td width="25%"><input type="password" id="txtPassword02" name="txtPassword02" size="15" runat="server"></td>
				</tr>
				<tr>
					<td width="75%" colspan="3">
						<asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></td>
					<td width="25%">
						<p align="right"><input type="button" value="Guardar" id="cmdSave" name="cmdSave" class="sys-button-options"
								style="WIDTH: 77px; POSITION: relative; HEIGHT: 25px" runat="server"></p>
					</td>
				</tr>
			</table>
			<P>
				<HR width="95%" SIZE="2" color="#d3d3d3" align="left">
				<span class="sys-font-body-Text"> Tambien&nbsp;puedes eliminar al usuario presionando 
      el botón Borrar.</span>
			<P></P>
			<table border="0" width="95%" class="sys-font-body">
				<tr>
					<td width="75%"></td>
					<td width="25%">
						<p align="right"><input type="button" value="Borrar" id="idDelete" name="cmdDelete" class="sys-button-options"
								style="WIDTH: 77px; POSITION: relative; HEIGHT: 25px" runat="server"></p>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
