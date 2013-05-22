using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogManager.Implementor
{
    public class MensajesLog
    {
        #region Documentos
        public const string ACTUALIZAR_ESTADO_DOCUMENTO = "Se actualizo el estado del documento";
        public const string ERROR_ACTUALIZAR_ESTADO_DOCUMENTO = "No se pudo actualizar el estado del documento";
        public const string OBTENER_DOCUMENTOS_AUDITORIA = "Se obtuvo documentos para auditoría siguiendo los parámetros de búsqueda";
        public const string ERROR_OBTENER_DOCUMENTOS_AUDITORIA = "No se obtuvieron documentos para auditoría";
        public const string OBTENER_DOCUMENTOS_AUDITORIA_2 = "Se obtuvo todos los documentos para auditoría";
        public const string OBTENER_MOVIMIENTOS_DOCUMENTO = "Se obtuvo el detalle de los movimientos del documento {0}";
        public const string ERROR_OBTENER_MOVIMIENTOS_DOCUMENTO = "No se obtuvo el detalle de los movimientos del documento {0}";
        public const string OBTENER_DOCUMENTOS_POR_MIGRAR = "Se obtuvieron los documentos que deben ser migrados";
        public const string ERROR_OBTENER_DOCUMENTOS_POR_MIGRAR = "No se pudo obtener los documentos que deben ser migrados";
        public const string OBTENER_DOCUMENTOS_DE_USUARIO = "Se realizó la recepción de documentos documentos para el usuario: {0}";
        public const string ERROR_OBTENER_DOCUMENTOS_DE_USUARIO = "Error al obtener los documentos para el usuario: {0}";
        public const string OBTENER_DETALLE_DOCUMENTO = "Se realizó la obtención del detalle del documento: {0}";
        public const string ERROR_OBTENER_DETALLE_DOCUMENTO = "Error al obtener el detalle del documento: {0}";
        public const string OBTENER_DOCUMENTO = "Se realizó la obtención del documento con id: {}";
        public const string ERROR_OBTENER_DOCUMENTO = "Error al obtener el documento con id: {}";
        #endregion

        #region Usuarios
        public const string OBTENER_MOVIMIENTOS_USUARIO = "Se obtuvo el detalle de los movimientos del usuario {0}";
        public const string ERROR_OBTENER_MOVIMIENTOS_USUARIO = "No se obtuvo el detalle de los movimientos del usurio {0}";
        
        #endregion





    }
}
