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
                {
                    var documento = new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()),
                        fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), "");

                    documentos.Add(documento);
                }
                LogManager.Implementor.LogManager.LogActivity(0, 1, "Documentos", 
                    "Se obtuvo documentos para auditoría del usuario emisor:"+usuarioEmisor+
                    ", usuario receptor: "+ usuarioReceptor);    
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos", "No se obtuvieron documentos para auditoría");
            return null;

        }

        public Documento[] ObtenerDocumentosAuditoria()
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerTodosDocumentosAuditoria", new List<SqlParameter>());
            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    var documento = new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()),
                        fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), "");

                    documentos.Add(documento);
                }
                LogManager.Implementor.LogManager.LogActivity(0, 1, "Documentos Auditoría",
                    "Se obtuvo todos los documentos para auditoría");  
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos Auditoría", "No se obtuvieron documentos para auditoría");
            return null;
        }

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
                {
                    var documento = new DocumentoDetalleMovimiento(fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()),
                        fila["Usuario"].ToString(), fila["TipoEntrada"].ToString(), fila["Ruta"].ToString());

                    movimientos.Add(documento);
                }
                LogManager.Implementor.LogManager.LogActivity(0, 1, "Documentos",
                    "Se obtuvo el detalle de los movimientos del documento " + nombreDocumento);
                return movimientos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos", "No se obtuvo el detalle de los movimientos del documento " + nombreDocumento);
            return null;

        }

        public Documento[] ObtenerDocumentosPorMigrar()
        {
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDocumentosMigracion", new List<SqlParameter>());
            if (result != null)
            {
                var documentos = new List<Documento>();
                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    var documento = new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()),
                        fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), "");
                    documentos.Add(documento);
                }
                LogManager.Implementor.LogManager.LogActivity(0, 1, "Documentos Auditoría",
                    "Se obtuvo todos los documentos para auditoría");  
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos Auditoría", "No se obtuvieron documentos para auditoría");
            return null;
        }

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
                {
                    var documento = new Documento((int)fila["IdDocumento"], fila["Documento"].ToString(),
                        DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), (bool)fila["Firmado"], (bool)fila["Leido"]);

                    documentos.Add(documento);
                }
                LogManager.Implementor.LogManager.LogActivity(0, 1, "Documentos",
                    "Se realizó la recepción de documentos documentos para el usuario: " + usuario);
                return documentos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos", "No se obtuvieron documentos para el usuario:" + usuario);
            return null;
        }

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
                LogManager.Implementor.LogManager.LogActivity(0, 1, "Documentos",
                    "Se realizó la descarga del documento con id: " + idDocumento);
                return documento;
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos", "No se pudo obtener el contenido del documento con id:" + idDocumento);
            return null;
        }

        public bool EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
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
                        return false;
                }
                return true;
            }else
	        {
                return false;
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
