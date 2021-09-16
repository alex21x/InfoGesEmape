#region Using Directives
using System;
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

namespace InfogesEmape.Code.Data.Forms.Consulta
{
    public class GSO_Obras
    {
        #region GSOEstadoSituacionalProyecto
        public static DataSet GSOEstadoSituacionalProyecto(string IdBaseDeDatos)
        {
            DataSet ds1 = new DataSet();
            //string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            //StringSql += " STR_TO_DATE(A.Fecha_entrega_terreno, '%m/%d/%Y') AS FECHA_ENTREGA_TERRENO,STR_TO_DATE(A.Fecha_inicio_obra, '%m/%d/%Y') AS FECHA_INICIO_OBRA ,A.ESTADO_OBRA,";
            //StringSql += " A.PLAZO_EJECUCION,STR_TO_DATE(A.fecha_culminacion, '%m/%d/%Y') AS FECHA_CULMINACION,";
            //StringSql += " B.IDTIPOAVANCE,CONCAT(B.SEMANA,' ',B.RANGO) AS SEMANA, B.AVANCE";
            //StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ,";
            //StringSql += " " + IdBaseDeDatos + ".gso_estado_situacional_det B";
            //StringSql += " WHERE A.IDGSOSITUACION=B.IDGSOSITUACION";
            //StringSql += " ORDER BY A.IDGSOSITUACION,B.SEMANA,B.IDTIPOAVANCE ";



            //string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            //StringSql += " A.ESTADO_OBRA,";
            //StringSql += " A.PLAZO_EJECUCION,";
            //StringSql += " DATE_FORMAT(A.FECHA_INICIO_OBRA, '%d/%m/%Y') as FECHA_INICIO_OBRA, ";
            //StringSql += " DATE_FORMAT(A.FECHA_ENTREGA_TERRENO, '%d/%m/%Y') as FECHA_ENTREGA_TERRENO, ";
            //StringSql += " DATE_FORMAT(A.FECHA_CULMINACION, '%d/%m/%Y') as FECHA_CULMINACION, ";
            //StringSql += " A.TIPO_AVANCE,A.SEMANA, A.AVANCE";
            //StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ";
            //StringSql += " WHERE A.IDGSOSITUACION";
            //StringSql += " ORDER BY A.IDGSOSITUACION,A.SEMANA ";


            string StringSql = "SELECT * FROM OBRASEMP.VIEW_PROYECTO ";
            return Mysqlquery(StringSql);
        }
        #endregion

        #region GSOEstadoSituacionalObraSeguimiento
        public static DataSet GSOEstadoSituacionalObraSeguimiento(string IdBaseDeDatos)
        {
            DataSet ds1 = new DataSet();
            //string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            //StringSql += " STR_TO_DATE(A.Fecha_entrega_terreno, '%m/%d/%Y') AS FECHA_ENTREGA_TERRENO,STR_TO_DATE(A.Fecha_inicio_obra, '%m/%d/%Y') AS FECHA_INICIO_OBRA ,A.ESTADO_OBRA,";
            //StringSql += " A.PLAZO_EJECUCION,STR_TO_DATE(A.fecha_culminacion, '%m/%d/%Y') AS FECHA_CULMINACION,";
            //StringSql += " B.IDTIPOAVANCE,CONCAT(B.SEMANA,' ',B.RANGO) AS SEMANA, B.AVANCE";
            //StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ,";
            //StringSql += " " + IdBaseDeDatos + ".gso_estado_situacional_det B";
            //StringSql += " WHERE A.IDGSOSITUACION=B.IDGSOSITUACION";
            //StringSql += " ORDER BY A.IDGSOSITUACION,B.SEMANA,B.IDTIPOAVANCE ";



            //string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            //StringSql += " A.ESTADO_OBRA,";
            //StringSql += " A.PLAZO_EJECUCION,";
            //StringSql += " DATE_FORMAT(A.FECHA_INICIO_OBRA, '%d/%m/%Y') as FECHA_INICIO_OBRA, ";
            //StringSql += " DATE_FORMAT(A.FECHA_ENTREGA_TERRENO, '%d/%m/%Y') as FECHA_ENTREGA_TERRENO, ";
            //StringSql += " DATE_FORMAT(A.FECHA_CULMINACION, '%d/%m/%Y') as FECHA_CULMINACION, ";
            //StringSql += " A.TIPO_AVANCE,A.SEMANA, A.AVANCE";
            //StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ";
            //StringSql += " WHERE A.IDGSOSITUACION";
            //StringSql += " ORDER BY A.IDGSOSITUACION,A.SEMANA ";


            string StringSql = "SELECT contrato_seguimiento.solucion, ";
            StringSql += " contrato_seguimiento.avance, ";
            StringSql += " contrato_seguimiento.semana, ";
            StringSql += " contrato_seguimiento.importe, ";
            StringSql += " contrato_seguimiento.observacion, ";
            StringSql += " contrato_seguimiento.FECHA_INFORME, ";
            StringSql += " contrato.empresa, contrato.ruc, ";
            StringSql += " maestro_detalle.descripcion, ";
            StringSql += " contrato.idProyectoEtapa ";
            StringSql += " FROM ((OBRASEMP.contrato contrato  ";
            StringSql += " INNER JOIN OBRASEMP.contrato_seguimiento  ";
            StringSql += " contrato_seguimiento ";
            StringSql += " ON (contrato_seguimiento.idcontrato = contrato.idcontrato)) ";
            StringSql += " INNER JOIN OBRASEMP.maestro_detalle maestro_detalle  ";
            StringSql += " ON (maestro_detalle.idMaestro_Detalle = contrato.idcomponente)) ";
            return Mysqlquery(StringSql);
        }
        #endregion






        #region GSOEstadoSituacional
        public static DataSet GSOEstadoSituacional(string IdBaseDeDatos)
        {
            DataSet ds1 = new DataSet();
            //string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            //StringSql += " STR_TO_DATE(A.Fecha_entrega_terreno, '%m/%d/%Y') AS FECHA_ENTREGA_TERRENO,STR_TO_DATE(A.Fecha_inicio_obra, '%m/%d/%Y') AS FECHA_INICIO_OBRA ,A.ESTADO_OBRA,";
            //StringSql += " A.PLAZO_EJECUCION,STR_TO_DATE(A.fecha_culminacion, '%m/%d/%Y') AS FECHA_CULMINACION,";
            //StringSql += " B.IDTIPOAVANCE,CONCAT(B.SEMANA,' ',B.RANGO) AS SEMANA, B.AVANCE";
            //StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ,";
            //StringSql += " " + IdBaseDeDatos + ".gso_estado_situacional_det B";
            //StringSql += " WHERE A.IDGSOSITUACION=B.IDGSOSITUACION";
            //StringSql += " ORDER BY A.IDGSOSITUACION,B.SEMANA,B.IDTIPOAVANCE ";



            //string StringSql = " SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD, ";
            //StringSql += " A.ESTADO_OBRA,";
            //StringSql += " A.PLAZO_EJECUCION,";
            //StringSql += " DATE_FORMAT(A.FECHA_INICIO_OBRA, '%d/%m/%Y') as FECHA_INICIO_OBRA, ";
            //StringSql += " DATE_FORMAT(A.FECHA_ENTREGA_TERRENO, '%d/%m/%Y') as FECHA_ENTREGA_TERRENO, ";
            //StringSql += " DATE_FORMAT(A.FECHA_CULMINACION, '%d/%m/%Y') as FECHA_CULMINACION, ";
            //StringSql += " A.TIPO_AVANCE,A.SEMANA, A.AVANCE";
            //StringSql += " FROM " + IdBaseDeDatos + ".gso_estado_situacional A ";
            //StringSql += " WHERE A.IDGSOSITUACION";
            //StringSql += " ORDER BY A.IDGSOSITUACION,A.SEMANA ";


            string StringSql = "SELECT A.IDGSOSITUACION,A.PAQUETE,A.ABREVIATURA,A.ACT_PROY,A.DISTRITO,A.ACTIVIDAD,  ";
            StringSql += "A.ESTADO_OBRA, ";
            StringSql += "A.PLAZO_EJECUCION, ";
            StringSql += "DATE_FORMAT(A.FECHA_INICIO_OBRA, '%d/%m/%Y') AS FECHA_INICIO_OBRA,  ";
            StringSql += "DATE_FORMAT(A.FECHA_ENTREGA_TERRENO, '%d/%m/%Y') AS FECHA_ENTREGA_TERRENO,  ";
            StringSql += "DATE_FORMAT(A.FECHA_CULMINACION, '%d/%m/%Y') AS FECHA_CULMINACION,  ";
            StringSql += "A.TIPO_AVANCE,CONCAT('SEMANA ',C.SEMANA,' . DEL ',DATE_SUB(CURDATE(), INTERVAL DAYOFWEEK(CURDATE())-1 DAY),' AL ',DATE_ADD(CURDATE(), INTERVAL 7-DAYOFWEEK(CURDATE()) DAY)) SEMANA, B.IDCOMPONENTEOBRA,B.PORCENTAJE, ";
            StringSql += "D.DESCRIPCION AS COMPONENTE ";
            StringSql += "FROM OBRASEMP.gso_estado_situacional A , ";
            StringSql += "OBRASEMP.gso_Avance_obra B, OBRASEMP.SEMANA C, OBRASEMP.MAESTRO_DETALLE D ";
            StringSql += "WHERE A.IDGSOSITUACION=B.IDGSOSITUACION AND ";
            StringSql += "D.IDMAESTRO_DETALLE=B.IDCOMPONENTEOBRA AND ";
            StringSql += "B.IDSEMANA=C.IdSemana AND C.SEMANA= WEEK(CURDATE()) AND C.periodo=YEAR(CURDATE()) ";
            StringSql += "ORDER BY A.IDGSOSITUACION,C.SEMANA,B.IDCOMPONENTEOBRA ";
            return Mysqlquery(StringSql);
        }
        #endregion
        public static DataSet Mysqlquery(string Cadena)
        {
            //DataSet ds1 = new DataSet();
            //MySqlConnection Conexion = new MySqlConnection();
            //MySqlCommand Query = new MySqlCommand();
            //MySqlDataAdapter MySqlDa;
            //Conexion.ConnectionString = Code.ConeccionString2.mysql();
            //Conexion.Open();
            //Query.CommandText = Cadena;
            //Query.Connection = Conexion;
            //Query.CommandTimeout = 600;
            //MySqlDa = new MySqlDataAdapter(Query);
            //MySqlDa.Fill(ds1);
            //Conexion.Close();
            //return ds1;
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
