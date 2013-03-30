using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.Library;
using Paperless.DataAccess;

namespace Paperless.Implementor
{
    public class DocumentosImplementor
    {

        #region Methods
        #endregion

        #region Singleton
        private DocumentosImplementor() { }

        public static DocumentosImplementor Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                        instance = new DocumentosImplementor();
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
        private static volatile DocumentosImplementor instance;
        private static object syncRoot = new Object();
        private DataAccess.DataAccess _AccesoDB;
        #endregion
    }
}
