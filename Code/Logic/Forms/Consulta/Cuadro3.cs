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
    public class Cuadro3
    {
        //920852043
        //https://www.photokinesiologas.com/kinesiologas/lima-metropolitana/santa-anita/sensacional-y-joven-de-hermosa-carita-y-tetas-deliciosas-amable-y-apasionada-id-rvvu5

        public static DataSet SearchByPresupuesto(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {

            return Code.Data.Forms.Consulta.Cuadro3.SearchByPresupuesto(pSecEjec, BaseDeDatos, pAnoEje);
        }

        public static DataSet SearchByPresupuestoEte(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByPresupuestoEte(pSecEjec, BaseDeDatos, pAnoEje);
        }

        public static DataSet SearchByEncargoEte(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByEncargoEte(pSecEjec, BaseDeDatos, pAnoEje);
        }

        public static string SearchByPresupuestoGraf(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {

            return Code.Data.Forms.Consulta.Cuadro3.SearchByPresupuestoGraf(pSecEjec, BaseDeDatos, pAnoEje);
        }
        public static DataSet SearchByGrupoGenerico(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByGrupoGenerico(pSecEjec, BaseDeDatos, pAnoEje);
        }
        public static DataSet SearchByGrupoGenericoEte(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByGrupoGenericoEte(pSecEjec, BaseDeDatos, pAnoEje);
        }
        public static DataSet SearchByFuenteFinanc(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByFuenteFinanc(pSecEjec, BaseDeDatos, pAnoEje);
        }

        public static DataSet SearchByFuenteFinancEte(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByFuenteFinancEte(pSecEjec, BaseDeDatos, pAnoEje);
        }

        public static DataSet SearchByFuncion(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByFuncion(IdSecEjec, BaseDeDatos, IdCadena);
        }
        public static DataSet SearchByFuncionEte(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchByFuncionEte(IdSecEjec, BaseDeDatos, IdCadena);
        }
        public static DataSet SearchAllGenericaComparativo(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchAllGenericaComparativo(IdSecEjec, BaseDeDatos, IdCadena);
        }

        public static DataSet SearchAllExpedienteFechas(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {
            return Code.Data.Forms.Consulta.Cuadro3.SearchAllExpedienteFechas(IdSecEjec, BaseDeDatos, IdCadena);
        }
    }
}
