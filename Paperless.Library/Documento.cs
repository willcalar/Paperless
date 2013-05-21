using System;
using System.Runtime.Serialization;

namespace Paperless.Library
{
    [DataContract]
    public class Documento
    {
        #region Atributos
        private int _IdDocumento;
        private string _NombreDocumento;
        private DateTime _Fecha;        
        private string _TipoDocumento;
        private string _NombreUsuarioEmisor;
        private string _NombreUsuarioReceptor;
        private byte[] _Archivo;
        private int _EstadoFirmas;
        private bool _Leido;
        private string _Formato;
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
        public string TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        [DataMember]
        public string NombreUsuarioEmisor
        {
            get { return _NombreUsuarioEmisor; }
            set { _NombreUsuarioEmisor = value; }
        }

        [DataMember]
        public string NombreUsuarioReceptor
        {
            get { return _NombreUsuarioReceptor; }
            set { _NombreUsuarioReceptor = value; }
        }

        [DataMember]
        public string Formato
        {
            get { return _Formato; }
            set { _Formato = value; }
        }

        [DataMember]
        public bool Leido
        {
            get { return _Leido; }
            set { _Leido = value; }
        }

        [DataMember]
        public int EstadoFirmas
        {
            get { return _EstadoFirmas; }
            set { _EstadoFirmas = value; }
        }

        [DataMember]
        public int IdDocumento
        {
            get { return _IdDocumento; }
            set { _IdDocumento = value; }
        }


        [DataMember]
        public byte[] Archivo
        {
            get { return _Archivo; }
            set { _Archivo = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Documento()
        {
        }

        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="nombreUsuarioEmisor">Nombre de usuario del emisor</param>
        /// <param name="nombreUsuarioReceptor">Nombre de usuario del receptor</param>
        /// <param name="departamento">Nombre del departamento</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="fechaEmision">Fecha de emisión del documento</param>
        /// <param name="fechaRecepcion">Fecha de recepción del documento</param>
        public Documento(string nombreDocumento, DateTime fecha, string tipoDocumento, string nombreUsuarioEmisor, string nombreUsuarioReceptor)
        {
            _NombreDocumento = nombreDocumento;
            _Fecha = fecha;
            _TipoDocumento = tipoDocumento;
            _NombreUsuarioEmisor = nombreUsuarioEmisor;
            _NombreUsuarioReceptor = nombreUsuarioReceptor;
           
        }


        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="nombreUsuarioReceptor">Nombre de usuario del receptor</param>
        public Documento(int idDocumento, string nombreDocumento, DateTime fecha,  string usuario, int estadoFirmas, bool leido)
        {
            _IdDocumento = idDocumento;
            _NombreDocumento = nombreDocumento;
            _Fecha = fecha;
            _NombreUsuarioEmisor = usuario;
            _EstadoFirmas = estadoFirmas;
            _Leido = leido;
        }


        public Documento(string nombreDocumento, String formatoArchivo, Byte[] archivo)
        {
            _NombreDocumento = nombreDocumento;
            _Formato = formatoArchivo;
            _Archivo = archivo;
        }
        #endregion
    }
}
