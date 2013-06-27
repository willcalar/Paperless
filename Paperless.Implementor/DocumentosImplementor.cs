using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.Library;
using Paperless.DataAccess;
using System.Data.SqlClient;
using System.Data;
using LogManager.Implementor;

namespace Paperless.Implementor
{
    public class DocumentosImplementor
    {

        #region Métodos

        /// <summary>
        /// Obtiene los documentos para la pantalla de Auditoía de Documentos
        /// </summary>
        /// <param name="pUsuarioEmisor">Parámetro de búsqueda</param>
        /// <param name="pUsuarioReceptor">Parámetro de búsqueda</param>
        /// <param name="pDepartamento">Parámetro de búsqueda</param>
        /// <param name="pTipoDocumento">Parámetro de búsqueda</param>
        /// <param name="pFechaEmision">Parámetro de búsqueda</param>
        /// <param name="pFechaRecepcion">Parámetro de búsqueda</param>
        /// <returns>Arreglo de Documentos que cumple con los parametros de la búsqueda</returns>
        public Documento[] ObtenerDocumentosAuditoria(string pUsuarioEmisor, string pUsuarioReceptor, string pDepartamento, string pTipoDocumento, DateTime pFechaEmision, DateTime pFechaRecepcion)
        {
            if (pUsuarioEmisor == null) pUsuarioEmisor = "null";
            if (pUsuarioReceptor == null) pUsuarioReceptor = "null";
            if (pDepartamento.Equals(CUALQUIERA)) pDepartamento = "null";
            if (pTipoDocumento.Equals(CUALQUIERA)) pTipoDocumento = "null";
            if (pFechaEmision.Equals(DateTime.MinValue)) pFechaEmision = DateTime.Now;
            if (pFechaRecepcion.Equals(DateTime.MinValue)) pFechaRecepcion = DateTime.Now;

            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDocumentosAuditoria", new List<SqlParameter>()
            {
                new SqlParameter("usuarioEmisor", pUsuarioEmisor),
                new SqlParameter("usuarioReceptor", pUsuarioReceptor),
                new SqlParameter("departamento", pDepartamento),
                new SqlParameter("tipoDocumento", pTipoDocumento),
                new SqlParameter("fechaEmision", pFechaEmision),
                new SqlParameter("fechaRecepcion", pFechaRecepcion)
            });

            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    documentos.Add(new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()), fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), ""));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_AUDITORIA);   
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_AUDITORIA);
            return null;

        }

        /// <summary>
        /// Obtiene documentos para auditoria
        /// </summary>
        /// <returns>Lista de todos los documentos ingresados en el sistema</returns>
        public Documento[] ObtenerDocumentosAuditoria()
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerTodosDocumentosAuditoria", new List<SqlParameter>());
            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    documentos.Add(new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()), fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), ""));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_AUDITORIA_2);  
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_AUDITORIA);
            return null;
        }

        /// <summary>
        /// Obtiene la lista de movimientos asociados a un documento
        /// </summary>
        /// <param name="pNombreDocumento">nombre del documento a consultar</param>
        /// <returns>Lista de movimientos asociados al documento solicitado</returns>
        public DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string pNombreDocumento)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDetalleDocumentoAuditoria", new List<SqlParameter>()
            {
                new SqlParameter("nombreDocumento", pNombreDocumento)
            });

            if (result != null)
            {
                var movimientos = new List<DocumentoDetalleMovimiento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    movimientos.Add(new DocumentoDetalleMovimiento(fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), fila["TipoEntrada"].ToString(), fila["Ruta"].ToString()));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_MOVIMIENTOS_DOCUMENTO, pNombreDocumento);
                return movimientos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_MOVIMIENTOS_DOCUMENTO, pNombreDocumento);
            return null;

        }

        /// <summary>
        /// Obtiene documentos por migrar del sistema
        /// </summary>
        /// <returns>Lista de documentos que deberían migrarse</returns>
        public Documento[] ObtenerDocumentosPorMigrar()
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDocumentosMigracion", new List<SqlParameter>());
            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    documentos.Add(new Documento((int)fila["ID"], fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()), fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), ""));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_POR_MIGRAR);  
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_POR_MIGRAR);
            return null;
        }

        /// <summary>
        /// Actualiza el estado de un documento que fue migrado en el sistema
        /// </summary>
        /// <param name="pIdDocumento">id del documento</param>
        /// <returns>Verdadero si actulizo con exito o Falso de lo contrario</returns>
        public bool ActualizarEstadoDocumento(int pIdDocumento)
        {
            var result = _AccesoDB.EjecutarNonQuery("PLSSP_ActualizarEstadoDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", pIdDocumento)
            });

            if (result != null)
            {
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.ACTUALIZAR_ESTADO_DOCUMENTO, pIdDocumento);
                return true;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_ACTUALIZAR_ESTADO_DOCUMENTO, pIdDocumento);
            return false;
        }

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuario(string pUsuario)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDocumentosDeUsuario", new List<SqlParameter>()
            {
                new SqlParameter("usuario", pUsuario)
            });

            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    documentos.Add(new Documento((int)fila["IdDocumento"], fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), (int)fila["EstadoFirmas"], (bool)fila["Leido"]));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_DE_USUARIO, pUsuario);
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_DE_USUARIO, pUsuario);
            return null;
        }

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public int ObtenerNumeroPaginasDocumentosUsuario(string pUsuario)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerNumeroPaginasDocumentosUsuario", new List<SqlParameter>()
            {
                new SqlParameter("usuario", pUsuario)
            });

            if (result != null)
            {
                int numPaginas = (int)result.Tables[0].Rows[0].ItemArray[0];
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_DE_USUARIO, pUsuario);
                return numPaginas;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_DE_USUARIO, pUsuario);
            return 0;
        }

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuarioPorPagina(string pUsuario, int pNumPagina)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDocumentosDeUsuarioPorPagina", new List<SqlParameter>()
            {
                new SqlParameter("usuario", pUsuario),
                new SqlParameter("numPag", pNumPagina)
            });

            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    documentos.Add(new Documento((int)fila["IdDocumento"], fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), (int)fila["EstadoFirmas"], (bool)fila["Leido"]));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_DE_USUARIO, pUsuario);
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_DE_USUARIO, pUsuario);
            return null;
        }

        /// <summary>
        /// Obtiene el detalle del estado del documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Lista de estados del documento para los diferentes receptores del mismo</returns>
        public DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int pIdDocumento)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDetalleDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", pIdDocumento)
            });

            if (result != null)
            {
                var detalles= new List<DocumentoDetalleRecibo>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    detalles.Add(new DocumentoDetalleRecibo(DateTime.Parse(fila["Fecha"].ToString()), fila["Documento"].ToString(), fila["Emisor"].ToString(), fila["Receptor"].ToString(), (int)fila["EstadoFirmas"]));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DETALLE_DOCUMENTO, pIdDocumento);
                return detalles.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DETALLE_DOCUMENTO, pIdDocumento);
            return null;
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public Documento ObtenerDocumento(int pIdDocumento)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_ObtenerDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", pIdDocumento)
            });

            if (result != null)
            {
                DataRow fila = result.Tables[0].Rows[0];
                var documento = new Documento(fila["Documento"].ToString(), fila["Formato"].ToString(), (byte[]) fila["Archivo"]);
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTO, pIdDocumento);
                return documento;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTO, pIdDocumento);
            return null;
        }

        /// <summary>
        /// Marca como leido por un usuario un documento
        /// </summary>
        /// <param name="pIdDocumento">id del documento</param>
        /// <param name="pNombreUsuario">username del usuario</param>
        public void MarcarLeido(int pIdDocumento, string pNombreUsuario)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_MarcarLeido", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", pIdDocumento),
                new SqlParameter("nombreUsuario", pNombreUsuario)

            });
        }

        /// <summary>
        /// Marca como firmado por un usuario un documento
        /// </summary>
        /// <param name="pIdDocumento">id del documento</param>
        /// <param name="pNombreUsuario">username del usuario</param>
        /// <param name="pPassword">password del usuario</param>
        public bool FirmarDocumento(int pIdDocumento, string pNombreUsuario, string pPassword)
        {
            var result = _AccesoDB.EjecutarQuery("PLSSP_FirmarDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", pIdDocumento),
                new SqlParameter("nombreUsuario", pNombreUsuario),
                new SqlParameter("password", pPassword)

            });
            if (result != null)
            {
                DataRow fila = result.Tables[0].Rows[0];
                var resultado = int.Parse(fila["Resultado"].ToString());
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.FIRMAR_DOCUMENTO, pIdDocumento);
                if (resultado == 1)
                    return true;
                else
                    return false;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_FIRMAR_DOCUMENTO, pIdDocumento);
            return false;
        }

        /// <summary>
        /// Envia un documento
        /// </summary>
        /// <param name="pLstDestinatarios"> Lista de destinatarios que recibirán el documento</param>
        /// <param name="pDocumento">Objeto que representa el documento que se enviará</param>
        /// <returns>El id del documento enviado o un -1 en caso de error</returns>
        public int EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
        {
            DataSet result = _AccesoDB.EjecutarQuery("PLSSP_InsertarDocumento", new List<SqlParameter> (){
                new SqlParameter("@nombre", pDocumento.NombreDocumento),
                new SqlParameter("@archivo", pDocumento.Archivo),
                new SqlParameter("@fechaingreso", pDocumento.Fecha),
                new SqlParameter("@estadoDocumento", 1),
                new SqlParameter("@tipoDocumento", 1),
                new SqlParameter("@formatoDocumento", 1),
                new SqlParameter("@activo", true),
            });
            bool resul;
            if(result != null){
                int idDocumento = Convert.ToInt32(result.Tables[0].Rows[0][0].ToString());
                resul = InsertarEventoBitacora(pDocumento.NombreUsuarioEmisor, "Envío de documento", idDocumento, 1);
                foreach (Usuario item in pLstDestinatarios)
                {
                    resul = InsertarEventoBitacora(item.Username, "Recepción de Documento", idDocumento, _VALUE_RECEPCION_DOCUMENTO);
                    if (!resul)
                        return -1;
                    resul = InsertarEventoBitacora(item.Username,
                        item.TipoEnvio == Usuario.TipoEnvioEnum.Lectura ? "Lectura de documento requerida" : "Firma de documento requerida", 
                        idDocumento, 
                        (item.TipoEnvio==Usuario.TipoEnvioEnum.Lectura? _VALUE_LECTURA_DOCUMENTO:_VALUE_FIRMA_DOCUMENTO));
                }
                return idDocumento;
            }else
	        {
                return -1;
	        }
        }

        /// <summary>
        /// Inserta eventos en la Bitácora
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pIdDocumento"></param>
        /// <param name="TipoEntradaBitacora"></param>
        /// <returns></returns>
        private bool InsertarEventoBitacora(string pUsername, string pDescripcion ,int pIdDocumento, int pTipoEntradaBitacora)
        {
           return _AccesoDB.EjecutarNonQuery("PLSSP_InsertarBitacoraDocumento", new List<SqlParameter>()
                    {
                        new SqlParameter("@fecha", DateTime.Now),
                        new SqlParameter("@descripcion", pDescripcion),
                        new SqlParameter("@usuario", pUsername),
                        new SqlParameter("@documento", pIdDocumento),
                        new SqlParameter("@tipoEntrada", pTipoEntradaBitacora),
                        new SqlParameter("@referenceID1", "0"),
                        new SqlParameter("@referenceID2", "0")
                    });
        }

        #endregion

        #region Singleton
        private DocumentosImplementor() { }

        public static DocumentosImplementor Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new DocumentosImplementor();
                        instance._AccesoDB = new DataAccess.DataAccess();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Atributos
        private static volatile DocumentosImplementor instance;
        private static object syncRoot = new Object();
        private DataAccess.DataAccess _AccesoDB;
        #endregion

        #region Constantes
        public const string CUALQUIERA = "Cualquiera";
        private const int _VALUE_RECEPCION_DOCUMENTO = 2;
        private const int _VALUE_FIRMA_DOCUMENTO = 9;
        private const int _VALUE_LECTURA_DOCUMENTO = 8;
        #endregion
    }
}
