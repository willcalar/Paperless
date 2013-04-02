using System;

namespace Exceptions
{
    public class GeneralException : Exception
    {
        #region Constructors
        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public GeneralException()
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public GeneralException(string pMessage) : base(pMessage)
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public GeneralException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Internal error code based on Excepcion code numbers
        /// </summary>
        public int ErrorCode
        {
            get;
            set;
        }

        #endregion
    }
}
