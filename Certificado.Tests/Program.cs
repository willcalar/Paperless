using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Certificado.Tests
{
    class Program
    {
        static void CheckCertificateExpiry(string CertificateSubject)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Certificate2Collection storecollection;
            X509Certificate2 x509;
            TimeSpan timespan;

            store.Open(OpenFlags.ReadOnly);
            storecollection = (X509Certificate2Collection)store.Certificates;
            storecollection = storecollection.Find(X509FindType.FindBySubjectName, CertificateSubject, true);

            if (storecollection.Count == 0)
            {
              //  Notify("Certificate for `" + CertificateSubject + "' not found", EventLogEntryType.Information);
            }
            else
            {
                x509 = storecollection[0];
                timespan = Convert.ToDateTime(x509.GetExpirationDateString()) - DateTime.Now;
             //   Notify("[" + CertificateSubject + "] certificate will expire in [" + timespan.Days + " days] issued by "
               //                                                         + x509.GetNameInfo(X509NameType.SimpleName, true),
                 //   (timespan.Days > 30) ? EventLogEntryType.Warning : EventLogEntryType.Error);
            }
        }

        

        static void Main(string[] args)
        {
            CheckCertificateExpiry("JAVIER-PC");
        }
    }
}
