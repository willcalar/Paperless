using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.DataAccess;
using Paperless.Library;
using System.Data.SqlClient;
using System.Data;

namespace Paperless.Implementor
{
    public class EventosImplementor
    {
        
        #region Methods

        /// <summary>
        /// Obtiene la lista de eventos irregulares presentados en el sistema
        /// </summary>
        /// <returns>Lista de eventos irregulares presentados en el sistema</returns>
        public Evento[] ObtenerEventosIrregulares()
        {
            DataSet dsResul = _AccesoDB.ExecuteQuery("PLSSP_ObtenerEventosIrregulares", new List<SqlParameter>());
            if (dsResul != null)
            {
                List<Evento> lstEvento = new List<Evento>();
                foreach (DataRow item in dsResul.Tables[0].Rows)
                {
                    Evento evento = new Evento((String)item["TipoEvento"], (String)item["Evento"], (DateTime)item["Fecha"], (String)item["Usuario"], (String)item["Documento"]);
                    evento.Origen = "Documento";
                    evento.IDReferencia = 1;
                    lstEvento.Add(evento);
                }
                return lstEvento.ToArray();
            }
            return null;
        }

        #endregion

        #region Singleton
        private EventosImplementor() { }

        public static EventosImplementor Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new EventosImplementor();
                        instance._AccesoDB = new DataAccess.DataAccess();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
        private static volatile EventosImplementor instance;
        private static object syncRoot = new Object();
        private DataAccess.DataAccess _AccesoDB;
        #endregion
    }
}
