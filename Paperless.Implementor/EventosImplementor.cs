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

        public Evento[] ObtenerEventosIrregulares()
        {
            DataSet dsResul = _AccesoDB.ExecuteQuery("PLSSP_ObtenerEventosIrregulares", new List<SqlParameter>());
            if (dsResul != null)
            {
                List<Evento> lstEvento = new List<Evento>();
                foreach (DataRow item in dsResul.Tables[0].Rows)
                {
                    Evento evento = new Evento();
                    evento.TipoEvento = (String)item["TipoEvento"];
                    evento.Descripcion = (String)item["Evento"];
                    evento.FechaHora = (DateTime)item["Fecha"];
                    evento.NombreUsuario = (String)item["Usuario"];
                    evento.NombreDocumento = (String)item["Documento"];
                    evento.Origen = "Documento";
                    evento.IDReferencia = 1;
                    lstEvento.Add(evento);
                }
                return lstEvento.ToArray();
            }
            return null;
            
        }



        public Evento[] ObtenerEventos()
        {
            DataSet dsResul = _AccesoDB.ExecuteQuery("PLSSP_ObtenerBitacoraDocumentos", new List<SqlParameter>()
            {
                new SqlParameter("@criterioBusqueda",""),
                new SqlParameter("@fechaInicio", new DateTime(1999,1,1)),
                new SqlParameter("@fechaFin", DateTime.Now)
            });
            try
            {
                List<Evento> lstEvento = new List<Evento>();
                foreach (DataRow item in dsResul.Tables[0].Rows)
                {
                    lstEvento.Add(new Evento()
                    {
                        TipoEvento = item["TipoEntrada"].ToString(),
                        Descripcion = item["Entrada"].ToString(),
                        NombreDocumento = item["Documento"].ToString(),
                        NombreUsuario = item["Usuario"].ToString()
                    });                    
                }
                return lstEvento.ToArray();
            }
            catch (Exception)
            {
                //Exception logger!
                return null;
            }
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
