using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogManager.Library
{
    public class LogMessages
    {
        #region Messages for 
        /// <summary>
        /// Message displayed when egm program is started
        /// </summary>
        public const string QUEUE_ERROR_ON_RECEIVED = "Error OnReceived message or object from message queue";
        /// <summary>
        /// Displayed when was a problema initializing the system queue
        /// </summary>
        public const string QUEUE_ERROR_INITIALIZING = "Error initializing the messaging system queue";
        /// <summary>
        /// There was problems when creating a new publisher
        /// </summary>
        public const string QUEUE_ERROR_ON_PUBLISHER = "Error creating the requested publisher";
        /// <summary>
        /// Error creating a new subscription
        /// </summary>
        public const string QUEUE_ERROR_ON_SUBSCRIPTION = "Error creating the requested new subscription";
        /// <summary>
        /// Error registering a new server
        /// </summary>
        public const string QUEUE_ERROR_ON_REGISTER = "Problem registering servers in the system";
        /// <summary>
        /// Error sending a new message throught the system
        /// </summary>
        public const string QUEUE_FAILED_SENDING = "Problem sending a message thought the system";
        /// <summary>
        /// Error sending a new message throught the system
        /// </summary>
        public const string QUEUE_FAILED_LOADING_SERVERS = "Problems loading the servers";
        /// <summary>
        /// Error updating the servers information
        /// </summary>
        public const string QUEUE_FAILED_UPDATING_SERVERS = "Problems updating the servers";
        /// <summary>
        /// A report has been sent
        /// </summary>
        public const string SEND_REPORT = "Report has been sent: ";

        #endregion
    }
}
