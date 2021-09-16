<%@ Page Language="C#"  MasterPageFile="~/Modules/MasterPage.Master"  AutoEventWireup="true"  Title="InfoGesConsultas"
 CodeBehind="InfoGesDashBoard.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.InfoGesDashBoard" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>



<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="principal" >

     <table>
     <tr>
     <td>
         <dx:ASPxDashboard   ID="ASPxDashboard1" runat="server" OnCustomParameters
             OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
             DashboardXmlPath="~/xml/xmlDashboard18.xml" >
        </dx:ASPxDashboard>

     </td>
     </tr>
     </table>



   </div> 
</asp:Content>
