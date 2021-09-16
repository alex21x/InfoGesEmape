using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InfogesEmape.Code.Data.Forms.Seguimiento
{
    public class GsoProyecto
    {

        #region SearchAll
        public static DataSet SearchAll(string pSecEjec)
        {
            DataSet ds1 = new DataSet();
            string  StringSql = " SELECT ";
            StringSql += " A.ACT_PROY, ";
            StringSql += " A.NOMBRE_BANCO_PROYECTO, ";
            StringSql += " B.ABREVIATURA, ";
            StringSql += " A.FECHA_PREINVERSION, ";
            StringSql += " A.MONTO_PREINVERSION, ";
            StringSql += " A.FECHA_INVERSION, ";
            StringSql += " A.MONTO_INVERSION, ";
            StringSql += " B.CUI, ";
            StringSql += " B.FECHA_INICIO, ";
            StringSql += " B.FECHA_FIN ";
            StringSql += " FROM ";
            StringSql += " SIAF_500196.INFOREG_BANCO_PROYECTO A ";
            StringSql += " LEFT JOIN OBRASEMP.proyecto B ";
            StringSql += " ON A.ACT_PROY=B.CUI ";
            StringSql += " order by ACT_PROY ";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllCoordinador
        public static DataSet SearchAllCoordinador(string pSecEjec)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += " A.ACT_PROY, ";
            StringSql += " A.NOMBRE_BANCO_PROYECTO, ";
            StringSql += " B.ABREVIATURA, ";
            StringSql += " A.FECHA_PREINVERSION, ";
            StringSql += " A.MONTO_PREINVERSION, ";
            StringSql += " A.FECHA_INVERSION, ";
            StringSql += " A.MONTO_INVERSION, ";
            StringSql += " B.CUI, ";
            StringSql += " B.FECHA_INICIO, ";
            StringSql += " B.FECHA_FIN ";
            StringSql += " FROM ";
            StringSql += " SIAF_500196.INFOREG_BANCO_PROYECTO A ";
            StringSql += " LEFT JOIN OBRASEMP.proyecto B ";
            StringSql += " ON A.ACT_PROY=B.CUI ";
            StringSql += " JOIN OBRASEMP.COORDINADOR_CONTRATO C ";
            StringSql += " ON B.CUI=C.CUI ";
            StringSql += " JOIN OBRASEMP.PERSONA D ";
            StringSql += " ON C.IDPERSONA=D.IDPERSONA AND DOCUMENTO='" + pSecEjec + "'";
            StringSql += " WHERE LENGTH(A.NOMBRE_BANCO_PROYECTO)>0 ";
            StringSql += " GROUP BY A.ACT_PROY ";
            StringSql += " order by a.ACT_PROY ";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion


        #region SearchAllProyectoGG
        public static DataSet SearchAllProyectoGG(string pIdDisitrito, string pIdActividad, string pIdTipoProyecto)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT *, IF(RESTO<0,'-1000','1000')    AS SEMAFORO FROM OBRASEMP.EMAPE_OBRAS_EJECUCION ";
            StringSql += " WHERE 1=1 ";           
            if (pIdDisitrito.ToString()!="TODOS")
                StringSql += " AND DISTRITO='"+pIdDisitrito+"'";

            if (pIdActividad.ToString() != "TODOS")
                StringSql += " AND DESCRIPCION_ACTIVIDAD_PROYECTO='" + pIdActividad + "'";

            if (pIdTipoProyecto.ToString() != "TODOS")
                StringSql += " AND DESCRIPCION_TIPO_PROYECTO='" + pIdTipoProyecto + "'";           

            StringSql += " ORDER BY ACT_PROY";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion
    }
}