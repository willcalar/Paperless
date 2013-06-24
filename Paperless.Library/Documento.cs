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
        /// <param name="pNombreDocumento">Nombre del documento</param>
        /// <param name="pFecha">Fecha de creación del documento</param>
        /// <param name="pTipoDocumento">Tipo del documento</param>
        /// <param name="pNombreUsuarioEmisor">Nombre del usuario emisor</param>
        /// <param name="pNombreUsuarioReceptor">Nombre del usuario receptor</param>
        public Documento(string pNombreDocumento, DateTime pFecha, string pTipoDocumento, string pNombreUsuarioEmisor, string pNombreUsuarioReceptor)
        {
            _NombreDocumento = pNombreDocumento;
            _Fecha = pFecha;
            _TipoDocumento = pTipoDocumento;
            _NombreUsuarioEmisor = pNombreUsuarioEmisor;
            _NombreUsuarioReceptor = pNombreUsuarioReceptor;
           
        }

        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="pIdDocumento">Id del documento</param>
        /// <param name="pNombreDocumento">Nombre del documento</param>
        /// <param name="pFecha">Fecha de creación del documento</param>
        /// <param name="pTipoDocumento">Tipo del documento</param>
        /// <param name="pNombreUsuarioEmisor">Nombre del usuario emisor</param>
        /// <param name="pNombreUsuarioReceptor">Nombre del usuario receptor</param>
        public Documento(int pIdDocumento, string pNombreDocumento, DateTime pFecha, string pTipoDocumento, string pNombreUsuarioEmisor, string pNombreUsuarioReceptor)
        {
            _IdDocumento = pIdDocumento;
            _NombreDocumento = pNombreDocumento;
            _Fecha = pFecha;
            _TipoDocumento = pTipoDocumento;
            _NombreUsuarioEmisor = pNombreUsuarioEmisor;
            _NombreUsuarioReceptor = pNombreUsuarioReceptor;
        }

        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="pIdDocumento">Id del documento</param>
        /// <param name="pNombreDocumento">Nombre del documento</param>
        /// <param name="pFecha">Fecha de creación del documento</param>
        /// <param name="pUsuario">Nombre del usuario solicitante</param>
        /// <param name="pEstadoFirmas">Estado de las firmas del documento</param>
        /// <param name="pLeido">Booleano que indica si el usuario solicitante ha leido el documento</param>
        public Documento(int pIdDocumento, string pNombreDocumento, DateTime pFecha,  string pUsuario, int pEstadoFirmas, bool pLeido)
        {
            _IdDocumento = pIdDocumento;
            _NombreDocumento = pNombreDocumento;
            _Fecha = pFecha;
            _NombreUsuarioEmisor = pUsuario;
            _EstadoFirmas = pEstadoFirmas;
            _Leido = pLeido;
        }

        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="pNombreDocumento">Nombre del documento</param>
        /// <param name="pFormatoArchivo">El formato del documento</param>
        /// <param name="pArchivo">El contenido del archivo que representa el documento</param>
        public Documento(string pNombreDocumento, String pFormatoArchivo, Byte[] pArchivo)
        {
            _NombreDocumento = pNombreDocumento;
            _Formato = pFormatoArchivo;
            _Archivo = pArchivo;
        }
        #endregion
    }
}
