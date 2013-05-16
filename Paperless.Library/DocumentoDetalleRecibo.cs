using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Paperless.Library
{
    [DataContract]
    public class DocumentoDetalleRecibo
    {
        #region Atributos
        private DateTime _Fecha;
        private string _NombreDocumento;
        private string _Emisor;
        private string _Receptor;
        private int _EstadoFirmas;
        #endregion

        #region Propiedades
        [DataMember]
        public string NombreDocumento
        {
            get { return _NombreDocumento; }
            set { _NombreDocumento = value; }
        }

        [DataMember]
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        

        [DataMember]
        public string Emisor
        {
            get { return _Emisor; }
            set { _Emisor = value; }
        }

        [DataMember]
        public string Receptor
        {
            get { return _Receptor; }
            set { _Receptor = value; }
        }

        [DataMember]
        public int EstadoFirmas
        {
            get { return _EstadoFirmas; }
            set { _EstadoFirmas = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public DocumentoDetalleRecibo()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="nombreDocumento"></param>
        /// <param name="emisor"></param>
        /// <param name="receptor"></param>
        /// <param name="estadoFirmas"></param>
        public DocumentoDetalleRecibo(DateTime fecha, string nombreDocumento, string emisor, string receptor, int estadoFirmas)
        {
            _Fecha = fecha;
            _NombreDocumento = nombreDocumento;
            _Emisor = emisor;
            _Receptor = receptor;
            _EstadoFirmas = estadoFirmas;
        }

        #endregion
    }
}
