using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogManager.Library
{
    public class ActivitySeverity
    {
        #region Properties

        public virtual int ActivitySeverityId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
