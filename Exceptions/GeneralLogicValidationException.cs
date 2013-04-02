using System;

namespace Exceptions
{
    public class GeneralLogicValidationException : GeneralException
    {
        #region Constructors
        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public GeneralLogicValidationException()
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public GeneralLogicValidationException(string pMessage) : base(pMessage)
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public GeneralLogicValidationException(string pMessage, Exception pInner): base(pMessage, pInner)
        {
        }
        #endregion
    }    
}
