using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Paperless.Implementor
{
    public class OrganizacionImplementor
    {

        #region Methods

        /// <summary>
        /// Obtiene la lista de departamentos de la organización que utiliza del sistema
        /// </summary>
        /// <returns>Lista de departamentos existentes en la organización</returns>
        public String[] ObtenerDepartamentos()
        {

            var departamentos = new List<String>();
            var result = _AccesoDB.ExecuteQuery("PLSSP_ObtenerDepartamentos", new List<SqlParameter>());

            if (result != null && result.Tables != null && result.Tables[0] != null && result.Tables[0].Rows != null)
            {
                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    var departamento = fila["Nombre"].ToString();
                    departamentos.Add(departamento);
                }
            }

            return departamentos.ToArray();

        }
        #endregion

        #region Singleton
        private OrganizacionImplementor() { }

        public static OrganizacionImplementor Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new OrganizacionImplementor();
                        instance._AccesoDB = new DataAccess.DataAccess();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
        private static volatile OrganizacionImplementor instance;
        private static object syncRoot = new Object();
        private DataAccess.DataAccess _AccesoDB;
        #endregion
    }
}
