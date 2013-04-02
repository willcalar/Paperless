using System;

namespace Exceptions
{
    public class SimpleLogTraceException : GeneralException
    {
        #region Constructors
        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public SimpleLogTraceException()
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public SimpleLogTraceException(string pMessage) : base(pMessage)
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public SimpleLogTraceException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
        #endregion
    }
}
