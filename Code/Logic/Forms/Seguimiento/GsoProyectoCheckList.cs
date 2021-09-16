using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace InfogesEmape.Code.Logic.Forms.Seguimiento
{
    public class GsoProyectoCheckList
    {

        #region SearchAll
        public static DataSet SearchAll(string pIdCoordinador)
        {
            return Code.Data.Forms.Seguimiento.GsoProyectoCheckList.SearchAll(pIdCoordinador);
        }
        #endregion

        #region SearchAllContratoCheckList
        public static DataSet SearchAllContratoCheckList(string pIdContrato)
        {
            return Code.Data.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoCheckList(pIdContrato);
        }
        #endregion
        #region SearchAllContratoTipologia
        public static DataSet SearchAllContratoTipologia(string pIdContrato)
        {
            return Code.Data.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoTipologia(pIdContrato);
        }
        #endregion

        #region SearchAllContratoCheckListDet
        public static DataSet SearchAllContratoCheckListDet(string pIdCheckList)
        {
            return Code.Data.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoCheckListDet(pIdCheckList);
        }
        #endregion
    }
}