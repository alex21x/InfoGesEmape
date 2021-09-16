#region Using Directives
using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
#endregion

namespace InfogesEmape.Code.Logic.Forms.Consulta
{
    public class Ejecutora
    {

        #region SearchAllEjecutora
        public static DataSet SearchAllEjecutora()
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchAllEjecutora();
        }
        #endregion

        #region SearchAllEjecutoraUnion
        public static DataSet SearchAllEjecutoraUnion(string IdSecEjec, string BaseDeDatos)
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchAllEjecutoraUnion(IdSecEjec,BaseDeDatos);
        }
        #endregion

        //#region SearchAllEjecutoraProgramacion
        //public static DataSet SearchAllEjecutoraProgramacion(string pIdAnoEje)
        //{
        //    return Code.Data.Forms.Consulta.Ejecutora.SearchAllEjecutoraProgramacion(pIdAnoEje);
        //}
        //#endregion

        #region SearchAllEnqueGasta
        public static DataSet SearchAllEnqueGasta(string IdCondicion1, string IdCondicion2)
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchAllEnqueGasta(IdCondicion1, IdCondicion2);
        }
        #endregion

        #region SearchEjecutora
        public static DataSet SearchEjecutora(string IdSec_Ejec)
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchEjecutora(IdSec_Ejec);
        }
        #endregion

        #region SearchEjecutoraCC
        public static DataSet SearchEjecutoraCC(string IdSec_Ejec)
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchEjecutoraCC(IdSec_Ejec);
        }
        #endregion

        #region SearchEjecutora1
        public static DataSet SearchEjecutora1()
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchEjecutora1();
        }
        #endregion

        public static DataSet GetUserEjecutora(string userId)
        {
            return Code.Data.Forms.Consulta.Ejecutora.GetUserEjecutora(userId);
        }


        #region SearchEjecutoraUser
        public static DataSet SearchEjecutoraUser(string IdSUser)
        {
            return Code.Data.Forms.Consulta.Ejecutora.SearchEjecutoraUser(IdSUser);
        }
        #endregion
 
    }
}
