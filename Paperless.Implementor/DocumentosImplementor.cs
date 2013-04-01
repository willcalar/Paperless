using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.Library;
using Paperless.DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace Paperless.Implementor
{
    public class DocumentosImplementor
    {

        #region Methods

        public Documento[] ObtenerDocumentos(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, DateTime fechaEmision, DateTime fechaRecepcion)
        {
            
            var documentos = new List<Documento>();
            if (usuarioEmisor == null) usuarioEmisor = "null";
            if (usuarioReceptor == null) usuarioReceptor = "null";
            if (departamento.Equals("Cualquiera")) departamento = "null";
            if (tipoDocumento.Equals("Cualquiera")) departamento = "null";
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

            if (result != null && result.Tables != null && result.Tables[0] != null && result.Tables[0].Rows != null)
            {
                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    var documento = new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()),
                        fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), "");

                    documentos.Add(documento);
                }
            }

            return documentos.ToArray();
        }


        public Documento[] ObtenerDocumentosPorMigrar()
        {

            var documentos = new List<Documento>();

            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDocumentosMigracion", new List<SqlParameter>());

            if (result != null && result.Tables != null && result.Tables[0] != null && result.Tables[0].Rows != null)
            {
                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    var documento = new Documento(fila["Documento"].ToString(), DateTime.Parse(fila["FechaIngreso"].ToString()),
                        fila["TipoDocumento"].ToString(), fila["Usuario"].ToString(), "");
                    documentos.Add(documento);
                }
            }

            return documentos.ToArray();
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
    }
}
