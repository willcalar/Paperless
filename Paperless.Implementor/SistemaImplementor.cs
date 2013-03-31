using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Paperless.Implementor
{
    public class SistemaImplementor
    {
        #region Methods

        public String[] ObtenerTiposDocumento()
        {

            var tiposDocumento = new List<String>();
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerTiposDocumento", new List<SqlParameter>());

            if (result != null && result.Tables != null && result.Tables[0] != null && result.Tables[0].Rows != null)
            {
                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    var tipoDocumento = fila["Nombre"].ToString();
                    tiposDocumento.Add(tipoDocumento);
                }
            }

            return tiposDocumento.ToArray();
        }
        #endregion

        #region Singleton
        private SistemaImplementor() { }

        public static SistemaImplementor Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new SistemaImplementor();
                        instance._AccesoDB = new DataAccess.DataAccess();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
        private static volatile SistemaImplementor instance;
        private static object syncRoot = new Object();
        private DataAccess.DataAccess _AccesoDB;
        #endregion
    }
}
