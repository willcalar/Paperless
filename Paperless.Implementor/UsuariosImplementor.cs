using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.Library;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Paperless.DataAccess;

namespace Paperless.Implementor
{
    public class UsuariosImplementor
    {

        #region Methods
        public String LogInUsuario(string pNombreUsuario, string pPassword)
        {
            DataSet dsResul = _AccesoDatos.ExecuteQuery("PLSSP_LoginUsuario", new List<SqlParameter>()
            {
                new SqlParameter("@nombreUsuario",pNombreUsuario),
                new SqlParameter("@password",pPassword)
            });
            try
            {
                if (dsResul.Tables[0].Rows.Count == 1)
                {
                    return dsResul.Tables[0].Rows[0]["NombreCompleto"].ToString();
                }
                return String.Empty;
            }
            catch (Exception)
            {
                //Exception logger!
                return null;
            }
        }

        public Usuario[] ObtenerUsuario(string pNombreUsuario)
        {
            DataSet dsResul = _AccesoDatos.ExecuteQuery("PLSSP_ObtenerUsuario", new List<SqlParameter>()
            {
                new SqlParameter("@criterioBusqueda",pNombreUsuario)
            });
            try
            {
                List<Usuario> lstUsuario = new List<Usuario>();
                foreach (DataRow item in dsResul.Tables[0].Rows)
                {
                    lstUsuario.Add(new Usuario()
                    {
                        NombreUsuario = item["Nombre"].ToString(),
                        PrimerApellido = item["Apellido1"].ToString(),
                        SegundoApellido = item["Apellido2"].ToString(),
                        Username = item["Username"].ToString()
                    });                    
                }
                return lstUsuario.ToArray();
            }
            catch (Exception)
            {
                //Exception logger!
                return null;
            }
        }

        public Usuario[] ObtenerTodosUsuarios()
        {
            DataSet dsResul = _AccesoDatos.ExecuteQuery("PLSSP_ObtenerUsuarioAll", new List<SqlParameter>());
            try
            {
                List<Usuario> lstUsuario = new List<Usuario>();
                foreach (DataRow item in dsResul.Tables[0].Rows)
                {
                    lstUsuario.Add(new Usuario()
                    {
                        NombreUsuario = item["Nombre"].ToString(),
                        PrimerApellido = item["Apellido1"].ToString(),
                        SegundoApellido = item["Apellido2"].ToString(),
                        Username = item["Username"].ToString()
                    });
                }
                return lstUsuario.ToArray();
            }
            catch (Exception)
            {
                //Exception logger!
                return null;
            }
        }

        public Historial[] ObtenerHistorialUsuario(string pNombreUsuario)
        {
            DataSet dsResul = _AccesoDatos.ExecuteQuery("PLSSP_ObtenerHistorialEventos", new List<SqlParameter>()
            {
                new SqlParameter("@criterioBusqueda",pNombreUsuario),
                new SqlParameter("@fechaInicio", new DateTime(1999,1,1)),
                new SqlParameter("@fechaFin", DateTime.Now)
            });
            try
            {
                List<Historial> lstHistorial = new List<Historial>();
                foreach (DataRow item in dsResul.Tables[0].Rows)
                {
                    lstHistorial.Add(new Historial()
                    {
                        Evento = item["Evento"].ToString(),
                        TipoEvento = item["TipoEvento"].ToString(),
                        Username = item["Username"].ToString(),
                        Fecha = Convert.ToDateTime(item["Fecha"].ToString())
                    });                    
                }
                return lstHistorial.ToArray();
            }
            catch (Exception)
            {
                //Exception logger!
                return null;
            }
        }



        public DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string nombreUsuario)
        {

            var result = _AccesoDatos.ExecuteQuery("PLSSP_ObtenerDetalleUsuarioAuditoria", new List<SqlParameter>()
            {
                new SqlParameter("nombreUsuario", nombreUsuario)
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
                    "Se obtuvo el detalle de los movimientos del usuario " + nombreUsuario);
                return movimientos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, "Documentos", "No se obtuvo el detalle de los movimientos del usuario " + nombreUsuario);
            return null;

        }

        #endregion

        #region Singleton
        private UsuariosImplementor()
        {
            _AccesoDatos = new DataAccess.DataAccess();
        }
        
        public static UsuariosImplementor Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new UsuariosImplementor();
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
        private static volatile UsuariosImplementor instance;
        private static object syncRoot = new Object();
        private static DataAccess.DataAccess _AccesoDatos;
        #endregion

    }
}
