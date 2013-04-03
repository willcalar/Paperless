﻿using System;
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
