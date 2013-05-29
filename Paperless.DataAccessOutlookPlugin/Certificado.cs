using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Paperless.DataAccessPlugins
{
    public static class Certificado
    {
        public static bool ChequearCertificado()
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Certificate2Collection storecollection;
            store.Open(OpenFlags.ReadOnly);
            storecollection = (X509Certificate2Collection)store.Certificates;
            storecollection = storecollection.Find(X509FindType.FindBySubjectName, Environment.MachineName, true);
            if (storecollection.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
