
namespace LogManager.Library
{
    /// <summary>
    /// Sources used in the CORE in order to map to the database LogSources table
    /// </summary>
    public enum LogSource
    {
        USERS_SECURITY = 10000,
        SYSTEM_QUEUE = 10001,
        REPORT_MAIL_SENDER = 10002
    }

    public class Source
    {
        #region Properties

        public virtual int SourceID
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Description;
        }

        #endregion
    }
}
