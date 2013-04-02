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

        private SqlCommand CreateCommand(string pProcedureName, IEnumerable<SqlParameter> pParameters, bool pAddOutput)
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

        public DataSet ExecuteQuery(string pProcedureName, IEnumerable<SqlParameter> pParameters = null)
        {
            var dataset = new DataSet();
            try
            {
                _Connection.Open();

                var command = CreateCommand(pProcedureName, pParameters, true);
                var adapter = new SqlDataAdapter(command);
                var commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Fill(dataset);

                command.Dispose();

                _Connection.Close();
            }
            catch (Exception ex)
            {
                dataset = null;
                ExceptionManager.HandleException(ex,Policy.DATA_ACCESS, ex.GetType(),
                    (int) ErrorCode.ERROR_EXECUTING_SP, String.Format(ERROR_EXECUTING_SP,pProcedureName));

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

        public bool ExecuteNonQuery(string pProcedureName, IEnumerable<SqlParameter> pParameters = null)
        {
            int result;
            try
            {
                _Connection.Open();
                var command = CreateCommand(pProcedureName, pParameters, false);
                result = command.ExecuteNonQuery();
                _Connection.Close();
            }
            catch (Exception ex)
            {
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


        
        #region Constants
        /// <summary>
        /// Used to get/set the Error message in Data dictionary
        /// </summary>
        public const string ERROR_EXECUTING_SP = "Error executing the SP: /0.";

        #endregion Constants
      
    }
}
