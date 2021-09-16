<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.WebForm3" %>

<%@ Register assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<dx:ASPxDashboard ID="ASPxDashboard1" runat="server" DashboardStorageFolder="C:\Users\desarrollo02\Desktop\obras\obras\InfoGesEmape\InfoGesEmape\xml" WorkingMode="ViewerOnly">
			</dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>
