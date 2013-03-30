using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Paperless.UI.WebService;

namespace Paperless.UI.Models
{
    public class DocumentAuditModel
    {
        [DisplayName("Usuario emisor")]
        public string UserSender { get; set; }

        [DisplayName("Usuario receptor")]
        public string UserReciever { get; set; }

        [DisplayName("Departamento")]
        public string Department{ get; set; }
        public SelectList AvailableDepartments { get; set; }

        [DisplayName("Tipo documento")]
        public string DocumentType { get; set; }
        public SelectList AvailableDocTypes { get; set; }

        [DisplayName("Fecha emisión")]
        public DateTime IssueDate { get; set; }

        [DisplayName("Fecha recepción")]
        public DateTime ReceptionDate { get; set; }
    }
}