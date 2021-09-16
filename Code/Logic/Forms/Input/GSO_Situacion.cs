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

namespace InfogesEmape.Code.Logic.Forms.Input
{
    public class GSO_Situacion
    {

        #region GSOEstadoSituacional
        public static DataSet GSOEstadoSituacional(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Consulta.GSO_Obras.GSOEstadoSituacional(IdBaseDeDatos);
        }
        #endregion

        #region GsoSearchAll
        public static DataSet GsoSearchAllAvance(string IdSemana, string IdUsuario, string IdPassword)
        {
            return Code.Data.Forms.Input.GSO_Situacion.GsoSearchAllAvance(IdSemana,IdUsuario,IdPassword);
        }
        #endregion
        public static DataSet SeachAllSemana(string lcCadena)
        {
            return Code.Data.Forms.Input.GSO_Situacion.SeachAllSemana(lcCadena);
        }

        public static DataSet SeachAllCoordinador(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Input.GSO_Situacion.SeachAllCoordinador(IdBaseDeDatos);
        }

        #region SeachAllCoordinadorRegistro
        public static DataSet SeachAllCoordinadorRegistro(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Input.GSO_Situacion.SeachAllCoordinadorRegistro(IdBaseDeDatos);
        }		
		public static string UpdatedGsoAvance(DataTable parameterValues, string pIdPersona)
        {
            return Code.Data.Forms.Input.GSO_Situacion.UpdatedGsoAvance(parameterValues, pIdPersona);
        }
		#endregion		

		#region UpdatedGsoAvanceRow
		public static string UpdatedGsoAvanceRow(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.UpdatedGsoAvanceRow(parameterValues, pId);
        }
        #endregion

        #region Coordinador
        #region insertRowCoordinador
        public static string insertRowCoordinador(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.insertRowCoordinador(parameterValues, pId);
        }
        #endregion
        #region UpdatedRowCoordinador
        public static string UpdatedRowCoordinador(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.UpdatedRowCoordinador(parameterValues, pId);
        }
        #endregion
        #region DeletedRowCoordinador
        public static string DeletedRowCoordinador(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.DeletedRowCoordinador(parameterValues, pId);
        }
        #endregion
        #endregion


        #region CoordinadorContrato
        #region insertRowCoordinadorContrato
        public static string insertRowCoordinadorContrato(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.insertRowCoordinadorContrato(parameterValues, pId);
        }
        #endregion
        #region UpdatedRowCoordinadorContrato
        public static string UpdatedRowCoordinadorContrato(string[] parameterValues, string pIdPersona, string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.UpdatedRowCoordinadorContrato(parameterValues, pIdPersona, pId);
        }
        #endregion
        #region DeletedRowCoordinadorContrato
        public static string DeletedRowCoordinadorContrato(string pId)
        {
            return Code.Data.Forms.Input.GSO_Situacion.DeletedRowCoordinadorContrato( pId);
        }
        #endregion
        #endregion


        #region SearchCoordinadorContrato
        public static DataSet SearchCoordinadorContrato(string IdPersona)
        {
            return Code.Data.Forms.Input.GSO_Situacion.SearchCoordinadorContrato(IdPersona);
        }
        public static DataSet SearchCoordinadorContrato(string pIdPersona, string pIdActProy)
        {
            return Code.Data.Forms.Input.GSO_Situacion.SearchCoordinadorContrato(pIdPersona, pIdActProy);
        }
        #endregion
        #region SearchDescripcion
        public static DataSet SearchDescripcion(string IdPersona)
        {
            return Code.Data.Forms.Input.GSO_Situacion.SearchDescripcion(IdPersona);
        }
        #endregion
    }
}
