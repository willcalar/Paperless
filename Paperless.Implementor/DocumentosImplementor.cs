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

        #region Methods

        /// <summary>
        /// Obtiene los documentos para la pantalla de Auditoía de Documentos
        /// </summary>
        /// <param name="usuarioEmisor">Parámetro de búsqueda</param>
        /// <param name="usuarioReceptor">Parámetro de búsqueda</param>
        /// <param name="departamento">Parámetro de búsqueda</param>
        /// <param name="tipoDocumento">Parámetro de búsqueda</param>
        /// <param name="fechaEmision">Parámetro de búsqueda</param>
        /// <param name="fechaRecepcion">Parámetro de búsqueda</param>
        /// <returns>Arreglo de Documentos que cumple con los parametros de la búsqueda</returns>
        public Documento[] ObtenerDocumentosAuditoria(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, DateTime fechaEmision, DateTime fechaRecepcion)
        {
            if (usuarioEmisor == null) usuarioEmisor = "null";
            if (usuarioReceptor == null) usuarioReceptor = "null";
            if (departamento.Equals(CUALQUIERA)) departamento = "null";
            if (tipoDocumento.Equals(CUALQUIERA)) departamento = "null";
            if (fechaEmision.Equals(DateTime.MinValue)) fechaEmision = DateTime.Now;
            if (fechaRecepcion.Equals(DateTime.MinValue)) fechaRecepcion = DateTime.Now;

            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDocumentosAuditoria", new List<SqlParameter>()
            {
                new SqlParameter("usuarioEmisor", usuarioEmisor),
                new SqlParameter("usuarioReceptor", usuarioReceptor),
                new SqlParameter("departamento", departamento),
                new SqlParameter("tipoDocumento", tipoDocumento),
                new SqlParameter("fechaEmision", fechaEmision),
                new SqlParameter("fechaRecepcion", fechaRecepcion)
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
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerTodosDocumentosAuditoria", new List<SqlParameter>());
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
        /// <param name="nombreDocumento">nombre del documento a consultar</param>
        /// <returns>Lista de movimientos asociados al documento solicitado</returns>
        public DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string nombreDocumento)
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDetalleDocumentoAuditoria", new List<SqlParameter>()
            {
                new SqlParameter("nombreDocumento", nombreDocumento)
            });

            if (result != null)
            {
                var movimientos = new List<DocumentoDetalleMovimiento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    movimientos.Add(new DocumentoDetalleMovimiento(fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), fila["TipoEntrada"].ToString(), fila["Ruta"].ToString()));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_MOVIMIENTOS_DOCUMENTO, nombreDocumento);
                return movimientos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_MOVIMIENTOS_DOCUMENTO, nombreDocumento);
            return null;

        }

        /// <summary>
        /// Obtiene documentos por migrar del sistema
        /// </summary>
        /// <returns>Lista de documentos que deberían migrarse</returns>
        public Documento[] ObtenerDocumentosPorMigrar()
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDocumentosMigracion", new List<SqlParameter>());
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
        /// <param name="nombreDocumento">id del documento</param>
        /// <returns>Verdadero si actulizo con exito o Falso de lo contrario</returns>
        public bool ActualizarEstadoDocumento(int idDocumento)
        {
            var result = _AccesoDB.ExecuteNonQuery("PLSSP_ActualizarEstadoDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", idDocumento)
            });

            if (result != null)
            {
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.ACTUALIZAR_ESTADO_DOCUMENTO, idDocumento);
                return true;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_ACTUALIZAR_ESTADO_DOCUMENTO, idDocumento);
            return false;
        }

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuario(string usuario)
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDocumentosDeUsuario", new List<SqlParameter>()
            {
                new SqlParameter("usuario", usuario)
            });

            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    documentos.Add(new Documento((int)fila["IdDocumento"], fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), (int)fila["EstadoFirmas"], (bool)fila["Leido"]));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTOS_DE_USUARIO, usuario);
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTOS_DE_USUARIO, usuario);
            return null;
        }

        /// <summary>
        /// Obtiene el detalle del estado del documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Lista de estados del documento para los diferentes receptores del mismo</returns>
        public DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int idDocumento)
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDetalleDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", idDocumento)
            });

            if (result != null)
            {
                var detalles= new List<DocumentoDetalleRecibo>();
                foreach (DataRow fila in result.Tables[0].Rows)
                    detalles.Add(new DocumentoDetalleRecibo(DateTime.Parse(fila["Fecha"].ToString()), fila["Documento"].ToString(), fila["Emisor"].ToString(), fila["Receptor"].ToString(), (int)fila["EstadoFirmas"]));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DETALLE_DOCUMENTO, idDocumento);
                return detalles.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DETALLE_DOCUMENTO, idDocumento);
            return null;
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public Documento ObtenerDocumento(int idDocumento)
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", idDocumento)
            });

            if (result != null)
            {
                DataRow fila = result.Tables[0].Rows[0];
                var documento = new Documento(fila["Documento"].ToString(), fila["Formato"].ToString(), (byte[]) fila["Archivo"]);
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.OBTENER_DOCUMENTO, idDocumento);
                return documento;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_OBTENER_DOCUMENTO, idDocumento);
            return null;
        }

        /// <summary>
        /// Marca como leido por un usuario un documento
        /// </summary>
        /// <param name="idDocumento">id del documento</param>
        /// <param name="nombreUsuario">username del usuario</param>
        public void MarcarLeido(int idDocumento, string nombreUsuario)
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_MarcarLeido", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", idDocumento),
                new SqlParameter("nombreUsuario", nombreUsuario)

            });
        }

        /// <summary>
        /// Marca como firmado por un usuario un documento
        /// </summary>
        /// <param name="idDocumento">id del documento</param>
        /// <param name="nombreUsuario">username del usuario</param>
        /// <param name="password">password del usuario</param>
        public bool FirmarDocumento(int idDocumento, string nombreUsuario, string password)
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_FirmarDocumento", new List<SqlParameter>()
            {
                new SqlParameter("idDocumento", idDocumento),
                new SqlParameter("nombreUsuario", nombreUsuario),
                new SqlParameter("password", password)

            });
            if (result != null)
            {
                DataRow fila = result.Tables[0].Rows[0];
                var resultado = int.Parse(fila["Resultado"].ToString());
                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.DOCUMENTOS, MensajesLog.FIRMAR_DOCUMENTO, idDocumento);
                if (resultado == 1)
                    return true;
                else
                    return false;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.DOCUMENTOS, MensajesLog.ERROR_FIRMAR_DOCUMENTO, idDocumento);
            return false;
        }

        public int EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
        {
            DataSet result = _AccesoDB.ExecuteQuery("PLSSP_InsertarDocumento", new List<SqlParameter> (){
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
                resul = _AccesoDB.ExecuteNonQuery("PLSSP_InsertarBitacoraDocumento", new List<SqlParameter>()
                    {
                        new SqlParameter("@fecha", DateTime.Now),
                        new SqlParameter("@descripcion", "Envío de documento"),
                        new SqlParameter("@usuario", pDocumento.NombreUsuarioEmisor),
                        new SqlParameter("@documento", idDocumento),
                        new SqlParameter("@tipoEntrada", 1),
                        new SqlParameter("@referenceID1", "0"),
                        new SqlParameter("@referenceID2", "0")
                    });
                foreach (Usuario item in pLstDestinatarios)
                {
                    resul = _AccesoDB.ExecuteNonQuery("PLSSP_InsertarBitacoraDocumento", new List<SqlParameter>()
                    {
                        new SqlParameter("@fecha", DateTime.Now),
                        new SqlParameter("@descripcion", "Recepción de documento"),
                        new SqlParameter("@usuario", item.Username),
                        new SqlParameter("@documento", idDocumento),
                        new SqlParameter("@tipoEntrada", 2),
                        new SqlParameter("@referenceID1", "0"),
                        new SqlParameter("@referenceID2", "0")
                    });
                    if (!resul)
                        return -1;
                }
                return idDocumento;
            }else
	        {
                return -1;
	        }
        }

        private bool RegistrarEventoBitacora(){
            return true;
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

        #region Attributes
        private static volatile DocumentosImplementor instance;
        private static object syncRoot = new Object();
        private DataAccess.DataAccess _AccesoDB;
        #endregion

        #region Constants
        public const string CUALQUIERA = "Cualquiera";
        #endregion
    }
}
