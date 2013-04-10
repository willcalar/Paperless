using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Paperless.Library
{
    [DataContract]
    public class Evento
    {
        #region Atributos
        private string _TipoEvento;
        private string _Descripcion;
        private DateTime _FechaHora;
        private string _NombreUsuario;
        private string _NombreDocumento;
        
        
        #endregion

        #region Propiedades
        [DataMember]
        public string TipoEvento
        {
            get { return _TipoEvento; }
            set { _TipoEvento = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        [DataMember]
        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set { _FechaHora = value; }
        }

        [DataMember]
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        [DataMember]
        public string NombreDocumento
        {
            get { return _NombreDocumento; }
            set { _NombreDocumento = value; }
        }

        [DataMember]
        public string _Revisado { get; set; }

        [DataMember]
        public string Origen { get; set; }

        [DataMember]
        public int IDReferencia { get; set; }
        #endregion    

        #region Constructores
        /// <summary>
        /// Constructor vacío de la clase
        /// </summary>
        public Evento()
        {
        }

        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="tipoEvento">Tipo de evento</param>
        /// <param name="descripcion">Descripción del evento</param>
        /// <param name="fechaHora">Fecha y hora del evento</param>
        /// <param name="nombreUsuario">Nombre del usuario involucrado</param>
        /// <param name="nombreDocumento">Nombre del documento involucrado</param>
        public Evento(string tipoEvento, string descripcion, DateTime fechaHora, string nombreUsuario, string nombreDocumento)
        {
            _TipoEvento = tipoEvento;
            _Descripcion = descripcion;
            _FechaHora = fechaHora;
            _NombreUsuario = nombreUsuario;
            _NombreDocumento = nombreDocumento;
        }
        #endregion
    }
}
