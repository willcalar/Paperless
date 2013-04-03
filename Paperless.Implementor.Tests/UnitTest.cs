using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paperless.Implementor;

namespace Paperless.Implementor.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestObtenerDocumentosAuditoria()
        {
            Paperless.Implementor.DocumentosImplementor.Instance.ObtenerDocumentosAuditoria();
        }
    }
}
