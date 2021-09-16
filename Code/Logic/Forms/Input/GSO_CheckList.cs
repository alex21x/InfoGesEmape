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
    public class GSO_CheckList
    {

        #region CheckList

        #region SeachAllCheckList
        public static DataSet SeachAllCheckList(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Input.GSO_CheckList.SeachAllCheckList(IdBaseDeDatos);
        }
        #endregion
        #region insertRowCheckList
        public static string insertRowCheckList(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.insertRowCheckList(parameterValues, pId);
        }
        #endregion
        #region UpdatedRowCheckList
        public static string UpdatedRowCheckList(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.UpdatedRowCheckList(parameterValues, pId);
        }
        #endregion
        #region DeletedRowCoordinador
        public static string DeletedRowCheckList(string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.DeletedRowCheckList(pId);
        }
        #endregion

        #endregion

        #region CheckListActividades

        #region SearchAllCheckListActividades
        public static DataSet SearchAllCheckListActividades(string pIdCheckList)
        {
            return Code.Data.Forms.Input.GSO_CheckList.SearchAllCheckListActividades(pIdCheckList);
        }
        #endregion
        #region insertRowCheckListActividades
        public static string insertRowCheckListActividades(string[] parameterValues)
        {
            return Code.Data.Forms.Input.GSO_CheckList.insertRowCheckListActividades(parameterValues);
        }
        #endregion
        #region UpdatedRowCheckListActividade
        public static string UpdatedRowCheckListActividades(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.UpdatedRowCheckListActividades(parameterValues,  pId);
        }
        #endregion
        #region DeletedRowCheckListActividade
        public static string DeletedRowCheckListActividades(string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.DeletedRowCheckListActividades(pId);
        }
        #endregion

        #endregion

        #region Tipologia

        #region SeachAllTipologia
        public static DataSet SeachAllTipologia(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Input.GSO_CheckList.SeachAllTipologia(IdBaseDeDatos);
        }
        #endregion
        #region insertRowTipologia
        public static string insertRowTipologia(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.insertRowTipologia(parameterValues, pId);
        }
        #endregion
        #region UpdatedRowTipologia
        public static string UpdatedRowTipologia(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.UpdatedRowTipologia(parameterValues, pId);
        }
        #endregion
        #region DeletedRowTipologia
        public static string DeletedRowTipologia(string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.DeletedRowTipologia(pId);
        }
		#endregion

		#endregion


		#region Medida

		#region SeachAllMedida

		public static DataSet SeachAllMedida(string IdBaseDatos)
		{
			return Code.Data.Forms.Input.GSO_CheckList.SeachAllMedida(IdBaseDatos);
		}

		#endregion
		#endregion


		#region Partida
		#region SeachAllPartida
		public static DataSet SeachAllPartida(string IdBaseDatos)
		{
			return Code.Data.Forms.Input.GSO_CheckList.SeachAllPartida(IdBaseDatos);
		}

		#endregion

		#region		
		public static DataSet SeachAllPolinomica(string IdBaseDatos)
		{
			return Code.Data.Forms.Input.GSO_CheckList.SeachAllPolinomica(IdBaseDatos);
		}	
		#endregion


		#endregion


		#region CheckListxTipo
		#region SearchCheckListxTipo
		public static DataSet SearchCheckListxTipo(string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.SearchCheckListxTipo(pId);
        }
        #endregion
        #region insertRowCheckListxTipo
        public static string insertRowCheckListxTipo(string[] parameterValues)
        {
            return Code.Data.Forms.Input.GSO_CheckList.insertRowCheckListxTipo(parameterValues);
        }
        #endregion
        #region UpdatedRowCheckListxTipo
        public static string UpdatedRowCheckListxTipo(string[] parameterValues, string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.UpdatedRowCheckListxTipo(parameterValues, pId);
        }
        #endregion
        #region DeletedRowCheckListxTipo
        public static string DeletedRowCheckListxTipo(string pId)
        {
            return Code.Data.Forms.Input.GSO_CheckList.DeletedRowCheckListxTipo(pId);
        }
        #endregion
        #region SearchDescripcion
        public static DataSet SearchDescripcion()
        {
            return Code.Data.Forms.Input.GSO_CheckList.SearchDescripcion();
        }
        #endregion

        #endregion


    }
}
