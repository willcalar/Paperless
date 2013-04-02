namespace Exceptions
{
    public class Policy
    {

        #region Constants
        /// <summary>
        /// Default policy name
        /// </summary>
        public const string DEFAULT_POLICY = "Default Exception Policy";
        /// <summary>
        /// Policy used on the logic on the client side, discard GUI exceptions
        /// </summary>
		public const string CLIENT_GENERAL_LOGIC = "Client General Logic Policy";
        /// <summary>
        /// Policy for exceptions produced inside the GUI layer
        /// </summary>
		public const string GUI = "GUI Exception Policy";
        /// <summary>
        /// Policy for exceptions that could have effects on the Workflow process
        /// </summary>
		public const string WORKFLOW = "Workflow Exception Policy";
        /// <summary>
        /// Policy for exceptions that had occoured trying to access data base or data storage
        /// </summary>
		public const string DATA_ACCESS = "Data Access Exception Policy";
        /// <summary>
        /// Policy for errors occours in the programas that are a process or win service, job in a server or automated process
        /// </summary>
		public const string PROCESS_SERVICE = "Process or Service Exception Policy";
		/// <summary>
		/// Policy for exceptions that had occoured in the server side like Services, DataTransformations, etc.
		/// </summary>
		public const string SERVER_SIDE = "Server Side Policy";
		/// <summary>
		/// Policy for exceptions that had occoured and needs to be logged but no body needs to know.
		/// </summary>
		public const string LOG_ONLY = "Log Without Throw";
        #endregion
    }
}
