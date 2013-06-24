using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Paperless.Library
{
    [DataContract]
    public class DocumentoDetalleMovimiento
    {
        #region Atributos
        private string _NombreDocumento;
        private DateTime _Fecha;    
        private string _Usuario;
        private string _TipoAccion;
        private string _Ruta;
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
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        

        

        [DataMember]
        public string TipoAccion
        {
            get { return _TipoAccion; }
            set { _TipoAccion = value; }
        }

        [DataMember]
        public string Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }
        
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public DocumentoDetalleMovimiento()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pNombreDocumento">nombre del documento</param>
        /// <param name="pFecha">Fecha del movimiento del documento</param>
        /// <param name="pNombreUsuario">Nombre de usuario</param>
        /// <param name="pTipoAccion"></param>
        /// <param name="pRuta"></param>
        public DocumentoDetalleMovimiento(string pNombreDocumento, DateTime pFecha,  string pNombreUsuario, string pTipoAccion, string pRuta)
        {
            _NombreDocumento = pNombreDocumento;
            _Fecha = pFecha;
            _Usuario = pNombreUsuario;
            _TipoAccion = pTipoAccion;
            _Ruta = pRuta;
           
        }
        #endregion
    }
}
