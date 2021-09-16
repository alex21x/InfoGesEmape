<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsersEdit.aspx.cs" Inherits="InfogesEmape.Modules.Account.UsersEdit"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

	    <span class="labelTitleNormal">Puedes modificar los datos del usuario haciendo click en Guardar.</span>
	    <br />
        <table border="0" width="95%" class="label" cellspacing="4">
	        <tr>
		        <td width="17%">Usuario</td>
		        <td width="83%" colspan="2"><asp:TextBox id="txtUserName" runat="server" CssClass="textEnabled"  Enabled="false" ></asp:TextBox>
	        </tr>
	        <tr>
		        <td width="17%">Descripción</td>
		        <td width="83%" colspan="2"> 
		            <asp:TextBox  id="txtDescription" name="txtDescription1" runat="server" CssClass="textEnabled"  Enabled="false"></asp:TextBox>
		           </td>
	        </tr>
	        <tr>
		        <td width="17%">Email</td>
		        <td width="83%" colspan="2"><asp:TextBox CssClass="textEnabled"  Enabled="false" id="txtEmailAddress" type="text" size="42" name="txtEmailAddress" runat="server" ></asp:TextBox>
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
					        <td valign="top" style="WIDTH: 179px">
                                <select size="5" name="cboRoles" style="FONT-SIZE: 8pt; WIDTH: 177px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 80px; top: 0px; left: 0px;"
							        id="cboRoles" runat="server">
						        </select></td>
				        </tr>
			        </table>
		        </td>
	        </tr>
            <tr>
		        <td width="17%" valign="top">Ejecutora</td>
		        <td width="83%" colspan="2">
			        <table border="0" width="400" bordercolor="#cccccc" cellpadding="3" cellspacing="0">
				        <tr>
					        <td style="WIDTH: 177px"><b><font color="#467020" face="Verdana" size="2">Ejecutoras 
								        Seleccionados</font></b></td>
					        <td></td>
					        <td style="WIDTH: 179px"><b><font color="#467020" face="Verdana" size="2">Ejecutoras&nbsp;Disponibles</font></b></td>
				        </tr>
				        <tr>
					        <td valign="top" style="WIDTH: 177px">
						        <select id="CboUjecutoraSeleccionadas" style="FONT-SIZE: 8pt; WIDTH: 406px; FONT-FAMILY: Arial; HEIGHT: 80px"
							        size="5" name="CboUjecutoraSeleccionadas" runat="server">
						        </select></td>
					        <td>
						        <table border="0">
							        <tr>
								        <td><asp:Button ID="Button6" runat="server" Text="&lt;&lt;" 
                                                CssClass="buttonDefault" onclick="onClickAddEjecutora" /></td>
							        </tr>
							        <tr>
								        <td><asp:Button ID="Button7" runat="server" Text="&gt;&gt;" 
                                                CssClass="buttonDefault" onclick="onClickRemoveEjecutora" /></td>
							        </tr>
						        </table>
					        </td>
					        <td valign="top" style="WIDTH: 179px">
                                <select size="5" name="cboEjecutoras" style="FONT-SIZE: 8pt; WIDTH: 453px; FONT-FAMILY: Arial; POSITION: relative; HEIGHT: 80px; top: 0px; left: 0px;"
							        id="cboEjecutoras" runat="server">
						        </select></td>
				        </tr>
			        </table>
		        </td>
            </tr>
        </table>
        <br />
        <hr align="left" width="95%" color="#d3d3d3" size="2">
        <table border="0" width="100%" class="label">
	        <tr>
		           <td width="25%" valign="top" visible="false"><input type="password" id="txtPassword01" name="txtPassword01" size="15" runat="server" class="textDefault"  visible="false">
			        <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Password must be the same" ControlToValidate="txtPassword02"
				        ControlToCompare="txtPassword01">*</asp:CompareValidator>
			        <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword02"
				        ErrorMessage="Must be between 6 and 8 characters or numerics digits" ValidationExpression="^[a-zA-Z0-9]{6,8}$">*</asp:RegularExpressionValidator></td>
		        
		        <td width="25%" valign="top"  visible="false"><input type="password" id="txtPassword02" name="txtPassword02" size="15" runat="server" class="textDefault" visible="false"></td>
	        </tr>
	        <tr>
		        <td width="55%" valign="top" colspan="2">
			        <asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
			        <asp:Label id="lblMessage" runat="server" CssClass="sys-font-body-Text" ForeColor="Red"></asp:Label></td>
		        <td width="45%" valign="top" align="right">&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Grabar" CssClass="buttonDefault" Visible="false" />&nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" CssClass="buttonDefault" 
                        onclick="Button4_Click" Text="Cancelar" CausesValidation="False"   Visible="false" />&nbsp;
		        </td>
	        </tr>
        </table>
        <table width="100%" class="label">
            <tr><td align="right"><asp:Button ID="Button5" runat="server" onclick="Button5_Click" CssClass="buttonDefault" Text="Borrar"  visible="false" /></td></tr>
        </table>        
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
