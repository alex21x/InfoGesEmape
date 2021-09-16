using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using System.Web.Services;
//using InfoGesConsultas.ServiceReference;
using System.Collections.Specialized;
using System.Text;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;


//http://ofi5.mef.gob.pe/sosem2/wsSosem.asmx


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmConfiguracionTransmision : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {


            if (Session["baseURL"] == null)
            {
                Session["baseURL"] = "http://ofi5.mef.gob.pe/integracion/mosip.aspx?codigo=";
                Session["baseURL"] = "http://ofi5.mef.gob.pe/integracion/mosipResumen.aspx?codigo=";
            }

        }
        #endregion

        protected void LoadASPxGridview(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();

            ds3 = Code.Logic.Forms.Consulta.ConfiguracionTransmision.SearchAllParOpeTransmision();
            ASPxGridview1.DataSource = ds3.Tables[0];
            ASPxGridview1.DataBind();
        }




    }
}
