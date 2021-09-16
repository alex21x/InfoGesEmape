using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace InfogesEmape.Code.Logic.Forms.Seguimiento
{
    public class GsoProyecto
    {

        #region SearchAll
        public static DataSet SearchAll(string pIdCoordinador)
        {
            return Code.Data.Forms.Seguimiento.GsoProyecto.SearchAll(pIdCoordinador);
        }
        #endregion
        #region SearchAllCoordinador
        public static DataSet SearchAllCoordinador(string pIdCoordinador)
        {
            return Code.Data.Forms.Seguimiento.GsoProyecto.SearchAllCoordinador(pIdCoordinador);
        }
        #endregion
        #region SearchAllProyectoGG
        public static DataSet SearchAllProyectoGG(string pIdDisitrito, string pIdActividad, string pIdTipoProyecto)
        {
            return Code.Data.Forms.Seguimiento.GsoProyecto.SearchAllProyectoGG(pIdDisitrito, pIdActividad, pIdTipoProyecto);
        }
        #endregion
    }
}