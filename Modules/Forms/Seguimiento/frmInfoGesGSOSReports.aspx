<%@ Page Language="C#"  AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOSReports.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOSReports" 
    Title="InfoGesConsultas" %>


<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Consulta Expediente Administrativo SIAF</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="principal" >
    	<dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" Width="800px">
		</dx:ASPxWebDocumentViewer>
    </div>    
</form>
</body>
</html>
