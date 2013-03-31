using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paperless.UI.WebService;
using Paperless.UI.Models;
using System.Collections.Generic;

namespace Paperless.UI.Controllers
{
    public class WebAdminController : Controller
    {
        ServiceContractClient clienteWCF = new ServiceContractClient();

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
            return View();
        }


        public ActionResult IrregularEvents()
        {
            return View();
        }

        /// <summary>
        /// URL: /WebAdmin/DocumentAudit/
        /// </summary>
        /// <returns>View</returns>
        public ActionResult DocumentAudit()
        {
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
            if (!this.IsSearchParamsEmpty(model.UserSender, model.UserReciever, model.Department, model.DocumentType, model.IssueDate, model.ReceptionDate))
            {
                /*Aqui procesa la consulta para todos los documentos almacenados en el sistema*/
                /* S redirige a la página de resultados con la lista de docs obtenida*/
                docs = new Documento[1]; // aqui llama al web service?
                docs[0] = new Documento();
                docs[0].NombreDocumento = "a";
                docs[0].NombreUsuarioEmisor = "a";
                docs[0].NombreUsuarioReceptor = "s";
                docs[0].TipoDocumento = "he";
                docs[0].Fecha = new DateTime(1999, 12, 25);
            }
            else
            {
                /*Aqui procesa la consulta para todos los documentos almacenados en el sistema*/
                /* S redirige a la página de resultados con la lista de docs obtenida*/
                docs = new Documento[0]; // aqui llama al web service?  
            }

            //Revisar si docs null tirar mensaje de error
            //Revisar si docs vacío tirar mensaje de no resultados
            //si no retorna los resultados
            if (docs == null)
            {
                ViewData["Message"] = "Ha ocurrido un error en la búsqueda. Por favor intente de nuevo.";
                return View(docs);
            }
            if (docs.Length == 0)
            {
                ViewData["Message"] = "No hay resultados que mostrar.";
                return View(docs);
            }
            else
                return View(docs);
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
            Usuario[] lstUsuarios = clienteWCF.ObtenerUsuario(model.UserName);
            
            /*List<Usuario> usuarios = new List<Usuario>();
            Usuario u = new Usuario();
            u.Departamento = "a";
            u.NombreUsuario = "a";
            u.PrimerApellido = "a";
            u.SegundoApellido = "a";
            usuarios.Add(u);

            Usuario u2 = new Usuario();
            u2.Departamento = "a2";
            u2.NombreUsuario = "a2";
            u2.PrimerApellido = "a2";
            u2.SegundoApellido = "a2";
            usuarios.Add(u2);*/

            return View(lstUsuarios.ToList());
        }

        #region Validations
        /// <summary>
        /// Método que se encarga de validar los parámetros de entrada en los campos
        /// de búsqueda de documentos, 
        /// </summary>
        /// <returns>Si se encuentran TODOS vacíos retorna verdadero
        /// al contrario retorna falso</returns>
        public bool IsSearchParamsEmpty(string userSender, string userReciever, string department, string docType, DateTime issueDate, DateTime receptionDate)
        {
            if (String.IsNullOrEmpty(userSender) && String.IsNullOrEmpty(userReciever) && String.IsNullOrEmpty(department) && String.IsNullOrEmpty(docType) && String.IsNullOrEmpty(issueDate.ToString()) && String.IsNullOrEmpty(receptionDate.ToString()))
                return true;
            else
                return false;
        }
        #endregion

    }
}
