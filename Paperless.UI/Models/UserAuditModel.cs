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
    public class UserAuditModel
    {
        [DisplayName("Nombre de usuario")]
        public string UserName { get; set; }
    }
}