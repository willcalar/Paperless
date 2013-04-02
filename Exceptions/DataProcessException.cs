using System;

namespace Exceptions
{
    public class DataProcessException : GeneralException
    {
        #region Constructors
        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public DataProcessException()
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public DataProcessException(string pMessage) : base(pMessage)
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public DataProcessException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
        #endregion
    }
}
