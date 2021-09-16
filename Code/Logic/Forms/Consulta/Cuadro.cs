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
    public class Cuadro
    {

        public static DataSet SearchAllGenerica(string ano_eje, string sec_ejec,string BaseDeDatos, Boolean lcDetalle)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllGenerica(ano_eje, sec_ejec, BaseDeDatos, lcDetalle);
        }

        public static DataSet SearchAllFteFto(string ano_eje, string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllFteFto(ano_eje, sec_ejec,BaseDeDatos);
        }

        public static DataSet SearchAllProgramaPpto(string ano_eje, string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllProgramaPpto(ano_eje, sec_ejec,BaseDeDatos);
        }
        public static DataSet SearchGastoAcumulado(string ano_eje, string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchGastoAcumulado(ano_eje, sec_ejec, BaseDeDatos);
        }

        public static DataSet SearchFuncionAcumulado(string ano_eje, string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchFuncionAcumulado(ano_eje, sec_ejec, BaseDeDatos);
        }
        public static DataSet SearchAllUbigeo(string ano_eje, string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllUbigeo(ano_eje, sec_ejec, BaseDeDatos);
        }
        public static DataSet SearchAllContrato(string ano_eje, string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllContrato(ano_eje, sec_ejec, BaseDeDatos);
        }

        public static DataSet SearchAllContrato1( string sec_ejec,string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllContrato1( sec_ejec, BaseDeDatos);
        }
        public static DataSet SearchAllFinalidad(string ano_eje, string sec_ejec, string BaseDeDatos)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllFinalidad(ano_eje, sec_ejec, BaseDeDatos);
        }
        public static DataSet SearchAllPeriodo(string Sec_Ejec)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllPeriodo(Sec_Ejec);
        }
        public static DataSet SearchAllEjecutora(string IdSecEjec)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchAllEjecutora(IdSecEjec);
        }

        public static DataSet SearchByPresupuesto(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchByPresupuesto(IdSecEjec, BaseDeDatos, IdCadena);
        }

        public static DataSet SearchByEjecucion(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchByEjecucion(IdSecEjec, BaseDeDatos, IdCadena);
        }


        public static DataSet SearchByGrupoGenerico(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchByGrupoGenerico(IdSecEjec, BaseDeDatos, IdCadena);
        }

        public static DataSet SearchByFuncion(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchByFuncion(IdSecEjec, BaseDeDatos, IdCadena);
        }


        public static DataSet SearchByFuenteFinanc(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchByFuenteFinanc(IdSecEjec, BaseDeDatos, IdCadena);
        }

        public static DataSet SearchByEspecificaGasto(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            return Code.Data.Forms.Consulta.Cuadro.SearchByEspecificaGasto(IdSecEjec, BaseDeDatos, IdCadena);
        }
    }
}
