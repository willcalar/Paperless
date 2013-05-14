using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.Library;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Paperless.DataAccess;
using LogManager.Implementor;

namespace Paperless.Implementor
{
    public class UsuariosImplementor
    {

        #region Methods
        /// <summary>
        /// Verifica el nombre de Usuario y contraseña de un usuario, permitiendo loguearse en el sistema 
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de Usuario</param>
        /// <param name="pPassword">Contraseña</param>
        /// <returns>Nombre del Funcionario logueado</returns>
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

        /// <summary>
        /// Obtiene el usuario asociado al nombre de usuario indicado
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de Usuario</param>
        /// <returns>Objeto de tipo Usuario asociado al nombre de usuario indicado</returns>
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

        /// <summary>
        /// Obtiene todos los usuarios registrados en el sistema
        /// </summary>
        /// <returns>Lista de todos los usuarios registrados en el sistema</returns>
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


        /// <summary>
        /// Obtiene el detalle de los movimientos realizados el usuario asociado al nombre de usuario indicado
        /// </summary>
        /// <param name="nombreUsuario">Nombre de Usuario</param>
        /// <returns>Lista de movimientos asociados al usuario consultado</returns>
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
                    movimientos.Add(new DocumentoDetalleMovimiento(fila["Documento"].ToString(), DateTime.Parse(fila["Fecha"].ToString()), fila["Usuario"].ToString(), fila["TipoEntrada"].ToString(), fila["Ruta"].ToString()));

                LogManager.Implementor.LogManager.LogActivity(0, 1, TipoLog.USUARIOS, MensajesLog.OBTENER_MOVIMIENTOS_USUARIO, nombreUsuario);
                return movimientos.ToArray();
            }
            LogManager.Implementor.LogManager.LogActivity(1, 1, TipoLog.USUARIOS, MensajesLog.ERROR_OBTENER_MOVIMIENTOS_USUARIO, nombreUsuario);
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
