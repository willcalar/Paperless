using System;

namespace Exceptions
{
    public class WorkflowEffectanceException : GeneralException
    {
        #region Constructors
        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public WorkflowEffectanceException()
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public WorkflowEffectanceException(string pMessage) : base(pMessage)
        {
        }

        /// <summary>
        /// Default constructor for Exceptions creation and hiearchy
        /// </summary>
        public WorkflowEffectanceException(string pMessage, Exception pInner) : base(pMessage, pInner)
        {
        }
        #endregion
    }
}
