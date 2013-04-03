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
        /*
        public DataAccess(string pConnectionString)
        {
            _Connection = new SqlConnection(pConnectionString);
        }
         */

        public DataAccess()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _Connection = new SqlConnection(connectionString);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Open the connection with the DB
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                _Connection.Open();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, ex.GetType(),
                    (int)ErrorCode.ERROR_ESTABLISHING_CONNECTION_LINQ, ExceptionMessages.Instance[ErrorCode.ERROR_ESTABLISHING_CONNECTION_LINQ], false);
            }
        }

        /// <summary>
        /// Creates the command to be executed
        /// </summary>
        /// <param name="pProcedureName">Name of the SP</param>
        /// <param name="pParameters">Params of the SP</param>
        /// <returns>Object of type SQLCommand that represents the SP</returns>
        private SqlCommand CreateCommand(string pProcedureName, IEnumerable<SqlParameter> pParameters)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = pProcedureName;
            command.Connection = _Connection;

            if (pParameters != null)
            {
                foreach (var parameter in pParameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// Executes a SP that returns data
        /// </summary>
        /// <param name="pProcedureName">Name of the SP</param>
        /// <param name="pParameters">Params of the SP</param>
        /// <returns>A DataSet with the data returned by the SP</returns>
        public DataSet ExecuteQuery(string pProcedureName, IEnumerable<SqlParameter> pParameters = null)
        {
            var dataset = new DataSet();
            OpenConnection();
            try
            {

                var command = CreateCommand(pProcedureName, pParameters);
                var adapter = new SqlDataAdapter(command);
                var commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Fill(dataset);

                command.Dispose();

                _Connection.Close();
            }
            catch (Exception ex)
            {
                dataset = null;
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, ex.GetType(),
                    (int)ErrorCode.ERROR_EXECUTING_SP, String.Format(ExceptionMessages.Instance[ErrorCode.ERROR_EXECUTING_SP], pProcedureName), false);
                
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return dataset;
        }

        /// <summary>
        /// Executes a SP that doesnt return data
        /// </summary>
        /// <param name="pProcedureName">Name of the SP</param>
        /// <param name="pParameters">Params of the SP</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string pProcedureName, IEnumerable<SqlParameter> pParameters = null)
        {
            int result;
            OpenConnection();
            try
            {
                
                var command = CreateCommand(pProcedureName, pParameters);
                result = command.ExecuteNonQuery();
                _Connection.Close();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, ex.GetType(),
                    (int)ErrorCode.ERROR_EXECUTING_SP, String.Format(ExceptionMessages.Instance[ErrorCode.ERROR_EXECUTING_SP] , pProcedureName),false);
                return false;
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Try the connection with the DB
        /// </summary>
        /// <returns>Bool that represents the state of the connection</returns>
        public bool TryConnection()
        {
            try
            {
                _Connection.Open();
                _Connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Atributos

        private SqlConnection _Connection;

        #endregion
     
       
      
    }
}
