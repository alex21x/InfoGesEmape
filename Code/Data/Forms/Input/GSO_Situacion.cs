#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntLibContrib.Data.MySql;
#endregion

namespace InfogesEmape.Code.Data.Forms.Input
{
    public class GSO_Situacion
    {
        #region GSOEstadoSituacional
        public static DataSet GSOEstadoSituacional(string IdBaseDeDatos)
        {
            DataSet ds1 = new DataSet();


            string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            StringSql += " A.ESTADO_OBRA,";
            StringSql += " A.PLAZO_EJECUCION,";
            StringSql += " DATE_FORMAT(A.FECHA_INICIO_OBRA, '%d/%m/%Y') as FECHA_INICIO_OBRA, ";
            StringSql += " DATE_FORMAT(A.FECHA_ENTREGA_TERRENO, '%d/%m/%Y') as FECHA_ENTREGA_TERRENO, ";
            StringSql += " DATE_FORMAT(A.FECHA_CULMINACION, '%d/%m/%Y') as FECHA_CULMINACION, ";
            StringSql += " A.TIPO_AVANCE,A.SEMANA, A.AVANCE";
            StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ";
            StringSql += " WHERE A.IDGSOSITUACION";
            StringSql += " ORDER BY A.IDGSOSITUACION,A.SEMANA "; 
            return Mysqlquery(StringSql);
        }
        #endregion

        #region GsoSearchAllAvance
        public static DataSet GsoSearchAllAvance(string IdSemana,string IdUsuario, string IdPassword)
        {
            string sqlCommand = " Call OBRASEMP.SearchSemana("+IdSemana+",'"+IdUsuario+"','"+IdPassword+"');";
            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SeachAllSemana
        public static DataSet SeachAllSemana(string lcCadena)
        {

            string sqlCommand = " SELECT A.IDSEMANA,A.SEMANA ";
            sqlCommand += "FROM OBRASEMP.SEMANA A ";
            sqlCommand += "WHERE  A.PERIODO='2020' ";
            sqlCommand += "AND A.SEMANA<='52' ";
            sqlCommand += "ORDER BY A.SEMANA DESC"; 

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SeachAllCoordinador
        public static DataSet SeachAllCoordinador(string lcCadena)
        {
            string sqlCommand = " SELECT A.IDPERSONA,A.NOMBRE ";
            sqlCommand += "FROM OBRASEMP.PERSONA A ";
            sqlCommand += "WHERE  A.ESTADO='A' ";
            sqlCommand += "ORDER BY A.NOMBRE ";

            return Mysqlquery(sqlCommand);
        }
        #endregion


        #region UpdatedGsoAvanceRow
        public static string UpdatedGsoAvanceRow(string[] parameterValues, string pId)
        {

            string IdAvance = pId.Substring(0, 10);
            string IdSemana = pId.Substring(10, 2);
            string IdGsoSituacion = pId.Substring(12);
            string IdObra               = parameterValues[0].ToString() ;
            string Idsupervision        = parameterValues[1].ToString() ;        
            string IdGestionProyecto    = parameterValues[2].ToString() ;
            string IdInterferencia      = parameterValues[3].ToString() ;
            string r = "";
            string lxCadena = "Delete A.* from OBRASEMP.gso_avance_obra A ";
            lxCadena += "  WHERE  A.IDAVANCE=" + IdAvance + " AND A.IDSEMANA=" + IdSemana + " AND A.IdGsoSituacion= " + IdGsoSituacion + " ; ";

            lxCadena += " INSERT INTO OBRASEMP.gso_avance_obra (IDAVANCE,IDGSOSITUACION,IDSEMANA,IDCOMPONENTEOBRA,PORCENTAJE) VALUES (";
            lxCadena += " " + IdAvance + "," + IdGsoSituacion + "," + IdSemana + ",36,"+IdObra+");";
            lxCadena += " INSERT INTO OBRASEMP.gso_avance_obra (IDAVANCE,IDGSOSITUACION,IDSEMANA,IDCOMPONENTEOBRA,PORCENTAJE) VALUES (";
            lxCadena += " " + IdAvance + "," + IdGsoSituacion + "," + IdSemana + ",37," + Idsupervision + ");";
            lxCadena += " INSERT INTO OBRASEMP.gso_avance_obra (IDAVANCE,IDGSOSITUACION,IDSEMANA,IDCOMPONENTEOBRA,PORCENTAJE) VALUES (";
            lxCadena += " " + IdAvance + "," + IdGsoSituacion + "," + IdSemana + ",38," + IdGestionProyecto + ");";
            lxCadena += " INSERT INTO OBRASEMP.gso_avance_obra (IDAVANCE,IDGSOSITUACION,IDSEMANA,IDCOMPONENTEOBRA,PORCENTAJE) VALUES (";
            lxCadena += " " + IdAvance + "," + IdGsoSituacion + "," + IdSemana + ",39," + IdInterferencia + ");";
            lxCadena += " SELECT 1;";


            DataSet df = Mysqlquery(lxCadena);
            return "1";
        }
        #endregion

        #region UpdatedGsoAvance
        public static string UpdatedGsoAvance(DataTable parameterValues, string pIdPersona)
        {

            string r = "";
            string lxCadena = "Delete A.* from OBRASEMP.gso_avance_obra A,OBRASEMP.COORDINADOR_CONTRATO B";
            lxCadena += "  WHERE  A.ACT_PROY=B.CIU AND  B.IDPERSONA=" + pIdPersona + " AND A.IDSEMANA=" + parameterValues.Rows[0]["IDSEMANA"].ToString() + "; ";

            for (int i = 0; i < parameterValues.Rows.Count; i++)
            {
                lxCadena+= " INSERT INTO OBRASEMP.gso_avance_obra (IDAVANCE,IDGSOSITUACION,IDCOMPONENTEOBRA,IDSEMANA,PORCENTAJE) VALUES (";

                lxCadena+= " " + parameterValues.Rows[i]["IDAVANCE"].ToString()+",";
                lxCadena+= " " + parameterValues.Rows[i]["IDGSOSITUACION"].ToString()+",";
                lxCadena+= " " + parameterValues.Rows[i]["IDCOMPONENTEOBRA"].ToString()+",";
                lxCadena+= " " + parameterValues.Rows[i]["IDSEMANA"].ToString()+",";
                lxCadena += " " + parameterValues.Rows[i]["PORCENTAJE"].ToString() + "";
                lxCadena += ");";


            }

            lxCadena += " SELECT WEEK(CURDATE()); ";
            DataSet df = Mysqlquery(lxCadena);
            return "1";
        }
        #endregion

        #region Coordinador

        #region SeachAllCoordinadorRegistro
        public static DataSet SeachAllCoordinadorRegistro(string lcCadena)
        {
            string sqlCommand = " SELECT A.IDPERSONA,A.DOCUMENTO,A.NOMBRE,A.ESTADO,A.ROLE_ID AS ROLE ";
            sqlCommand += "FROM OBRASEMP.PERSONA A ";            
            sqlCommand += "ORDER BY A.NOMBRE ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region insertRowCoordinador
        public static string insertRowCoordinador(string[] parameterValues, string pId)
        {

            string idDocumento = parameterValues[1].ToString();
            string IdNombre = parameterValues[2].ToString();
			string IdRole   = parameterValues[3].ToString();

			string sqlCommand = "";
            sqlCommand += "insert into OBRASEMP.Persona(DOCUMENTO,NOMBRE,ROLE_ID) VALUES";
            sqlCommand += "('" + idDocumento + "','" + IdNombre + "','" + IdRole + "'); Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #region UpdatedRowCoordinador
        public static string UpdatedRowCoordinador(string[] parameterValues, string pId)
        {
            string idDocumento = parameterValues[1].ToString();
            string IdNombre = parameterValues[2].ToString();
			string IdRole = parameterValues[3].ToString();
			string sqlCommand = "";
            sqlCommand += "UPDATE OBRASEMP.Persona SET ";
            sqlCommand += " DOCUMENTO='"+ idDocumento +"',";
            sqlCommand += " NOMBRE  = '" + IdNombre + "',";
			sqlCommand += " ROLE_ID = '" + IdRole + "'";
			sqlCommand += "WHERE IDPERSONA=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";

        }
        #endregion        
        #region DeletedRowCoordinador
        public static string DeletedRowCoordinador(string[] parameterValues, string pId)
        {
            string sqlCommand = "";
            sqlCommand += "DELETE  fROM OBRASEMP.Persona  ";
            sqlCommand += "WHERE IDPERSONA=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #endregion

        #region CoordinadorContrato

        #region SearchCoordinadorContrato
        public static DataSet SearchCoordinadorContrato(string IdPersona)
        {

            string sqlCommand = " SELECT DISTINCT B.IDCOORDINADORCONTRATO,A.CUI AS ACT_PROY, CONCAT(A.CUI,' ',A.ABREVIATURA,'-',IF(ISNULL(D.CONTRATO_NUMERO),'SIN CONTRATO',D.CONTRATO_NUMERO)) AS ABREVIATURA ,A.DESCRIPCION, "; 
            sqlCommand += " B.INSERTAR,B.ACTUALIZAR,B.ELIMINAR,B.CONSULTA,B.CIERRE,B.SUPERVISION,B.ESRESPONSABLE,C.ROLE_ID ";
            sqlCommand += " FROM OBRASEMP.PROYECTO A ";
            sqlCommand += " JOIN OBRASEMP.Coordinador_contrato B ";
            sqlCommand += " ON A.CUI=B.CUI  ";
            sqlCommand += " JOIN OBRASEMP.persona C  ";
            sqlCommand += " ON B.IDPERSONA=C.IDPERSONA  ";
            sqlCommand += " JOIN OBRASEMP.CONTRATO D ";
            sqlCommand += " ON B.IDCONTRATO=D.IDCONTRATO ";
            sqlCommand += " WHERE  ";
            sqlCommand += " C.IdPersona=" + IdPersona + " ";
            sqlCommand += " ORDER BY A.CUI ";

            return Mysqlquery(sqlCommand);
        }
        #endregion
        #region SearchDescripcion
        public static DataSet SearchDescripcion(string IdPersona)
        {
           
            string sqlCommand = " SELECT DISTINCT CONCAT(A.CUI,C.IDCONTRATO) AS ACT_PROY, CONCAT(A.CUI,' ',B.ABREVIATURA,'-',IF(ISNULL(C.CONTRATO_NUMERO),'SIN CONTRATO',C.CONTRATO_NUMERO)) AS ABREVIATURA ";
            sqlCommand += " FROM OBRASEMP.PROYECTO A   JOIN OBRASEMP.PROYECTO_COMPONENTE B  ON A.IDPROYECTO=B.IDPROYECTO ";
            sqlCommand += " JOIN OBRASEMP.CONTRATO C  ON B.IDPROYECTOCOMPONENTE=C.IDPROYECTOCOMPONENTE  ";
            sqlCommand += " ORDER BY A.CUI  ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SearchCoordinadorContrato
        public static DataSet SearchCoordinadorContrato(string pIdPersona, string pIdActProy)
        {
            string sqlCommand = "  ";
            sqlCommand += " SELECT A.CUI,B.INSERTAR,B.ACTUALIZAR,B.ELIMINAR,B.CONSULTA,B.CIERRE,B.SUPERVISION,B.ESRESPONSABLE,C.ROLE_ID  ";
            sqlCommand += " FROM OBRASEMP.PROYECTO A  ";
            sqlCommand += " JOIN OBRASEMP.Coordinador_contrato B ";
            sqlCommand += " ON A.CUI=B.CUI  ";
            sqlCommand += " JOIN OBRASEMP.persona C  ";
            sqlCommand += " ON B.IDPERSONA=C.IDPERSONA  ";
            sqlCommand += " JOIN OBRASEMP.CONTRATO D ";
            sqlCommand += " ON B.IDCONTRATO=D.IDCONTRATO ";
            sqlCommand += " WHERE  ";
            sqlCommand += " C.DOCUMENTO='" + pIdPersona + "' and ";
            sqlCommand += " A.CUI='" + pIdActProy + "' ";
            sqlCommand += " ORDER BY A.CUI ";

            return Mysqlquery(sqlCommand);
        }
        #endregion
        #region insertRowCoordinadorContrato
        public static string insertRowCoordinadorContrato(string[] parameterValues, string pId)
        {

            string IdCui = parameterValues[0].ToString();
            string sqlCommand = "";
            sqlCommand += "insert into OBRASEMP.Coordinador_contrato(CUI,IDPERSONA,IDCONTRATO,INSERTAR, ACTUALIZAR,ELIMINAR,CONSULTA,CIERRE,SUPERVISION,ESRESPONSABLE) VALUES";
            sqlCommand += "(" + IdCui.ToString().Substring(0,7) + "," + pId+ ","+IdCui.ToString().Substring(7)+", ";
            sqlCommand += parameterValues[1].ToString() + ", " + parameterValues[2].ToString() + "," + parameterValues[3].ToString() +",";
            sqlCommand += parameterValues[4].ToString() + ", " + parameterValues[5].ToString() + "," + parameterValues[6].ToString() + "," + parameterValues[7].ToString()+" ";
            sqlCommand += "); Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #region UpdatedRowCoordinadorContrato
        public static string UpdatedRowCoordinadorContrato(string[] parameterValues, string pIdPersona, string pId)
        {
            string IdCui = parameterValues[0].ToString();
            string sqlCommand = "";
            sqlCommand += "UPDATE OBRASEMP.Coordinador_contrato SET ";
            if (IdCui != "NCN")
            {
                sqlCommand += " CUI='" + IdCui.ToString().Substring(0, 7) + "',";
                sqlCommand += " IDCONTRATO = '" + IdCui.ToString().Substring(7) + "',";
            }
            sqlCommand += " INSERTAR = '" + parameterValues[1].ToString() + "',";
            sqlCommand += " ACTUALIZAR = '" + parameterValues[2].ToString() + "',";
            sqlCommand += " ELIMINAR = '" + parameterValues[3].ToString() + "',";
            sqlCommand += " CONSULTA = '" + parameterValues[4].ToString() + "',";
            sqlCommand += " CIERRE = '" + parameterValues[5].ToString() + "',";
            sqlCommand += " SUPERVISION = '" + parameterValues[6].ToString() + "',";
            sqlCommand += " ESRESPONSABLE = '" + parameterValues[7].ToString() + "' ";
            sqlCommand += "WHERE IDCOORDINADORCONTRATO=" + pId + " ; Select 1 ;";
  
            DataSet df = Mysqlquery(sqlCommand);
            return "1";

        }
        #endregion
        #region DeletedRowCoordinadorContrato
        public static string DeletedRowCoordinadorContrato( string pId)
        {


            string sqlCommand = "";
            sqlCommand += "DELETE  fROM OBRASEMP.Coordinador_contrato  ";
            sqlCommand += "WHERE IDCOORDINADORCONTRATO=" + pId+" ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion


        public static DataSet Mysqlquery(string Cadena)
        {
            DataSet ds1 = new DataSet();
            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand Query = new MySqlCommand();
            MySqlDataAdapter MySqlDa;
            Conexion.ConnectionString = Code.ConeccionString2.mysql();
            Conexion.Open();
            Query.CommandText = Cadena;
            Query.Connection = Conexion;
            Query.CommandTimeout = 1200;
            MySqlDa = new MySqlDataAdapter(Query);
			MySqlDa.Fill(ds1);
            Conexion.Close();
            return ds1;
        }
    }
}
