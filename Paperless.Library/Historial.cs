using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Paperless.Library
{
    [DataContract]
    public class Historial
    {

        #region Atributos
        #endregion
        
        #region Propiedades
        public string Evento { get; set; }
        public string TipoEvento { get; set; }
        public DateTime Fecha { get; set; }
        public string Username { get; set; }
        #endregion
        
        #region Constructores
        /// <summary>
        /// Constructor vacío de la clase
        /// </summary>
        public Historial()
        {
        }
        #endregion
    }
}
