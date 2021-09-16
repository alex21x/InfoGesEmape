using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;

namespace PersistentObjects 
{

        [NonPersistent]

        public class MyBaseObject : XPObject
        {
            public MyBaseObject(Session session) : base(session) { }
        }

        public class gso_estado_situacional : MyBaseObject
        {
            public gso_estado_situacional(Session session) : base(session) { }


            string _PAQUETE;
            public string PAQUETE
            {
                get { return _PAQUETE; }
                set { SetPropertyValue("PAQUETE", ref _PAQUETE, value); }
            }

            string _DESCRIPCION;
            public string DESCRIPCION
            {
                get { return _DESCRIPCION; }
                set { SetPropertyValue("DESCRIPCION", ref _DESCRIPCION, value); }
            }

            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
            }

            string _ABREVIATURA;
            public string ABREVIATURA
            {
                get { return _ABREVIATURA; }
                set { SetPropertyValue("ABREVIATURA", ref _ABREVIATURA, value); }
            }

            string _DISTRITO;
            public string DISTRITO
            {
                get { return _DISTRITO; }
                set { SetPropertyValue("DISTRITO", ref _DISTRITO, value); }
            }

            string _ANO_EJE;
            public string ANO_EJE
            {
                get { return _ANO_EJE; }
                set { SetPropertyValue("ANO_EJE", ref _ANO_EJE, value); }
            }

            string _ACTIVIDAD;
            public string ACTIVIDAD
            {
                get { return _ACTIVIDAD; }
                set { SetPropertyValue("ACTIVIDAD", ref _ACTIVIDAD, value); }
            }

            string _FECHA_ENTREGA_TERRENO;
            public string FECHA_ENTREGA_TERRENO
            {
                get { return _FECHA_ENTREGA_TERRENO; }
                set { SetPropertyValue("FECHA_ENTREGA_TERRENO", ref _FECHA_ENTREGA_TERRENO, value); }
            }

            string _FECHA_INICIO_OBRA;
            public string FECHA_INICIO_OBRA
            {
                get { return _FECHA_INICIO_OBRA; }
                set { SetPropertyValue("FECHA_INICIO_OBRA", ref _FECHA_INICIO_OBRA, value); }
            }

            string _ESTADO_OBRA;
            public string ESTADO_OBRA
            {
                get { return _ESTADO_OBRA; }
                set { SetPropertyValue("ESTADO_OBRA", ref _ESTADO_OBRA, value); }
            }

            string _PLAZO_EJECUCION;
            public string PLAZO_EJECUCION
            {
                get { return _PLAZO_EJECUCION; }
                set { SetPropertyValue("PLAZO_EJECUCION", ref _PLAZO_EJECUCION, value); }
            }

            string _FECHA_CULMINACION;
            public string FECHA_CULMINACION
            {
                get { return _FECHA_CULMINACION; }
                set { SetPropertyValue("FECHA_CULMINACION", ref _FECHA_CULMINACION, value); }
            }


            string _SEC_EJEC;
            public string SEC_EJEC
            {
                get { return _SEC_EJEC; }
                set { SetPropertyValue("SEC_EJEC", ref _SEC_EJEC, value); }
            }
        }


        public class auxiliar : MyBaseObject
        {
            public auxiliar(Session session) : base(session) { }


            string _CAMPO;
            public string CAMPO
            {
                get { return _CAMPO; }
                set { SetPropertyValue("CAMPO", ref _CAMPO, value); }
            }

            string _DESCRIPCION;
            public string DESCRIPCION
            {
                get { return _DESCRIPCION; }
                set { SetPropertyValue("DESCRIPCION", ref _DESCRIPCION, value); }
            }

            string _CANTIDAD;
            public string CANTIDAD
            {
                get { return _CANTIDAD; }
                set { SetPropertyValue("CANTIDAD", ref _CANTIDAD, value); }
            }

            string _COSTO_UNITARIO;
            public string COSTO_UNITARIO
            {
                get { return _COSTO_UNITARIO; }
                set { SetPropertyValue("COSTO_UNITARIO", ref _COSTO_UNITARIO, value); }
            }

            string _TOTAL;
            public string TOTAL
            {
                get { return _TOTAL; }
                set { SetPropertyValue("TOTAL", ref _TOTAL, value); }
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

        }


        public class contrato_presupuesto : MyBaseObject
        {
            public contrato_presupuesto(Session session) : base(session) { }


            string _IDCONTRATO;
            public string IDCONTRATO
            {
                get { return _IDCONTRATO; }
                set { SetPropertyValue("IDCONTRATO", ref _IDCONTRATO, value); }
            }

            string _IDCONTRATOPRESUPUESTO;
            public string IDCONTRATOPRESUPUESTO
            {
                get { return _IDCONTRATOPRESUPUESTO; }
                set { SetPropertyValue("IDCONTRATOPRESUPUESTO", ref _IDCONTRATOPRESUPUESTO, value); }
            }

            string _ITEM;
            public string ITEM
            {
                get { return _ITEM; }
                set { SetPropertyValue("ITEM", ref _ITEM, value); }
            }

            string _DESCRIPCION;
            public string DESCRIPCION
            {
                get { return _DESCRIPCION; }
                set { SetPropertyValue("DESCRIPCION", ref _DESCRIPCION, value); }
            }

            decimal _UNIDAD_MEDIDA;
            public decimal UNIDAD_MEDIDA
            {
                get { return _UNIDAD_MEDIDA; }
                set { SetPropertyValue("UNIDAD_MEDIDA", ref _UNIDAD_MEDIDA, value); }
            }

            decimal _METRADO;
            public decimal METRADO
            {
                get { return _METRADO; }
                set { SetPropertyValue("METRADO", ref _METRADO, value); }
            }

            decimal _PRECIO;
            public decimal PRECIO
            {
                get { return _PRECIO; }
                set { SetPropertyValue("PRECIO", ref _PRECIO, value); }
            }

            decimal _TOTAL;
            public decimal TOTAL
            {
                get { return _TOTAL; }
                set { SetPropertyValue("TOTAL", ref _TOTAL, value); }
            }

            decimal _ESEDITABLE;
            public decimal ESEDITABLE
            {
                get { return _ESEDITABLE; }
                set { SetPropertyValue("ESEDITABLE", ref _ESEDITABLE, value); }
            }

        }

        public class infoges_exp : MyBaseObject
        {
            public infoges_exp(Session session) : base(session) { }

            //int oid;
            //[Key(true)]
            //public int Oid
            //{
            //    get { return oid; }
            //    set { SetPropertyValue(typeof(Oid).Name, ref oid, value); }
            //}

            //string _OID;
            //public string OID
            //{
            //    get { return _OID; }
            //    set { SetPropertyValue("OID", ref _OID, value); }
            //}

            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
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

            string _EXPEDIENTE;
            public string EXPEDIENTE
            {
                get { return _EXPEDIENTE; }
                set { SetPropertyValue("EXPEDIENTE", ref _EXPEDIENTE, value); }
            }

            string _EXPEDIENTE_SECUENCIA;
            public string EXPEDIENTE_SECUENCIA
            {
                get { return _EXPEDIENTE_SECUENCIA; }
                set { SetPropertyValue("EXPEDIENTE_SECUENCIA", ref _EXPEDIENTE_SECUENCIA, value); }
            }

            string _EXPEDIENTE_CORRELATIVO;
            public string EXPEDIENTE_CORRELATIVO
            {
                get { return _EXPEDIENTE_CORRELATIVO; }
                set { SetPropertyValue("EXPEDIENTE_CORRELATIVO", ref _EXPEDIENTE_CORRELATIVO, value); }
            }
            string _CICLO;
            public string CICLO
            {
                get { return _CICLO; }
                set { SetPropertyValue("CICLO", ref _CICLO, value); }
            }
            string _FASE;
            public string FASE
            {
                get { return _FASE; }
                set { SetPropertyValue("FASE", ref _FASE, value); }
            }
            string _FASE_CONTRACTUAL;
            public string FASE_CONTRACTUAL
            {
                get { return _FASE_CONTRACTUAL; }
                set { SetPropertyValue("FASE_CONTRACTUAL", ref _FASE_CONTRACTUAL, value); }
            }

            string _NOMBRE_RUC;
            public string NOMBRE_RUC
            {
                get { return _NOMBRE_RUC; }
                set { SetPropertyValue("NOMBRE_RUC", ref _NOMBRE_RUC, value); }
            }

            string _NOTAS;
            public string NOTAS
            {
                get { return _NOTAS; }
                set { SetPropertyValue("NOTAS", ref _NOTAS, value); }
            }

            string _TIPO_OPERACION;
            public string TIPO_OPERACION
            {
                get { return _TIPO_OPERACION; }
                set { SetPropertyValue("TIPO_OPERACION", ref _TIPO_OPERACION, value); }
            }
            string _TIPO_RECURSO;
            public string TIPO_RECURSO
            {
                get { return _TIPO_RECURSO; }
                set { SetPropertyValue("TIPO_RECURSO", ref _TIPO_RECURSO, value); }
            }

            string _FUENTE_FINANC;
            public string FUENTE_FINANC
            {
                get { return _FUENTE_FINANC; }
                set { SetPropertyValue("FUENTE_FINANC", ref _FUENTE_FINANC, value); }
            }

            string _ANO_CTA_CTE;
            public string ANO_CTA_CTE
            {
                get { return _ANO_CTA_CTE; }
                set { SetPropertyValue("ANO_CTA_CTE", ref _ANO_CTA_CTE, value); }
            }

            string _BANCO;
            public string BANCO
            {
                get { return _BANCO; }
                set { SetPropertyValue("BANCO", ref _BANCO, value); }
            }

            string _CTA_CTE;
            public string CTA_CTE
            {
                get { return _CTA_CTE; }
                set { SetPropertyValue("CTA_CTE", ref _CTA_CTE, value); }
            }

            string _CTA_BCO_EJEC;
            public string CTA_BCO_EJEC
            {
                get { return _CTA_BCO_EJEC; }
                set { SetPropertyValue("CTA_BCO_EJEC", ref _CTA_BCO_EJEC, value); }
            }

            string _COD_DOC;
            public string COD_DOC
            {
                get { return _COD_DOC; }
                set { SetPropertyValue("COD_DOC", ref _COD_DOC, value); }
            }

            string _RUC_NOMBRE;
            public string RUC_NOMBRE
            {
                get { return _RUC_NOMBRE; }
                set { SetPropertyValue("RUC_NOMBRE", ref _RUC_NOMBRE, value); }
            }

            string _MES_EJE;
            public string MES_EJE
            {
                get { return _MES_EJE; }
                set { SetPropertyValue("MES_EJE", ref _MES_EJE, value); }
            }

            string _NUM_DOC;
            public string NUM_DOC
            {
                get { return _NUM_DOC; }
                set { SetPropertyValue("NUM_DOC", ref _NUM_DOC, value); }
            }

            string _FECHA_DOC;
            public string FECHA_DOC
            {
                get { return _FECHA_DOC; }
                set { SetPropertyValue("FECHA_DOC", ref _FECHA_DOC, value); }
            }

            string _FECHA;
            public string FECHA
            {
                get { return _FECHA; }
                set { SetPropertyValue("FECHA", ref _FECHA, value); }
            }

            string _ESPECIFICA_DET;
            public string ESPECIFICA_DET
            {
                get { return _ESPECIFICA_DET; }
                set { SetPropertyValue("ESPECIFICA_DET", ref _ESPECIFICA_DET, value); }
            }

            string _ID_CLASIFICADOR;
            public string ID_CLASIFICADOR
            {
                get { return _ID_CLASIFICADOR; }
                set { SetPropertyValue("ID_CLASIFICADOR", ref _ID_CLASIFICADOR, value); }
            }

            string _CERTIFICADO;
            public string CERTIFICADO
            {
                get { return _CERTIFICADO; }
                set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
            }

            string _DOCUMENTOB;
            public string DOCUMENTOB
            {
                get { return _DOCUMENTOB; }
                set { SetPropertyValue("DOCUMENTOB", ref _DOCUMENTOB, value); }
            }

            string _SEC_FUNC;
            public string SEC_FUNC
            {
                get { return _SEC_FUNC; }
                set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
            }

            string _EJECUCION;
            public string EJECUCION
            {
                get { return _EJECUCION; }
                set { SetPropertyValue("EJECUCION", ref _EJECUCION, value); }
            }

            string _ESTADO;
            public string ESTADO
            {
                get { return _ESTADO; }
                set { SetPropertyValue("ESTADO", ref _ESTADO, value); }
            }

            string _ESTADO_REGISTRO;
            public string ESTADO_REGISTRO
            {
                get { return _ESTADO_REGISTRO; }
                set { SetPropertyValue("ESTADO_REGISTRO", ref _ESTADO_REGISTRO, value); }
            }
			
            string _ESTADO_ENVIO;
            public string ESTADO_ENVIO
            {
                get { return _ESTADO_ENVIO; }
                set { SetPropertyValue("ESTADO_ENVIO", ref _ESTADO_ENVIO, value); }
            }

            string _FECHA_AUTORIZACION;
            public string FECHA_AUTORIZACION
            {
                get { return _FECHA_AUTORIZACION; }
                set { SetPropertyValue("FECHA_AUTORIZACION", ref _FECHA_AUTORIZACION, value); }
            }																								
            //[Association("Customer-Orders")]
            //public XPCollection<Order> Orders
            //{
            //    get { return GetCollection<Order>("Orders"); }
            //}
        }
        public class infoges_exp_compromiso_sin_dev : MyBaseObject
        {
            public infoges_exp_compromiso_sin_dev(Session session) : base(session) { }

            //int oid;


            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
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

            string _EXPEDIENTE;
            public string EXPEDIENTE
            {
                get { return _EXPEDIENTE; }
                set { SetPropertyValue("EXPEDIENTE", ref _EXPEDIENTE, value); }
            }

            string _EXPEDIENTE_SECUENCIA;
            public string EXPEDIENTE_SECUENCIA
            {
                get { return _EXPEDIENTE_SECUENCIA; }
                set { SetPropertyValue("EXPEDIENTE_SECUENCIA", ref _EXPEDIENTE_SECUENCIA, value); }
            }

            string _EXPEDIENTE_CORRELATIVO;
            public string EXPEDIENTE_CORRELATIVO
            {
                get { return _EXPEDIENTE_CORRELATIVO; }
                set { SetPropertyValue("EXPEDIENTE_CORRELATIVO", ref _EXPEDIENTE_CORRELATIVO, value); }
            }
            string _CICLO;
            public string CICLO
            {
                get { return _CICLO; }
                set { SetPropertyValue("CICLO", ref _CICLO, value); }
            }
            string _FASE;
            public string FASE
            {
                get { return _FASE; }
                set { SetPropertyValue("FASE", ref _FASE, value); }
            }
            string _FASE_CONTRACTUAL;
            public string FASE_CONTRACTUAL
            {
                get { return _FASE_CONTRACTUAL; }
                set { SetPropertyValue("FASE_CONTRACTUAL", ref _FASE_CONTRACTUAL, value); }
            }

            string _NOMBRE_RUC;
            public string NOMBRE_RUC
            {
                get { return _NOMBRE_RUC; }
                set { SetPropertyValue("NOMBRE_RUC", ref _NOMBRE_RUC, value); }
            }

            string _NOTAS;
            public string NOTAS
            {
                get { return _NOTAS; }
                set { SetPropertyValue("NOTAS", ref _NOTAS, value); }
            }

            string _TIPO_OPERACION;
            public string TIPO_OPERACION
            {
                get { return _TIPO_OPERACION; }
                set { SetPropertyValue("TIPO_OPERACION", ref _TIPO_OPERACION, value); }
            }
            string _TIPO_RECURSO;
            public string TIPO_RECURSO
            {
                get { return _TIPO_RECURSO; }
                set { SetPropertyValue("TIPO_RECURSO", ref _TIPO_RECURSO, value); }
            }

            string _FUENTE_FINANC;
            public string FUENTE_FINANC
            {
                get { return _FUENTE_FINANC; }
                set { SetPropertyValue("FUENTE_FINANC", ref _FUENTE_FINANC, value); }
            }

            string _ANO_CTA_CTE;
            public string ANO_CTA_CTE
            {
                get { return _ANO_CTA_CTE; }
                set { SetPropertyValue("ANO_CTA_CTE", ref _ANO_CTA_CTE, value); }
            }

            string _BANCO;
            public string BANCO
            {
                get { return _BANCO; }
                set { SetPropertyValue("BANCO", ref _BANCO, value); }
            }

            string _CTA_CTE;
            public string CTA_CTE
            {
                get { return _CTA_CTE; }
                set { SetPropertyValue("CTA_CTE", ref _CTA_CTE, value); }
            }

            string _CTA_BCO_EJEC;
            public string CTA_BCO_EJEC
            {
                get { return _CTA_BCO_EJEC; }
                set { SetPropertyValue("CTA_BCO_EJEC", ref _CTA_BCO_EJEC, value); }
            }

            string _COD_DOC;
            public string COD_DOC
            {
                get { return _COD_DOC; }
                set { SetPropertyValue("COD_DOC", ref _COD_DOC, value); }
            }

            string _RUC_NOMBRE;
            public string RUC_NOMBRE
            {
                get { return _RUC_NOMBRE; }
                set { SetPropertyValue("RUC_NOMBRE", ref _RUC_NOMBRE, value); }
            }

            string _MES_EJE;
            public string MES_EJE
            {
                get { return _MES_EJE; }
                set { SetPropertyValue("MES_EJE", ref _MES_EJE, value); }
            }

            string _NUM_DOC;
            public string NUM_DOC
            {
                get { return _NUM_DOC; }
                set { SetPropertyValue("NUM_DOC", ref _NUM_DOC, value); }
            }

            string _FECHA_DOC;
            public string FECHA_DOC
            {
                get { return _FECHA_DOC; }
                set { SetPropertyValue("FECHA_DOC", ref _FECHA_DOC, value); }
            }

            string _FECHA;
            public string FECHA
            {
                get { return _FECHA; }
                set { SetPropertyValue("FECHA", ref _FECHA, value); }
            }

            string _ESPECIFICA_DET;
            public string ESPECIFICA_DET
            {
                get { return _ESPECIFICA_DET; }
                set { SetPropertyValue("ESPECIFICA_DET", ref _ESPECIFICA_DET, value); }
            }

            string _ID_CLASIFICADOR;
            public string ID_CLASIFICADOR
            {
                get { return _ID_CLASIFICADOR; }
                set { SetPropertyValue("ID_CLASIFICADOR", ref _ID_CLASIFICADOR, value); }
            }

            string _CERTIFICADO;
            public string CERTIFICADO
            {
                get { return _CERTIFICADO; }
                set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
            }

            string _DOCUMENTOB;
            public string DOCUMENTOB
            {
                get { return _DOCUMENTOB; }
                set { SetPropertyValue("DOCUMENTOB", ref _DOCUMENTOB, value); }
            }

            string _SEC_FUNC;
            public string SEC_FUNC
            {
                get { return _SEC_FUNC; }
                set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
            }

            string _EJECUCION;
            public string EJECUCION
            {
                get { return _EJECUCION; }
                set { SetPropertyValue("EJECUCION", ref _EJECUCION, value); }
            }

            string _ESTADO;
            public string ESTADO
            {
                get { return _ESTADO; }
                set { SetPropertyValue("ESTADO", ref _ESTADO, value); }
            }
            
            string _ESTADO_ENVIO;
            public string ESTADO_ENVIO
            {
                get { return _ESTADO_ENVIO; }
                set { SetPropertyValue("ESTADO_ENVIO", ref _ESTADO_ENVIO, value); }
            }

            string _FECHA_AUTORIZACION;
            public string FECHA_AUTORIZACION
            {
                get { return _FECHA_AUTORIZACION; }
                set { SetPropertyValue("FECHA_AUTORIZACION", ref _FECHA_AUTORIZACION, value); }
            }																								


            //[Association("Customer-Orders")]
            //public XPCollection<Order> Orders
            //{
            //    get { return GetCollection<Order>("Orders"); }
            //}
        }
        public class infoges_exp_devengados_sin_giro : MyBaseObject
        {
            public infoges_exp_devengados_sin_giro(Session session) : base(session) { }

            //int oid;


            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
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

            string _EXPEDIENTE;
            public string EXPEDIENTE
            {
                get { return _EXPEDIENTE; }
                set { SetPropertyValue("EXPEDIENTE", ref _EXPEDIENTE, value); }
            }

            string _EXPEDIENTE_SECUENCIA;
            public string EXPEDIENTE_SECUENCIA
            {
                get { return _EXPEDIENTE_SECUENCIA; }
                set { SetPropertyValue("EXPEDIENTE_SECUENCIA", ref _EXPEDIENTE_SECUENCIA, value); }
            }

            string _EXPEDIENTE_CORRELATIVO;
            public string EXPEDIENTE_CORRELATIVO
            {
                get { return _EXPEDIENTE_CORRELATIVO; }
                set { SetPropertyValue("EXPEDIENTE_CORRELATIVO", ref _EXPEDIENTE_CORRELATIVO, value); }
            }
            string _CICLO;
            public string CICLO
            {
                get { return _CICLO; }
                set { SetPropertyValue("CICLO", ref _CICLO, value); }
            }
            string _FASE;
            public string FASE
            {
                get { return _FASE; }
                set { SetPropertyValue("FASE", ref _FASE, value); }
            }
            string _FASE_CONTRACTUAL;
            public string FASE_CONTRACTUAL
            {
                get { return _FASE_CONTRACTUAL; }
                set { SetPropertyValue("FASE_CONTRACTUAL", ref _FASE_CONTRACTUAL, value); }
            }

            string _NOMBRE_RUC;
            public string NOMBRE_RUC
            {
                get { return _NOMBRE_RUC; }
                set { SetPropertyValue("NOMBRE_RUC", ref _NOMBRE_RUC, value); }
            }

            string _NOTAS;
            public string NOTAS
            {
                get { return _NOTAS; }
                set { SetPropertyValue("NOTAS", ref _NOTAS, value); }
            }

            string _TIPO_OPERACION;
            public string TIPO_OPERACION
            {
                get { return _TIPO_OPERACION; }
                set { SetPropertyValue("TIPO_OPERACION", ref _TIPO_OPERACION, value); }
            }
            string _TIPO_RECURSO;
            public string TIPO_RECURSO
            {
                get { return _TIPO_RECURSO; }
                set { SetPropertyValue("TIPO_RECURSO", ref _TIPO_RECURSO, value); }
            }

            string _FUENTE_FINANC;
            public string FUENTE_FINANC
            {
                get { return _FUENTE_FINANC; }
                set { SetPropertyValue("FUENTE_FINANC", ref _FUENTE_FINANC, value); }
            }

            string _ANO_CTA_CTE;
            public string ANO_CTA_CTE
            {
                get { return _ANO_CTA_CTE; }
                set { SetPropertyValue("ANO_CTA_CTE", ref _ANO_CTA_CTE, value); }
            }

            string _BANCO;
            public string BANCO
            {
                get { return _BANCO; }
                set { SetPropertyValue("BANCO", ref _BANCO, value); }
            }

            string _CTA_CTE;
            public string CTA_CTE
            {
                get { return _CTA_CTE; }
                set { SetPropertyValue("CTA_CTE", ref _CTA_CTE, value); }
            }

            string _CTA_BCO_EJEC;
            public string CTA_BCO_EJEC
            {
                get { return _CTA_BCO_EJEC; }
                set { SetPropertyValue("CTA_BCO_EJEC", ref _CTA_BCO_EJEC, value); }
            }

            string _COD_DOC;
            public string COD_DOC
            {
                get { return _COD_DOC; }
                set { SetPropertyValue("COD_DOC", ref _COD_DOC, value); }
            }

            string _RUC_NOMBRE;
            public string RUC_NOMBRE
            {
                get { return _RUC_NOMBRE; }
                set { SetPropertyValue("RUC_NOMBRE", ref _RUC_NOMBRE, value); }
            }

            string _MES_EJE;
            public string MES_EJE
            {
                get { return _MES_EJE; }
                set { SetPropertyValue("MES_EJE", ref _MES_EJE, value); }
            }

            string _NUM_DOC;
            public string NUM_DOC
            {
                get { return _NUM_DOC; }
                set { SetPropertyValue("NUM_DOC", ref _NUM_DOC, value); }
            }

            string _FECHA_DOC;
            public string FECHA_DOC
            {
                get { return _FECHA_DOC; }
                set { SetPropertyValue("FECHA_DOC", ref _FECHA_DOC, value); }
            }

            string _FECHA;
            public string FECHA
            {
                get { return _FECHA; }
                set { SetPropertyValue("FECHA", ref _FECHA, value); }
            }

            string _ESPECIFICA_DET;
            public string ESPECIFICA_DET
            {
                get { return _ESPECIFICA_DET; }
                set { SetPropertyValue("ESPECIFICA_DET", ref _ESPECIFICA_DET, value); }
            }

            string _ID_CLASIFICADOR;
            public string ID_CLASIFICADOR
            {
                get { return _ID_CLASIFICADOR; }
                set { SetPropertyValue("ID_CLASIFICADOR", ref _ID_CLASIFICADOR, value); }
            }

            string _CERTIFICADO;
            public string CERTIFICADO
            {
                get { return _CERTIFICADO; }
                set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
            }

            string _DOCUMENTOB;
            public string DOCUMENTOB
            {
                get { return _DOCUMENTOB; }
                set { SetPropertyValue("DOCUMENTOB", ref _DOCUMENTOB, value); }
            }

            string _SEC_FUNC;
            public string SEC_FUNC
            {
                get { return _SEC_FUNC; }
                set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
            }

            string _EJECUCION;
            public string EJECUCION
            {
                get { return _EJECUCION; }
                set { SetPropertyValue("EJECUCION", ref _EJECUCION, value); }
            }

            string _ESTADO;
            public string ESTADO
            {
                get { return _ESTADO; }
                set { SetPropertyValue("ESTADO", ref _ESTADO, value); }
            }

            //string _ESTADO_REGISTRO;
            //public string ESTADO_REGISTRO
            //{
            //    get { return _ESTADO_REGISTRO; }
            //    set { SetPropertyValue("ESTADO_REGISTRO", ref _ESTADO_REGISTRO, value); }
            //}

            string _ESTADO_ENVIO;
            public string ESTADO_ENVIO
            {
                get { return _ESTADO_ENVIO; }
                set { SetPropertyValue("ESTADO_ENVIO", ref _ESTADO_ENVIO, value); }
            }

            string _FECHA_AUTORIZACION;
            public string FECHA_AUTORIZACION
            {
                get { return _FECHA_AUTORIZACION; }
                set { SetPropertyValue("FECHA_AUTORIZACION", ref _FECHA_AUTORIZACION, value); }
            }																								

            //[Association("Customer-Orders")]
            //public XPCollection<Order> Orders
            //{
            //    get { return GetCollection<Order>("Orders"); }
            //}
        }
        public class infoges_exp_fondos_por_rendir : MyBaseObject
        {
            public infoges_exp_fondos_por_rendir(Session session) : base(session) { }

            //int oid;


            string _ACT_PROY;
            public string ACT_PROY
            {
                get { return _ACT_PROY; }
                set { SetPropertyValue("ACT_PROY", ref _ACT_PROY, value); }
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

            string _EXPEDIENTE;
            public string EXPEDIENTE
            {
                get { return _EXPEDIENTE; }
                set { SetPropertyValue("EXPEDIENTE", ref _EXPEDIENTE, value); }
            }

            string _EXPEDIENTE_SECUENCIA;
            public string EXPEDIENTE_SECUENCIA
            {
                get { return _EXPEDIENTE_SECUENCIA; }
                set { SetPropertyValue("EXPEDIENTE_SECUENCIA", ref _EXPEDIENTE_SECUENCIA, value); }
            }

            string _EXPEDIENTE_CORRELATIVO;
            public string EXPEDIENTE_CORRELATIVO
            {
                get { return _EXPEDIENTE_CORRELATIVO; }
                set { SetPropertyValue("EXPEDIENTE_CORRELATIVO", ref _EXPEDIENTE_CORRELATIVO, value); }
            }
            string _CICLO;
            public string CICLO
            {
                get { return _CICLO; }
                set { SetPropertyValue("CICLO", ref _CICLO, value); }
            }
            string _FASE;
            public string FASE
            {
                get { return _FASE; }
                set { SetPropertyValue("FASE", ref _FASE, value); }
            }
            string _FASE_CONTRACTUAL;
            public string FASE_CONTRACTUAL
            {
                get { return _FASE_CONTRACTUAL; }
                set { SetPropertyValue("FASE_CONTRACTUAL", ref _FASE_CONTRACTUAL, value); }
            }

            string _NOMBRE_RUC;
            public string NOMBRE_RUC
            {
                get { return _NOMBRE_RUC; }
                set { SetPropertyValue("NOMBRE_RUC", ref _NOMBRE_RUC, value); }
            }

            string _NOTAS;
            public string NOTAS
            {
                get { return _NOTAS; }
                set { SetPropertyValue("NOTAS", ref _NOTAS, value); }
            }

            string _TIPO_OPERACION;
            public string TIPO_OPERACION
            {
                get { return _TIPO_OPERACION; }
                set { SetPropertyValue("TIPO_OPERACION", ref _TIPO_OPERACION, value); }
            }
            string _TIPO_RECURSO;
            public string TIPO_RECURSO
            {
                get { return _TIPO_RECURSO; }
                set { SetPropertyValue("TIPO_RECURSO", ref _TIPO_RECURSO, value); }
            }

            string _FUENTE_FINANC;
            public string FUENTE_FINANC
            {
                get { return _FUENTE_FINANC; }
                set { SetPropertyValue("FUENTE_FINANC", ref _FUENTE_FINANC, value); }
            }

            string _ANO_CTA_CTE;
            public string ANO_CTA_CTE
            {
                get { return _ANO_CTA_CTE; }
                set { SetPropertyValue("ANO_CTA_CTE", ref _ANO_CTA_CTE, value); }
            }

            string _BANCO;
            public string BANCO
            {
                get { return _BANCO; }
                set { SetPropertyValue("BANCO", ref _BANCO, value); }
            }

            string _CTA_CTE;
            public string CTA_CTE
            {
                get { return _CTA_CTE; }
                set { SetPropertyValue("CTA_CTE", ref _CTA_CTE, value); }
            }

            string _CTA_BCO_EJEC;
            public string CTA_BCO_EJEC
            {
                get { return _CTA_BCO_EJEC; }
                set { SetPropertyValue("CTA_BCO_EJEC", ref _CTA_BCO_EJEC, value); }
            }

            string _COD_DOC;
            public string COD_DOC
            {
                get { return _COD_DOC; }
                set { SetPropertyValue("COD_DOC", ref _COD_DOC, value); }
            }

            string _RUC_NOMBRE;
            public string RUC_NOMBRE
            {
                get { return _RUC_NOMBRE; }
                set { SetPropertyValue("RUC_NOMBRE", ref _RUC_NOMBRE, value); }
            }

            string _MES_EJE;
            public string MES_EJE
            {
                get { return _MES_EJE; }
                set { SetPropertyValue("MES_EJE", ref _MES_EJE, value); }
            }

            string _NUM_DOC;
            public string NUM_DOC
            {
                get { return _NUM_DOC; }
                set { SetPropertyValue("NUM_DOC", ref _NUM_DOC, value); }
            }

            string _FECHA_DOC;
            public string FECHA_DOC
            {
                get { return _FECHA_DOC; }
                set { SetPropertyValue("FECHA_DOC", ref _FECHA_DOC, value); }
            }

            string _FECHA;
            public string FECHA
            {
                get { return _FECHA; }
                set { SetPropertyValue("FECHA", ref _FECHA, value); }
            }

            string _ESPECIFICA_DET;
            public string ESPECIFICA_DET
            {
                get { return _ESPECIFICA_DET; }
                set { SetPropertyValue("ESPECIFICA_DET", ref _ESPECIFICA_DET, value); }
            }

            //string _ID_CLASIFICADOR;
            //public string ID_CLASIFICADOR
            //{
            //    get { return _ID_CLASIFICADOR; }
            //    set { SetPropertyValue("ID_CLASIFICADOR", ref _ID_CLASIFICADOR, value); }
            //}

            string _CERTIFICADO;
            public string CERTIFICADO
            {
                get { return _CERTIFICADO; }
                set { SetPropertyValue("CERTIFICADO", ref _CERTIFICADO, value); }
            }

            string _DOCUMENTOB;
            public string DOCUMENTOB
            {
                get { return _DOCUMENTOB; }
                set { SetPropertyValue("DOCUMENTOB", ref _DOCUMENTOB, value); }
            }

            string _SEC_FUNC;
            public string SEC_FUNC
            {
                get { return _SEC_FUNC; }
                set { SetPropertyValue("SEC_FUNC", ref _SEC_FUNC, value); }
            }

            string _EJECUCION;
            public string EJECUCION
            {
                get { return _EJECUCION; }
                set { SetPropertyValue("EJECUCION", ref _EJECUCION, value); }
            }

            string _ESTADO;
            public string ESTADO
            {
                get { return _ESTADO; }
                set { SetPropertyValue("ESTADO", ref _ESTADO, value); }
            }

            //string _ESTADO_REGISTRO;
            //public string ESTADO_REGISTRO
            //{
            //    get { return _ESTADO_REGISTRO; }
            //    set { SetPropertyValue("ESTADO_REGISTRO", ref _ESTADO_REGISTRO, value); }
            //}

            string _ESTADO_ENVIO;
            public string ESTADO_ENVIO
            {
                get { return _ESTADO_ENVIO; }
                set { SetPropertyValue("ESTADO_ENVIO", ref _ESTADO_ENVIO, value); }
            }

            string _FECHA_AUTORIZACION;
            public string FECHA_AUTORIZACION
            {
                get { return _FECHA_AUTORIZACION; }
                set { SetPropertyValue("FECHA_AUTORIZACION", ref _FECHA_AUTORIZACION, value); }
            }																								

            //[Association("Customer-Orders")]
            //public XPCollection<Order> Orders
            //{
            //    get { return GetCollection<Order>("Orders"); }
            //}
        }

        //public class Order : MyBaseObject
        //{
        //    public Order(Session session) : base(session) { }

        //    DateTime _OrderDate;
        //    public DateTime OrderDate
        //    {
        //        get { return _OrderDate; }
        //        set { SetPropertyValue("OrderDate", ref _OrderDate, value); }
        //    }

        //    decimal _PaidTotal;
        //    public decimal PaidTotal
        //    {
        //        get { return _PaidTotal; }
        //        set { SetPropertyValue("PaidTotal", ref _PaidTotal, value); }
        //    }

        //    private Customer _Customer;

        //    [Association("Customer-Orders")]
        //    public Customer Customer
        //    {
        //        get
        //        {
        //            return _Customer;
        //        }
        //        set
        //        {
        //            SetPropertyValue("Customer", ref _Customer, value);
        //        }
        //    }
        //}

}
