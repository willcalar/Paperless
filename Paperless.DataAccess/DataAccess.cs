using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using Exceptions;

namespace Paperless.DataAccess
{
    public class DataAccess
    {
        #region Constructor
        public DataAccess()
        {
            var conexionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _Conexion = new SqlConnection(conexionString);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Abre la conexión con la Base de Datos
        /// </summary>
        private void AbrirConexion()
        {
            try
            {
                _Conexion.Open();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, ex.GetType(),
                    (int)ErrorCode.ERROR_ESTABLISHING_CONNECTION_LINQ, ExceptionMessages.Instance[ErrorCode.ERROR_ESTABLISHING_CONNECTION_LINQ], false);
            }
        }

        /// <summary>
        /// Crea el comando a ser ejecutado
        /// </summary>
        /// <param name="pNombreProcedimiento">Nombre del SP</param>
        /// <param name="pParametros">Parametros el SP</param>
        /// <returns>Objeto de tipo SQLCommand que representa el SP</returns>
        private SqlCommand CrearComando(string pNombreProcedimiento, IEnumerable<SqlParameter> pParametros)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = pNombreProcedimiento;
            command.Connection = _Conexion;

            if (pParametros != null)
            {
                foreach (var parameter in pParametros)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// Ejecuta un SP que retorna datos
        /// </summary>
        /// <param name="pNombreProcedimiento">Nombre del SP</param>
        /// <param name="pParametros">Parametros el SP</param>
        /// <returns>Un DataSet con los datos que retornó el SP</returns>
        public DataSet EjecutarQuery(string pNombreProcedimiento, IEnumerable<SqlParameter> pParametros = null)
        {
            var dataset = new DataSet();
            AbrirConexion();
            try
            {

                var command = CrearComando(pNombreProcedimiento, pParametros);
                var adapter = new SqlDataAdapter(command);
                var commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Fill(dataset);

                command.Dispose();

                _Conexion.Close();
            }
            catch (Exception ex)
            {
                dataset = null;
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, ex.GetType(),
                    (int)ErrorCode.ERROR_EXECUTING_SP, String.Format(ExceptionMessages.Instance[ErrorCode.ERROR_EXECUTING_SP], pNombreProcedimiento), false);
                
            }
            finally
            {
                if (_Conexion.State == ConnectionState.Open)
                {
                    _Conexion.Close();
                }
            }
            return dataset;
        }

        /// <summary>
        /// Ejecuta un SP que no retorna datos
        /// </summary>
        /// <param name="pNombreProcedimiento">Nombre del SP</param>
        /// <param name="pParametros">Parametros el SP</param>
        /// <returns></returns>
        public bool EjecutarNonQuery(string pNombreProcedimiento, IEnumerable<SqlParameter> pParametros = null)
        {
            int result;
            AbrirConexion();
            try
            {

                var command = CrearComando(pNombreProcedimiento, pParametros);
                result = command.ExecuteNonQuery();
                _Conexion.Close();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, ex.GetType(),
                    (int)ErrorCode.ERROR_EXECUTING_SP, String.Format(ExceptionMessages.Instance[ErrorCode.ERROR_EXECUTING_SP], pNombreProcedimiento), false);
                return false;
            }
            finally
            {
                if (_Conexion.State == ConnectionState.Open)
                {
                    _Conexion.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Prueba la conexión con la BD
        /// </summary>
        /// <returns>Booleano que representa el resultado de la prueba</returns>
        public bool ProbarConexion()
        {
            try
            {
                _Conexion.Open();
                _Conexion.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Atributos

        private SqlConnection _Conexion;

        #endregion
     
       
      
    }
}
