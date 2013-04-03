using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogManager.Library
{
    public class ActivityType
    {
        #region Properties

        public virtual int TypeId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual ActivitySeverity ActivitySeverity
        {
            get;
            set;
        }

        public virtual ActivityCategory ActivityCategory
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
