using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Paperless.Library
{
    [DataContract]
    public class Usuario
    {
        #region Atributos
        private string _NombreUsuario;
        private string _PrimerApellido;
        private string _SegundoApellido;
        private string _Departamento;
        private string _Username;
        private TipoEnvioEnum _TipoEnvio;
        #endregion

        #region Propiedades
        [DataMember]
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }


        [DataMember]
        public string PrimerApellido
        {
            get { return _PrimerApellido; }
            set { _PrimerApellido = value; }
        }

        [DataMember]
        public string SegundoApellido
        {
            get { return _SegundoApellido; }
            set { _SegundoApellido = value; }
        }

        [DataMember]
        public string Departamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }

        [DataMember]
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        [DataMember]
        public TipoEnvioEnum TipoEnvio
        {
            get { return _TipoEnvio; }
            set { _TipoEnvio = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacío de la clase
        /// </summary>
        public Usuario()
        {
        }

        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario</param>
        /// <param name="primerApellido">Primer apellido del usuario</param>
        /// <param name="segundoApellido">Segundo apellido del usuario</param>
        /// <param name="departamento">Departamento del usuario</param>
        public Usuario(string nombreUsuario, string primerApellido, string segundoApellido, string departamento)
        {
            _NombreUsuario = nombreUsuario;
            _PrimerApellido = primerApellido;
            _SegundoApellido = segundoApellido;
            _Departamento = departamento;
        }
        #endregion


        public enum TipoEnvioEnum { Lectura, Firma }

    }
}
