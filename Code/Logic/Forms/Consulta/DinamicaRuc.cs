#region Using Directives
using System;
using System.Data;
#endregion

namespace InfogesEmape.Code.Logic.Forms.Consulta
{
    public class DinamicaRuc
    {


        #region SearchAllRucDet
        public static DataSet SearchAllRucDet(string pSec_ejec, string pKey, string BaseDeDatos)
        {
            return Code.Data.Forms.Consulta.DinamicaRuc.SearchAllRucDet(pSec_ejec, pKey, BaseDeDatos);
        }
        #endregion

        #region SearchAllRucGrupo
        public static DataSet SearchAllRucGrupo(string psec_ejec, string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.DinamicaRuc.SearchAllRucGrupo(psec_ejec, BaseDeDatos);
        }
        #endregion

        #region SearchAllRucGrupoPrueba
        public static DataSet SearchAllRucGrupoPrueba()
        {

            return Code.Data.Forms.Consulta.DinamicaRuc.SearchAllRucGrupoPrueba();
        }
        #endregion

    }
}
