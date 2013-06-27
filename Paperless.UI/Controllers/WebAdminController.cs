using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paperless.UI.WebService;
using Paperless.UI.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Configuration;
using System.Text;
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

        /// <summary>
        /// URL: /WebAdmin/DocumentMigration/
        /// </summary>
        /// <returns>View Actualizada</returns>
        public ActionResult MigrateDocument(int pid)
        {
            try
            {
                Documento Documento = new Documento();
                Documento = clienteWCF.ObtenerDocumento(pid);
           
                clienteWCF.ActualizarEstadoDocumento(pid);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }

            return RedirectToAction("DocumentMigration");
         }


        /// <summary>
        /// URL: /WebAdmin/IrregularEvents/
        /// </summary>
        /// <returns>View</returns>
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
        public ActionResult SearchDocuments(DocumentAuditModel pmodel)
        {
            return RedirectToAction("DocumentResults", pmodel);
        }

        /// <summary>
        /// URL: /WebAdmin/DocumentAudit/
        /// Método que se encarga de desplegar en pantalla los resultados obtenidos de la búsqueda realizada
        /// </summary>
        /// <param name="docs">Lista de documentos resultantes</param>
        /// <returns>View</returns>
        public ActionResult DocumentResults(DocumentAuditModel pmodel)
        {
            Documento[] docs = null;
            try
            {
                if (!this.IsSearchParamsEmpty(pmodel.UserSender, pmodel.UserReciever, pmodel.Department, pmodel.DocumentType, pmodel.IssueDate, pmodel.ReceptionDate))
                {
                    docs = clienteWCF.ObtenerDocumentosAuditoria(pmodel.UserSender, pmodel.UserReciever, pmodel.Department, pmodel.DocumentType, pmodel.IssueDate, pmodel.ReceptionDate);
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



        public ActionResult DetailsDocumentResults(string pid)
        {
            DocumentoDetalleMovimiento[] movs = null;
            try
            {
                movs = clienteWCF.ObtenerDetalleDocumentoAuditoria(pid);
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
        public ActionResult SearchUsers(UserAuditModel pmodel)
        {
            return RedirectToAction("UserResults", pmodel);
        }

        /// <summary>
        /// URL: /WebAdmin/UserAudit/
        /// Método que se encarga de desplegar en pantalla los resultados obtenidos de la búsqueda realizada
        /// </summary>
        /// <param name="docs">Lista de usuarios resultantes</param>
        /// <returns>View</returns>
        public ActionResult UserResults(UserAuditModel pmodel)
        {
            Usuario[] lstUsuarios = null;
            try
            {
                lstUsuarios = clienteWCF.ObtenerUsuario(pmodel.UserName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            lstUsuarios = IsEmptyResult(lstUsuarios);
            return View(lstUsuarios.ToList());
        }

        public ActionResult DetailsUserResults(string pid)
        {
            DocumentoDetalleMovimiento[] movs = null;
            try
            {
                movs = clienteWCF.ObtenerDetalleUsuarioAuditoria(pid);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.WORKFLOW, ex.GetType(),
                    (int)ErrorCode.ERROR_OPENING_CONNECTION_WS, ExceptionMessages.Instance[ErrorCode.ERROR_OPENING_CONNECTION_WS], false);
            }
            return View(movs);
        }

        public ActionResult CheckEvent(string porigen, string pid)
        {
            Evento eventoRevisar=new Evento();
            eventoRevisar.Origen = porigen;
            eventoRevisar.IDReferencia = Convert.ToInt32(pid);
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
        public bool IsSearchParamsEmpty(string puserSender, string puserReciever, string pdepartment, string pdocType, DateTime pissueDate, DateTime preceptionDate)
        {
            if (String.IsNullOrEmpty(puserSender) && String.IsNullOrEmpty(puserReciever) && pdepartment.Equals(CUALQUIERA) && pdocType.Equals(CUALQUIERA) && pissueDate.Equals(DateTime.MinValue) && preceptionDate.Equals(DateTime.MinValue))
                return true;
            else
                return false;
        }

        public Evento[] IsEmptyResult(Evento[] presult)
        {
            if (presult == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return new Evento[] { };

            }
            else if (presult.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";

            }
            return presult;
        }

        public Documento[] IsEmptyResult(Documento[] presult)
        {
            if (presult == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return new Documento[] { };

            }
            else if (presult.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";

            }
            return presult;
        }

        public Usuario[] IsEmptyResult(Usuario[] presult)
        {
            if (presult == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return new Usuario[] { };

            }
            else if (presult.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";

            }
            return presult;
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
