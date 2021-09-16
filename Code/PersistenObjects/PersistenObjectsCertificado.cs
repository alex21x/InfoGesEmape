using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;

namespace PersistenObjectsCertificado 
{

        [NonPersistent]

        public class MyBaseObject : XPObject
        {
            public MyBaseObject(Session session) : base(session) { }
        }
    

        public class infoges_control_certificado : MyBaseObject
        {
            public infoges_control_certificado (Session session) : base(session) { }

            string _GLOSA;
            public string GLOSA
            {
                get { return _GLOSA; }
                set { SetPropertyValue("GLOSA", ref _GLOSA, value); }
            }

            string _KEY1;
            public string KEY1
            {
                get { return _KEY1; }
                set { SetPropertyValue("KEY1", ref _KEY1, value); }
            }

            string _ANO_EJE;
            public string ANO_EJE
            {
                get { return _ANO_EJE; }
                set { SetPropertyValue("ANO_EJE", ref _ANO_EJE, value); }
            }

            string _SEC_EJEC;
            public string SEC_EJEC
            {
                get { return _SEC_EJEC; }
                set { SetPropertyValue("SEC_EJEC", ref _SEC_EJEC, value); }
            }

            string _CERTIFICADO;
            public string CERTIFICADO
            {
                get { return _CERTIFICADO; }
                set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
            }

            string _SEC_FUNC;
            public string SEC_FUNC
            {
                get { return _SEC_FUNC; }
                set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
            }


            string _FUENTE_FINANC;
            public string FUENTE_FINANC
            {
                get { return _FUENTE_FINANC; }
                set { SetPropertyValue("FUENTE_FINANC", ref _FUENTE_FINANC, value); }
            }

            string _GENERICA_NOMBRE;
            public string GENERICA_NOMBRE
            {
                get { return _GENERICA_NOMBRE; }
                set { SetPropertyValue("GENERICA_NOMBRE", ref _GENERICA_NOMBRE, value); }
            }

            string _COD_DOC;
            public string COD_DOC
            {
                get { return _COD_DOC; }
                set { SetPropertyValue("COD_DOC", ref _COD_DOC, value); }
            }

            string _NUM_DOC;
            public string NUM_DOC
            {
                get { return _NUM_DOC; }
                set { SetPropertyValue("NUM_DOC", ref _NUM_DOC, value); }
            }

            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
            }

            string _NOTAS;
            public string NOTAS
            {
                get { return _NOTAS; }
                set { SetPropertyValue("NOTAS", ref _NOTAS, value); }
            }

            string _ID_CLASIFICADOR;
            public string ID_CLASIFICADOR
            {
                get { return _ID_CLASIFICADOR; }
                set { SetPropertyValue("ID_CLASIFICADOR", ref _ID_CLASIFICADOR, value); }
            }

            string _ESTADO_ENVIO;
            public string ESTADO_ENVIO
            {
                get { return _ESTADO_ENVIO; }
                set { SetPropertyValue("ESTADO_ENVIO", ref _ESTADO_ENVIO, value); }
            }

            string _ESTADO_REGISTRO;
            public string ESTADO_REGISTRO
            {
                get { return _ESTADO_REGISTRO; }
                set { SetPropertyValue("ESTADO_REGISTRO", ref _ESTADO_REGISTRO, value); }
            }

            string _FECHA_DOC;
            public string FECHA_DOC
            {
                get { return _FECHA_DOC; }
                set { SetPropertyValue("FECHA_DOC", ref _FECHA_DOC, value); }
            }

            string _SEC_FUNCD;
            public string SEC_FUNCD
            {
                get { return _SEC_FUNCD; }
                set { SetPropertyValue("SEC_FUNCD", ref _SEC_FUNCD, value); }
            }

            string _FUENTE_FINANC_NOMBRE;
            public string FUENTE_FINANC_NOMBRE
            {
                get { return _FUENTE_FINANC_NOMBRE; }
                set { SetPropertyValue("FUENTE_FINANC_NOMBRE", ref _FUENTE_FINANC_NOMBRE, value); }
            }

            string _ESPECIFICA_NOMBRE;
            public string ESPECIFICA_NOMBRE
            {
                get { return _ESPECIFICA_NOMBRE; }
                set { SetPropertyValue("ESPECIFICA_NOMBRE", ref _ESPECIFICA_NOMBRE, value); }
            }

            decimal _MONTO_CERTIFICADO;
            public decimal MONTO_CERTIFICADO
            {
                get { return _MONTO_CERTIFICADO; }
                set { SetPropertyValue("MONTO_CERTIFICADO", ref _MONTO_CERTIFICADO, value); }
            }

            decimal _MONTO_COMPROMISO_ANUAL;
            public decimal MONTO_COMPROMISO_ANUAL
            {
                get { return _MONTO_COMPROMISO_ANUAL; }
                set { SetPropertyValue("MONTO_COMPROMISO_ANUAL", ref _MONTO_COMPROMISO_ANUAL, value); }
            }

            decimal _COMPROMISO;
            public decimal COMPROMISO
            {
                get { return _COMPROMISO; }
                set { SetPropertyValue("COMPROMISO", ref _COMPROMISO, value); }
            }

            decimal _DEVENGADO;
            public decimal DEVENGADO
            {
                get { return _DEVENGADO; }
                set { SetPropertyValue("DEVENGADO", ref _DEVENGADO, value); }
            }

            decimal _GIRADO;
            public decimal GIRADO
            {
                get { return _GIRADO; }
                set { SetPropertyValue("GIRADO", ref _GIRADO, value); }
            }

            decimal _SALDO_COMPROMISO_ANUAL;
            public decimal SALDO_COMPROMISO_ANUAL
            {
                get { return _SALDO_COMPROMISO_ANUAL; }
                set { SetPropertyValue("SALDO_COMPROMISO_ANUAL", ref _SALDO_COMPROMISO_ANUAL, value); }
            }

            decimal _SALDO_CERTIFICADO;
            public decimal SALDO_CERTIFICADO
            {
                get { return _SALDO_CERTIFICADO; }
                set { SetPropertyValue("SALDO_CERTIFICADO", ref _SALDO_CERTIFICADO, value); }
            }

            string _EMAPE_COMPONENTE;
            public string EMAPE_COMPONENTE
            {
                get { return _EMAPE_COMPONENTE; }
                set { SetPropertyValue("EMAPE_COMPONENTE", ref _EMAPE_COMPONENTE, value); }
            }
            //[Association("Certificado-Expediente", typeof(infoges_exp)), Aggregated]
            //public XPCollection infoges_exp { get { return GetCollection("infoges_exp"); } }
        
        }


        public class infoges_control_certificado_meta: MyBaseObject
        {
            public infoges_control_certificado_meta(Session session) : base(session) { }
            string _ANO_EJE;
            public string ANO_EJE
            {
                get { return _ANO_EJE; }
                set { SetPropertyValue("ANO_EJE", ref _ANO_EJE, value); }
            }


            string _SEC_EJEC;
            public string SEC_EJEC
            {
                get { return _SEC_EJEC; }
                set { SetPropertyValue("SEC_EJEC", ref _SEC_EJEC, value); }
            }

            string _CADENAKEY;
            public string CADENAKEY
            {
                get { return _CADENAKEY; }
                set { SetPropertyValue("CADENAKEY", ref _CADENAKEY, value); }
            }

            string _SEC_FUNC;
            public string SEC_FUNC
            {
                get { return _SEC_FUNC; }
                set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
            }

            string _FUENTE_FINANC_NOMBRE;
            public string FUENTE_FINANC_NOMBRE
            {
                get { return _FUENTE_FINANC_NOMBRE; }
                set { SetPropertyValue("FUENTE_FINANC_NOMBRE", ref _FUENTE_FINANC_NOMBRE, value); }
            }

            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
            }


            string _GENERICA_NOMBRE;
            public string GENERICA_NOMBRE
            {
                get { return _GENERICA_NOMBRE; }
                set { SetPropertyValue("GENERICA_NOMBRE", ref _GENERICA_NOMBRE, value); }
            }

            string _PROGRAMA_NOMBRE;
            public string PROGRAMA_NOMBRE
            {
                get { return _PROGRAMA_NOMBRE; }
                set { SetPropertyValue("PROGRAMA_NOMBRE", ref _PROGRAMA_NOMBRE, value); }
            }


            string _ESPECIFICA_DET_NOMBRE;
            public string ESPECIFICA_DET_NOMBRE
            {
                get { return _ESPECIFICA_DET_NOMBRE; }
                set { SetPropertyValue("ESPECIFICA_DET_NOMBRE", ref _ESPECIFICA_DET_NOMBRE, value); }
            }


            string _PIA;
            public string PIA
            {
                get { return _PIA; }
                set { SetPropertyValue("PIA", ref _PIA, value); }
            }

            string _PIM;
            public string PIM
            {
                get { return _PIM; }
                set { SetPropertyValue("PIM", ref _PIM, value); }
            }

            string _CERTIFICADO;
            public string CERTIFICADO
            {
                get { return _CERTIFICADO; }
                set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
            }

            string _COMPROMISO_ANUAL;
            public string COMPROMISO_ANUAL
            {
                get { return _COMPROMISO_ANUAL; }
                set { SetPropertyValue("COMPROMISO_ANUAL", ref _COMPROMISO_ANUAL, value); }
            }

            string _COMPROMISO;
            public string COMPROMISO
            {
                get { return _COMPROMISO; }
                set { SetPropertyValue("COMPROMISO", ref _COMPROMISO, value); }
            }

            string _DEVENGADO;
            public string DEVENGADO
            {
                get { return _DEVENGADO; }
                set { SetPropertyValue("DEVENGADO", ref _DEVENGADO, value); }
            }

            string _GIRADO;
            public string GIRADO
            {
                get { return _GIRADO; }
                set { SetPropertyValue("GIRADO", ref _GIRADO, value); }
            }


            string _SALDO_CERTIFICADO;
            public string SALDO_CERTIFICADO
            {
                get { return _SALDO_CERTIFICADO; }
                set { SetPropertyValue("SALDO_CERTIFICADO", ref _SALDO_CERTIFICADO, value); }
            }

            string _SALDO_MARCO;
            public string SALDO_MARCO
            {
                get { return _SALDO_MARCO; }
                set { SetPropertyValue("SALDO_MARCO", ref _SALDO_MARCO, value); }
            }

            string _SALDO_COMPROMISO_ANUAL;
            public string SALDO_COMPROMISO_ANUAL
            {
                get { return _SALDO_COMPROMISO_ANUAL; }
                set { SetPropertyValue("SALDO_COMPROMISO_ANUAL", ref _SALDO_COMPROMISO_ANUAL, value); }
            }

            string _SALDO_COMPROMISO;
            public string SALDO_COMPROMISO
            {
                get { return _SALDO_COMPROMISO; }
                set { SetPropertyValue("SALDO_COMPROMISO", ref _SALDO_COMPROMISO, value); }
            }

            string _SALDO_DEVENGADO;
            public string SALDO_DEVENGADO
            {
                get { return _SALDO_DEVENGADO; }
                set { SetPropertyValue("SALDO_DEVENGADO", ref _SALDO_DEVENGADO, value); }
            }

            string _GLOSA;
            public string GLOSA
            {
                get { return _GLOSA; }
                set { SetPropertyValue("GLOSA", ref _GLOSA, value); }
            }






        }

        //public class infoges_exp : MyBaseObject
        //{
        //    public infoges_exp(Session session) : base(session) { }

        //    string _ACT_PROY;
        //    public string ACT_PROY
        //    {
        //        get { return _ACT_PROY; }
        //        set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
        //    }

        //    string _ANO_EJE;
        //    public string ANO_EJE
        //    {
        //        get { return _ANO_EJE; }
        //        set { SetPropertyValue("ANO_EJE", ref _ANO_EJE, value); }
        //    }

        //    string _SEC_EJEC;
        //    public string SEC_EJEC
        //    {
        //        get { return _SEC_EJEC; }
        //        set { SetPropertyValue("SEC_EJEC", ref _SEC_EJEC, value); }
        //    }

        //    string _EXPEDIENTE;
        //    public string EXPEDIENTE
        //    {
        //        get { return _EXPEDIENTE; }
        //        set { SetPropertyValue("EXPEDIENTE", ref _EXPEDIENTE, value); }
        //    }

        //    string _EXPEDIENTE_SECUENCIA;
        //    public string EXPEDIENTE_SECUENCIA
        //    {
        //        get { return _EXPEDIENTE_SECUENCIA; }
        //        set { SetPropertyValue("EXPEDIENTE_SECUENCIA", ref _EXPEDIENTE_SECUENCIA, value); }
        //    }

        //    string _EXPEDIENTE_CORRELATIVO;
        //    public string EXPEDIENTE_CORRELATIVO
        //    {
        //        get { return _EXPEDIENTE_CORRELATIVO; }
        //        set { SetPropertyValue("EXPEDIENTE_CORRELATIVO", ref _EXPEDIENTE_CORRELATIVO, value); }
        //    }
        //    string _CICLO;
        //    public string CICLO
        //    {
        //        get { return _CICLO; }
        //        set { SetPropertyValue("CICLO", ref _CICLO, value); }
        //    }
        //    string _FASE;
        //    public string FASE
        //    {
        //        get { return _FASE; }
        //        set { SetPropertyValue("FASE", ref _FASE, value); }
        //    }
        //    string _FASE_CONTRACTUAL;
        //    public string FASE_CONTRACTUAL
        //    {
        //        get { return _FASE_CONTRACTUAL; }
        //        set { SetPropertyValue("FASE_CONTRACTUAL", ref _FASE_CONTRACTUAL, value); }
        //    }

        //    string _NOMBRE_RUC;
        //    public string NOMBRE_RUC
        //    {
        //        get { return _NOMBRE_RUC; }
        //        set { SetPropertyValue("NOMBRE_RUC", ref _NOMBRE_RUC, value); }
        //    }

        //    string _NOTAS;
        //    public string NOTAS
        //    {
        //        get { return _NOTAS; }
        //        set { SetPropertyValue("NOTAS", ref _NOTAS, value); }
        //    }

        //    string _TIPO_OPERACION;
        //    public string TIPO_OPERACION
        //    {
        //        get { return _TIPO_OPERACION; }
        //        set { SetPropertyValue("TIPO_OPERACION", ref _TIPO_OPERACION, value); }
        //    }
        //    string _TIPO_RECURSO;
        //    public string TIPO_RECURSO
        //    {
        //        get { return _TIPO_RECURSO; }
        //        set { SetPropertyValue("TIPO_RECURSO", ref _TIPO_RECURSO, value); }
        //    }

        //    string _FUENTE_FINANC;
        //    public string FUENTE_FINANC
        //    {
        //        get { return _FUENTE_FINANC; }
        //        set { SetPropertyValue("FUENTE_FINANC", ref _FUENTE_FINANC, value); }
        //    }

        //    string _ANO_CTA_CTE;
        //    public string ANO_CTA_CTE
        //    {
        //        get { return _ANO_CTA_CTE; }
        //        set { SetPropertyValue("ANO_CTA_CTE", ref _ANO_CTA_CTE, value); }
        //    }

        //    string _BANCO;
        //    public string BANCO
        //    {
        //        get { return _BANCO; }
        //        set { SetPropertyValue("BANCO", ref _BANCO, value); }
        //    }

        //    string _CTA_CTE;
        //    public string CTA_CTE
        //    {
        //        get { return _CTA_CTE; }
        //        set { SetPropertyValue("CTA_CTE", ref _CTA_CTE, value); }
        //    }

        //    string _CTA_BCO_EJEC;
        //    public string CTA_BCO_EJEC
        //    {
        //        get { return _CTA_BCO_EJEC; }
        //        set { SetPropertyValue("CTA_BCO_EJEC", ref _CTA_BCO_EJEC, value); }
        //    }

        //    string _COD_DOC;
        //    public string COD_DOC
        //    {
        //        get { return _COD_DOC; }
        //        set { SetPropertyValue("COD_DOC", ref _COD_DOC, value); }
        //    }

        //    string _RUC_NOMBRE;
        //    public string RUC_NOMBRE
        //    {
        //        get { return _RUC_NOMBRE; }
        //        set { SetPropertyValue("RUC_NOMBRE", ref _RUC_NOMBRE, value); }
        //    }

        //    string _MES_EJE;
        //    public string MES_EJE
        //    {
        //        get { return _MES_EJE; }
        //        set { SetPropertyValue("MES_EJE", ref _MES_EJE, value); }
        //    }

        //    string _NUM_DOC;
        //    public string NUM_DOC
        //    {
        //        get { return _NUM_DOC; }
        //        set { SetPropertyValue("NUM_DOC", ref _NUM_DOC, value); }
        //    }

        //    string _FECHA_DOC;
        //    public string FECHA_DOC
        //    {
        //        get { return _FECHA_DOC; }
        //        set { SetPropertyValue("FECHA_DOC", ref _FECHA_DOC, value); }
        //    }

        //    string _FECHA;
        //    public string FECHA
        //    {
        //        get { return _FECHA; }
        //        set { SetPropertyValue("FECHA", ref _FECHA, value); }
        //    }

        //    string _ESPECIFICA_DET;
        //    public string ESPECIFICA_DET
        //    {
        //        get { return _ESPECIFICA_DET; }
        //        set { SetPropertyValue("ESPECIFICA_DET", ref _ESPECIFICA_DET, value); }
        //    }

        //    string _ID_CLASIFICADOR;
        //    public string ID_CLASIFICADOR
        //    {
        //        get { return _ID_CLASIFICADOR; }
        //        set { SetPropertyValue("ID_CLASIFICADOR", ref _ID_CLASIFICADOR, value); }
        //    }

        //    string _CERTIFICADO;
        //    public string CERTIFICADO
        //    {
        //        get { return _CERTIFICADO; }
        //        set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
        //    }

        //    string _DOCUMENTOB;
        //    public string DOCUMENTOB
        //    {
        //        get { return _DOCUMENTOB; }
        //        set { SetPropertyValue("DOCUMENTOB", ref _DOCUMENTOB, value); }
        //    }

        //    string _SEC_FUNC;
        //    public string SEC_FUNC
        //    {
        //        get { return _SEC_FUNC; }
        //        set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
        //    }

        //    string _EJECUCION;
        //    public string EJECUCION
        //    {
        //        get { return _EJECUCION; }
        //        set { SetPropertyValue("EJECUCION", ref _EJECUCION, value); }
        //    }

        //    string _ESTADO;
        //    public string ESTADO
        //    {
        //        get { return _ESTADO; }
        //        set { SetPropertyValue("ESTADO", ref _ESTADO, value); }
        //    }

        //    string _ESTADO_REGISTRO;
        //    public string ESTADO_REGISTRO
        //    {
        //        get { return _ESTADO_REGISTRO; }
        //        set { SetPropertyValue("ESTADO_REGISTRO", ref _ESTADO_REGISTRO, value); }
        //    }

        //    string _ESTADO_ENVIO;
        //    public string ESTADO_ENVIO
        //    {
        //        get { return _ESTADO_ENVIO; }
        //        set { SetPropertyValue("ESTADO_ENVIO", ref _ESTADO_ENVIO, value); }
        //    }

        //    [Association("Certificado-Expediente")]
        //    public infoges_control_certificado infoges_control_certificado;
        //}

}
