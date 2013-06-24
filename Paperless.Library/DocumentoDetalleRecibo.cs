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
        /// Constructor de la clase
        /// </summary>
        /// <param name="pFecha">Fecha de creación del documento</param>
        /// <param name="pNombreDocumento">Nombre del documento</param>
        /// <param name="pEmisor">Nombre de usuario del emisor</param>
        /// <param name="pReceptor">Nombre de usuario del receptor</param>
        /// <param name="pEstadoFirmas">Estado de las firmas del documento</param>
        public DocumentoDetalleRecibo(DateTime pFecha, string pNombreDocumento, string pEmisor, string pReceptor, int pEstadoFirmas)
        {
            _Fecha = pFecha;
            _NombreDocumento = pNombreDocumento;
            _Emisor = pEmisor;
            _Receptor = pReceptor;
            _EstadoFirmas = pEstadoFirmas;
        }

        #endregion
    }
}
