using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogManager.Library
{
    public class ActivityCategory
    {
        #region Properties

        public virtual int ActivityCategoryId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual bool Enabled
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
