using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paperless.UI.WebService;
using Paperless.UI.Models;
using System.Collections.Generic;
using Exceptions;

namespace Paperless.UI.Controllers
{
    public class WebAdminController : Controller
    {
        #region Attributes
        ServiceContractClient clienteWCF = new ServiceContractClient();
        #endregion

        #region Action Results
        /// <summary>
        /// URL: /WebAdmin/
        /// </summary>
        /// <returns>View</returns>
        public ActionResult WebAdmin ()
        {
            return View();
        }


        /// <summary>
        /// URL: /WebAdmin/DocumentMigration/
        /// </summary>
        /// <returns>View</returns>
        public ActionResult DocumentMigration()
        {
            Documento[] docs = null;
            try
            {
                docs = clienteWCF.ObtenerDocumentosPorMigrar();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            docs = IsEmptyResult(docs); 
            return View(docs);
        }


        public ActionResult IrregularEvents()
        {
            Evento[] events = null;
            try
            {
                events = clienteWCF.ObtenerEventosIrregulares();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            events= IsEmptyResult(events);
            return View(events);

        }

        /// <summary>
        /// URL: /WebAdmin/DocumentAudit/
        /// </summary>
        /// <returns>View</returns>
        public ActionResult DocumentAudit()
        {
            fillComboBoxAuditModel();
            return View();
        }


        /// <summary>
        /// Método que se encarga de capturar la información de filtrado de la búsqueda
        /// para recolectar los documentos que los cumplan, o si no mostrar TODOS los
        /// documentos del sistema
        /// </summary>
        /// <param name="_BtnSearch">Nombre del botón</param>
        /// <param name="userSender">Nombre usuario emisor</param>
        /// <param name="userReciever">Nombre usuario receptor</param>
        /// <param name="department">Nombre departamento</param>
        /// <param name="docType">Nombre tipo documento</param>
        /// <param name="issueDate">Fecha de emisión</param>
        /// <param name="receptionDate">Fecha de recepción</param>
        /// <returns>Se redirige a la otra página con los parámetros debidos</returns>
        [HttpPost]
        public ActionResult SearchDocuments(DocumentAuditModel model)
        {
            return RedirectToAction("DocumentResults", model);
        }

        /// <summary>
        /// URL: /WebAdmin/DocumentAudit/
        /// Método que se encarga de desplegar en pantalla los resultados obtenidos de la búsqueda realizada
        /// </summary>
        /// <param name="docs">Lista de documentos resultantes</param>
        /// <returns>View</returns>
        public ActionResult DocumentResults(DocumentAuditModel model)
        {
            Documento[] docs = null;
            try
            {
                if (!this.IsSearchParamsEmpty(model.UserSender, model.UserReciever, model.Department, model.DocumentType, model.IssueDate, model.ReceptionDate))
                {
                    docs = clienteWCF.ObtenerDocumentosAuditoria(model.UserSender, model.UserReciever, model.Department, model.DocumentType, model.IssueDate, model.ReceptionDate);
                }
                else
                {
                    docs = clienteWCF.ObtenerTodosDocumentosAuditoria();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            docs = IsEmptyResult(docs);
            return View(docs);
        }



        public ActionResult DetailsDocumentResults(string id)
        {
            DocumentoDetalleMovimiento[] movs = null;
            try
            {
                movs = clienteWCF.ObtenerDetalleDocumentoAuditoria(id);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            return View(movs);
        }

        /// <summary>
        /// URL: /WebAdmin/UserAudit/
        /// </summary>
        /// <returns>View</returns>
        public ActionResult UserAudit()
        {
            return View();
        }

        /// <summary>
        /// Busca los usuarios resultantes
        /// </summary>
        /// <param name="model">Modelo de usuario</param>
        /// <returns>El view con la lista de resultados</returns>
        [HttpPost]
        public ActionResult SearchUsers(UserAuditModel model)
        {
            return RedirectToAction("UserResults", model);
        }

        /// <summary>
        /// URL: /WebAdmin/UserAudit/
        /// Método que se encarga de desplegar en pantalla los resultados obtenidos de la búsqueda realizada
        /// </summary>
        /// <param name="docs">Lista de usuarios resultantes</param>
        /// <returns>View</returns>
        public ActionResult UserResults(UserAuditModel model)
        {
            Usuario[] lstUsuarios = null;
            try
            {
                lstUsuarios = clienteWCF.ObtenerUsuario(model.UserName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            lstUsuarios = IsEmptyResult(lstUsuarios);
            return View(lstUsuarios.ToList());
        }

        public ActionResult DetailsDUserResults(string id)
        {
            DocumentoDetalleMovimiento[] movs = null;
            try
            {
                movs = clienteWCF.ObtenerDetalleUsuarioAuditoria(id);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            return View(movs);
        }

        public ActionResult CheckEvent(string origen, string id)
        {
            Evento eventoRevisar=new Evento();
            eventoRevisar.Origen = origen;
            eventoRevisar.IDReferencia = Convert.ToInt32(id);
            //FUNCION QUE ENVIA CORREO AL ADMIN DEL SISTEMA

            return View(eventoRevisar);
        }

        #endregion

        #region Validations
        /// <summary>
        /// Método que se encarga de validar los parámetros de entrada en los campos
        /// de búsqueda de documentos, 
        /// </summary>
        /// <returns>Si se encuentran TODOS vacíos retorna verdadero
        /// al contrario retorna falso</returns>
        public bool IsSearchParamsEmpty(string userSender, string userReciever, string department, string docType, DateTime issueDate, DateTime receptionDate)
        {
            if (String.IsNullOrEmpty(userSender) && String.IsNullOrEmpty(userReciever) && department.Equals(CUALQUIERA) && docType.Equals(CUALQUIERA) && issueDate.Equals(DateTime.MinValue) && receptionDate.Equals(DateTime.MinValue))
                return true;
            else
                return false;
        }

        public Evento[] IsEmptyResult(Evento[] result)
        {
            if (result == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return new Evento[] { };

            }
            else if (result.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";

            }
            return result;
        }

        public Documento[] IsEmptyResult(Documento[] result)
        {
            if (result == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return new Documento[] { };

            }
            else if (result.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";

            }
            return result;
        }

        public Usuario[] IsEmptyResult(Usuario[] result)
        {
            if (result == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return new Usuario[] { };

            }
            else if (result.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";

            }
            return result;
        }
        #endregion

        #region Data Methods

        private void fillComboBoxAuditModel()
        {
            String[] departamentos = new String[]{};
            String[] tiposDocumento = new String[]{};
            List<SelectListItem> tiposDocumentoList = new List<SelectListItem>() { new SelectListItem(){ Value= CUALQUIERA, Text= CUALQUIERA, Selected= false }};
            List<SelectListItem> departamentosList = new List<SelectListItem>() { new SelectListItem() { Value = CUALQUIERA, Text = CUALQUIERA, Selected = false }};
            try
            {
                departamentos = clienteWCF.ObtenerDepartamentos();
                tiposDocumento = clienteWCF.ObtenerTiposDocumento();
            }
            catch(Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }

            
            foreach (String departamento in departamentos)
            {
                SelectListItem dep = new SelectListItem(){Value=departamento, Text= departamento, Selected= false};
                departamentosList.Add(dep);
            }
            
            foreach (String tipoDocumento in tiposDocumento)
            {
                SelectListItem tipo = new SelectListItem() { Value = tipoDocumento, Text = tipoDocumento, Selected = false };
                tiposDocumentoList.Add(tipo);
            }

            ViewData["Departments"] = departamentosList;
            ViewData["TypesOfDocument"] = tiposDocumentoList;
        }

        #endregion 

        #region Constants
        public const string CUALQUIERA = "Cualquiera";
        #endregion

    }
}
