using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InfogesEmape.Code.Data.Forms.Seguimiento
{
    public class GsoProyectoCheckList
    {

        #region SearchAll
        public static DataSet SearchAll(string pSecEjec)
        {
            DataSet ds1 = new DataSet();
            string  StringSql = " SELECT ";
            StringSql += " DISTINCT  ";
            StringSql += " A.CUI, A.DESCRIPCION, A.ABREVIATURA, C.IDCONTRATO, C.CONTRATO_NUMERO, ";
            StringSql += " MAX(G.CHECKLIST_FECHA) AS ULTIMA_FECHA, ";
            StringSql += " RTRIM(F.ABREVIATURA) AS COMPONENTE_OBRA, ";
            StringSql += " RTRIM(E.ABREVIATURA) AS ESTADO_CONTRATO, ";
            StringSql += " COUNT(D.IDCONTRATOTIPOLOGIA) AS NCHECKLIST ";
            StringSql += " FROM OBRASEMP.PROYECTO A ";
            StringSql += " JOIN OBRASEMP.PROYECTO_COMPONENTE B ";
            StringSql += " ON A.IDPROYECTO=B.IDPROYECTO ";
            StringSql += " JOIN OBRASEMP.CONTRATO C ";
            StringSql += " ON C.IDPROYECTOCOMPONENTE=B.IDPROYECTOCOMPONENTE ";
            StringSql += " AND C.IDESTADO_CONTRATO<>49 ";
            StringSql += " LEFT JOIN OBRASEMP.CONTRATO_TIPOLOGIA D ";
            StringSql += " ON C.IDCONTRATO=D.IDCONTRATO ";
            StringSql += " JOIN OBRASEMP.MAESTRO_DETALLE E ";
            StringSql += " ON C.IDESTADO_CONTRATO=E.IDMAESTRO_DETALLE ";
            StringSql += " JOIN OBRASEMP.MAESTRO_DETALLE F ";
            StringSql += " ON B.IDCOMPONENTE=F.IDMAESTRO_DETALLE ";
            StringSql += " LEFT JOIN OBRASEMP.CONTRATO_CHECKLIST G ";
            StringSql += " ON C.IDCONTRATO=G.IDCONTRATO ";
            StringSql += " GROUP BY A.CUI ";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllContratoCheckList
        public static DataSet SearchAllContratoCheckList(string pIdContrato)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += " IDCONTRATOCHECKLIST,IDCONTRATO,CHECKLIST_FECHA,CHECKLIST_SEMANA,ANO_EJE ";
            StringSql += " FROM OBRASEMP.CONTRATO_CHECKLIST ";
            StringSql += " WHERE IDCONTRATO="+pIdContrato+" ";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion


        #region SearchAllContratoTipologia
        public static DataSet SearchAllContratoTipologia(string pIdContrato)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += "  D.IDCHECKLIST,D.CHECKLIST_DESCRIPCION ";
            StringSql += "  FROM OBRASEMP.CONTRATO_TIPOLOGIA A ";
            StringSql += "  JOIN OBRASEMP.OBRA_CHECKLIST_TIPOLOGIA B ";
            StringSql += "  ON A.IDTIPOLOGIA=B.IDTIPOLOGIA ";
            StringSql += "  JOIN OBRASEMP.OBRA_CHECKLIST_X_TIPO C ";
            StringSql += "  ON B.IDTIPOLOGIA=C.IDTIPOLOGIA ";
            StringSql += "  JOIN OBRASEMP.obra_checklist D ";
            StringSql += "  ON C.IDCHECKLIST=D.IDCHECKLIST ";
            StringSql += "  WHERE A.IDCONTRATO="+pIdContrato+" ";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllContratoCheckListDet
        public static DataSet SearchAllContratoCheckListDet(string pIdCheckList)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += "  C.CHECKLIST_DESCRIPCION,A.IDCONTRATOCHECKLISTDET,B.CHECKLIST_ACTIVIDAD_DESCRIPCION,A.LIKERT1,A.LIKERT2,A.LIKERT3,A.LIKERT4,A.LIKERT5 ";
            StringSql += "  FROM OBRASEMP.CONTRATO_CHECKLIST_DET A ";
            StringSql += "  JOIN OBRASEMP.OBRA_CHECKLIST_ACTIVIDAD B ";
            StringSql += "  ON A.IDCHECKLIST_ACTIVIDAD=B.IDCHECKLIST_ACTIVIDAD ";
            StringSql += "  JOIN OBRASEMP.OBRA_CHECKLIST C ";
            StringSql += "  ON B.IDCHECKLIST=C.IDCHECKLIST ";
            StringSql += "  WHERE A.IDCONTRATOCHECKLIST=" + pIdCheckList + " ";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

    }
}