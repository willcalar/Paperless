
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LogManager.Library
{
    /// <summary>
    /// Represent an entry for the eventlog stored in the database
    /// </summary>
    public class LogInfo
    {
        #region Properties
        /// <summary>
        /// Log id in the database, unique identifier
        /// </summary>
        public virtual int LogId
        {
            get;
            set;
        }

        /// <summary>
        /// TypeId of this activity, related to enums 
        /// </summary>
        public int ActivityType
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the activity
        /// </summary>
        public string ActivityTypeName
        {
            get;
            set;
        }

        /// <summary>
        /// Source which produce this log entry
        /// </summary>
        public string Source
        {
            get;
            set;
        }

        /// <summary>
        /// Builds the path to the image for this severity type
        /// </summary>
        public string SeverityImagePath
        {
            get
            {
                return string.Format(PATH_TO_IMAGES, Severity);
                //return string.Format(PATH_TO_IMAGES, ActivityType.ActivitySeverity.Name);
            }
        }
        /// <summary>
        /// Severity of this log
        /// </summary>
        public string Severity
        {
            get;
            set;
        }

        /// <summary>
        /// Category clasified for this log
        /// </summary>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Description for this entry, it explains exactly what happend during this log
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Datetime when the activity happends
        /// </summary>
        public virtual DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the computer which record this log
        /// </summary>
        public virtual string ComputerName
        {
            get;
            set;
        }

        /// <summary>
        /// Ip address for the computer which save this log
        /// </summary>
        public virtual string ComputerIp
        {
            get;
            set;
        }

        /// <summary>
        /// Username which log this entry
        /// </summary>
        public virtual string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Contextual reference data, depends of the ActivityType this value is interpreted
        /// </summary>
        public virtual string Reference
        {
            get;
            set;
        }
        
        public virtual ActivityType ActivityTypeObject
        {
            get;
            set;
        }

        public virtual Source LogSource
        {
            get;
            set;
        }

        #endregion

        #region Contants
        private const string PATH_TO_IMAGES = "Images\\AdminApplication\\{0}.png";
        #endregion
    }
}
