using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DevExpress.XtraPivotGrid;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Utils;


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmSeguimientoSnipCubo : System.Web.UI.Page
    {




        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");

            if (!Page.IsPostBack)
            {

            }
        }

        #region LoadAvanceObra
        protected void LoadAvanceObra(object sender, EventArgs e)
        {
            this.Load_Grid();
        }
        #endregion

        #region Load_Grid
        protected void Load_Grid()
        {
            DataSet ds3 = new DataSet(), ds1 = new DataSet(), ds2 = new DataSet();

            ds3 = Code.Logic.Forms.Consulta.InfoGesConsulta2009.SearchAllSeguimientoSnipCubo("", "", (string)(Session["IdBaseDeDatos"]));
            ASPxPivotGridConsultaObraxValorizacion.DataSource = ds3.Tables[0];
            ASPxPivotGridConsultaObraxValorizacion.DataBind();


        }
        #endregion


        #region Print
        void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
 
                string contentType = "", fileName = "";
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        ASPxPivotGridExporter1.ExportToXls(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
                Response.BinaryWrite(buffer);
                Response.End();


            }
        }

        protected void buttonOpen_Click(object sender, EventArgs e)
        {
            Export(false);
        }
        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        #endregion
    }
}
