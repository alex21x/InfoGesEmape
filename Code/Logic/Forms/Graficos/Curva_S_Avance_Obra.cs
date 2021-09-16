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

namespace InfogesEmape.Code.Logic.Forms.Graficos
{
    public class Curva_S_Avance_Obra
    {



        #region SearchByCostoObraNew
        public static DataSet SearchByCostoObraNew(string IdPeriodo, string IdProyecto, string IdCategoriaPrograma, string IdComponenteObra, string IdProvincia, string IdDistrito, string IdBaseDeDatos)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchByCostoObraNew(IdPeriodo, IdProyecto, IdCategoriaPrograma, IdComponenteObra, IdProvincia, IdDistrito, IdBaseDeDatos);
        }
        #endregion


        #region SearchAllPeriodoDistinct
        public static DataSet SearchAllPeriodoDistinct(string IdOperador)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllPeriodoDistinct(IdOperador);
        }
        #endregion

        
        #region SearchAllEstadoRegistro
        public static DataSet SearchAllEstadoRegistro()
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllEstadoRegistro();
        }
        #endregion

        #region SearchAllProyectoDistinct
        public static DataSet SearchAllProyectoDistinct(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllProyectoDistinct(IdBaseDeDatos);
        }
        #endregion        
        
        #region SearchAllGrupoObraDistinct
        public static DataSet SearchAllGrupoObraDistinct(string IdProyecto, string IdBaseDeDatos)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllGrupoObraDistinct(IdProyecto, IdBaseDeDatos);
        }
        #endregion

        #region SearchAllComponenteObraDistinct
        public static DataSet SearchAllComponenteObraDistinct(string IdProyecto, string IdCategoriaPrograma, string IdBaseDeDatos)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllComponenteObraDistinct(IdProyecto, IdCategoriaPrograma, IdBaseDeDatos);
        }
        #endregion

        #region SearchAllProvinciaDistinct
        public static DataSet SearchAllProvinciaDistinct(string IdProyecto, string IdCategoriaPrograma, string IdComponenteObra, string IdBaseDeDatos)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllProvinciaDistinct(IdProyecto, IdCategoriaPrograma, IdComponenteObra, IdBaseDeDatos);
        }
        #endregion

        #region SearchAllDistritoDistinct
        public static DataSet SearchAllDistritoDistinct(string IdProyecto, string IdCategoriaPrograma, string IdComponenteObra, string IdProvincia, string IdBaseDeDatos)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllDistritoDistinct(IdProyecto, IdCategoriaPrograma, IdComponenteObra, IdProvincia, IdBaseDeDatos);
        }
        #endregion



        /*******************************************************/
        /***********************Google Maps*********************/
        /*******************************************************/


        #region SearchAllGmapUbigeo
        public static DataSet SearchAllGmapUbigeo(string IdProyecto)
        {
            return Code.Data.Forms.Graficos.Curva_S_Avance_Obra.SearchAllGmapUbigeo(IdProyecto);
        }
        #endregion 

        /*******************************************************/
        /***********************Google Maps*********************/
        /*******************************************************/
    }
}
