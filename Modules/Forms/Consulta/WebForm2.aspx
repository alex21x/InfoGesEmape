<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.WebForm2" %>

<%@ Register assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    	<dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Height="169px" OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" Width="698px" ActiveTabIndex="0">
			<TabPages>
				<dx:TabPage Text="MENU1">
					<ContentCollection>
						<dx:ContentControl runat="server">
							
							<dx:ASPxDashboard ID="ASPxDashboard1" runat="server" DashboardId="" DashboardState="" DashboardStorageFolder="C:\Users\desarrollo02\Desktop\obras\obras\InfoGesEmape\InfoGesEmape\xml" Height="835px" Width="879px">
								<ClientSideEvents ActionAvailabilityChanged="" BeforeRender="" CustomizeMenuItems="" DashboardBeginUpdate="" DashboardChanged="" DashboardEndUpdate="" DashboardStateChanged="" DynamicLookUpValuesLoaded="" ItemBeginUpdate="" ItemEndUpdate="" />
							</dx:ASPxDashboard>
							
						</dx:ContentControl>
					</ContentCollection>
				</dx:TabPage>
				<dx:TabPage Text="MENU2">
					<ContentCollection>
						<dx:ContentControl runat="server">
						</dx:ContentControl>
					</ContentCollection>
				</dx:TabPage>
				<dx:TabPage Text="MENU3">
					<ContentCollection>
						<dx:ContentControl runat="server">
						</dx:ContentControl>
					</ContentCollection>
				</dx:TabPage>
			</TabPages>




		</dx:ASPxPageControl>
    </form>
</body>
</html>
