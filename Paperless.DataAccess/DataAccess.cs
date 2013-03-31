using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Paperless.DataAccess
{
    public class DataAccess
    {
        #region Constructor

        public DataAccess(string pConnectionString)
        {
            _Conexion = new SqlConnection(pConnectionString);
        }

        #endregion

        #region Metodos

        private SqlCommand CreateCommand(string pProcedureName, IEnumerable<SqlParameter> pParametros)
        {
            var comando = new SqlCommand(pProcedureName, _Conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            foreach (var parametro in pParametros)
            {
                comando.Parameters.Add(parametro);
            }
            return comando;
        }

        public DataSet ExecuteQuery(string pProcedureName, IEnumerable<SqlParameter> pParametros)
        {
            var dataSet = new DataSet();
            try
            {
                var adapter = new SqlDataAdapter(CreateCommand(pProcedureName, pParametros));
                _Conexion.Open();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                //ExceptionLogger.LogExcepcion(ex, "Error consulta ejecutando: " + pProcedureName);
                dataSet = null;
            }
            finally
            {
                if (_Conexion != null && _Conexion.State == ConnectionState.Open)
                {
                    _Conexion.Close();
                }
            }
            return dataSet;
        }

        public bool ExecuteNonQuery(string pProcedureName, IEnumerable<SqlParameter> pParametros)
        {
            try
            {
                var comando = CreateCommand(pProcedureName, pParametros);
                _Conexion.Open();
                int resultado = comando.ExecuteNonQuery();
                _Conexion.Close();
                return resultado == -1;
            }
            catch (Exception ex)
            {
                //ExceptionLogger.LogExcepcion(ex, "Error no consulta ejecutando: " + pProcedureName);
                return false;
            }
            finally
            {
                if (_Conexion != null && _Conexion.State == ConnectionState.Open)
                {
                    _Conexion.Close();
                }
            }
        }

        #endregion

        #region Atributos

        private SqlConnection _Conexion;

        #endregion
    }
}
