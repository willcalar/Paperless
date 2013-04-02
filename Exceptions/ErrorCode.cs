namespace Exceptions
{
	public enum ErrorCode
    {
        #region Users and Security errors 64000 -> 64039
        /// <summary>
        /// Error that is completely unexpected
        /// </summary>
        UNEXPECTED_ERROR = 64000,
        /// <summary>
        /// Error reported when DCOM component had failed in the unmanagged code
        /// </summary>
        DCOM_AUTHENTICATED_FAILED = 64001,
        /// <summary>
        /// Controlled error that occours when login fail or the users controller report any kind of invalidation
        /// </summary>
        DCOM_AUTHENTICATE_CONTROLLED_ERROR = 64002,
        #endregion

        #region General Settings Manager errors 64040 -> 64079
        /// <summary>
        /// There's a failed operation trying to stored the new setting value
        /// </summary>
        FAILED_STORE_GENERAL_SETTING_VALUE = 64040,
        /// <summary>
        /// There's a failed trying to retreive a setting value from the database
        /// </summary>
        FAILED_GETTING_SETTING_VALUE = 64041,
        /// <summary>
        /// An error occour trying to create or access information related to location information
        /// </summary>
        ERROR_ON_LOCATION_INFO = 64042,
        #endregion

        #region Users and Security Error codes 64080 -> 64119
        /// <summary>
        /// Failed when checking login status, attemps, restrictions
        /// </summary>
        ERROR_ON_LOGIN_USER_BY_RESTRICTIONS = 64080,
        /// <summary>
        /// The account or password supplied was incorrect
        /// </summary>
        ACCOUNT_OR_PASSWORD_INCORRECT = 64081,
        /// <summary>
        /// The account was disabled because had tried too many attemps
        /// </summary>
        ACCOUNT_DISABLED_MANY_ATTEMPS = 64082,
        /// <summary>
        /// The account is not recorded in the database
        /// </summary>
        ACCOUNT_NOT_RECORDED = 64083,
        /// <summary>
        /// The account is not recorded in the database
        /// </summary>
        USER_NOT_ADDED_EDIT = 64084,
        /// <summary>
        /// The account is not recorded in the database
        /// </summary>
        ROLE_NOT_ADDED = 64085,
        /// <summary>
        /// The PIN number or the user was incorrect
        /// </summary>
        ACCOUNT_OR_PIN_INCORRECT = 64086,
        /// <summary>
        /// Cannot read the user permissions for this application
        /// </summary>
        CANNOT_LOAD_PERMISSIONS = 64087,
        #endregion

        #region Encription and Decryption codes 64120 -> 64159
        /// <summary>
        /// The account is not recorded in the database
        /// </summary>
        DONGLE_COM_ERROR = 64120,
        #endregion

        #region System Messaging Queue codes 64160 --> 64200
        /// <summary>
        /// Problem occour when the destiny queue is unreacheable
        /// </summary>
        QUEUE_SEND_FAILED = 64200,
        QUEUE_PREPARING_TO_SEND_FAILED = 64201,
        QUEUE_MAINTENANCE = 64202,
        #endregion

        #region ReportMailSender codes 64300 -> 64350

        ERROR_HANDLING_XML = 64300,
        ERROR_GENERATING_REPORT = 64301,
        ERROR_SENDING_MAIL = 64303,
        ERROR_SAVING_LOG = 64304,
        ERROR_CREATING_FILE = 64305,
        ERROR_UNEXPECTED_RMS = 64306,
        ERROR_PARSING_CONFIGURATION = 64307,

        #endregion

        #region LINQ to SQL codes 64350 -> 64399

        ERROR_ESTABLISHING_CONNECTION_LINQ = 64350,
        ERROR_SUBMITTING_CHANGES_LINQ = 64351,
        ERROR_GETTING_TABLE_LINQ = 64352,
        ERROR_QUERY_LINQ = 64353,
        ERROR_EXECUTING_SP = 64354,

        #endregion

        #region Web Socket Service errors 64400 -> 64499

        ERROR_STARTING_WEBSOCKET_SERVER = 64400,
        ERROR_SENDING_MESSAGE_WS = 64401,
        ERROR_RECEIVING_MESSAGE_WS = 64402,
        ERROR_DESERIALIZING_JSON_WS = 64403,
        ERROR_OPENING_CONNECTION_WS = 64404,
        ERROR_CLOSING_CONNECTION_WS = 64405,
        ERROR_BROADCASTING_MESSAGE_WS = 64406,
        ERROR_RESTARTING_WEBSOCKET_SERVER = 64407,
        ERROR_STOPPING_WEBSOCKET_SERVER = 64408,
        ERROR_GETTING_WEBSOCKET_CONFIGURATION = 64409,

        #endregion

        #region MemCached codes 64500 -> 64599

        ERROR_INITIALIZING_INTERFACE = 64500,
        ERROR_SETTING_ITEM = 64501,
        ERROR_GETTING_ITEM = 64502,
        ERROR_FLUSHING_ITEMS = 64503,

        #endregion

        #region NHibernate codes 64600 -> 64699

        ERROR_CONFIGURING_NHIBERNATE = 64600,
        ERROR_OPENING_SESSION = 64601,
        ERROR_CLOSING_SESSION=64602,
        ERROR_SAVING_ITEMS = 64603,
        ERROR_GETTING_ITEMS = 64604,
        ERROR_INITIALIZING_NHIBERNATE_SERVICE = 64605,
        ERROR_COMITTING_TRANSACTION = 64606,
        ERROR_BEGINNING_TRANSACTION = 64607,
        ERROR_ROLLBACK_TRANSACTION = 64608


        #endregion

    }
}
