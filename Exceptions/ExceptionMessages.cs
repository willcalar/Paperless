using System;
using System.Collections.Generic;

namespace Exceptions
{
	public class CoreExceptionMessages
	{
		#region Constructors
		/// <summary>
		/// Private constructor for singleton pattern
		/// </summary>
		private CoreExceptionMessages()
        {
            #region Users and Security
            _Messages.Add(ErrorCode.UNEXPECTED_ERROR, "An unexpected error had been occour");
            _Messages.Add(ErrorCode.DCOM_AUTHENTICATED_FAILED, "The unmanaged code had produce an unexpected error");
            _Messages.Add(ErrorCode.DCOM_AUTHENTICATE_CONTROLLED_ERROR, "The users controller server had reported the status of the authentication");
            _Messages.Add(ErrorCode.ERROR_ON_LOGIN_USER_BY_RESTRICTIONS, "Fialed in authentication because users restrictions in the users database");
            _Messages.Add(ErrorCode.ACCOUNT_OR_PASSWORD_INCORRECT, "Account or password is incorrect");
            _Messages.Add(ErrorCode.ACCOUNT_DISABLED_MANY_ATTEMPS, "Account was disabled because many failed attemps");
            _Messages.Add(ErrorCode.ACCOUNT_NOT_RECORDED, "Account is not properly recorded on the database");
            _Messages.Add(ErrorCode.USER_NOT_ADDED_EDIT, "User information wasn't save correctly");
            _Messages.Add(ErrorCode.ROLE_NOT_ADDED, "Role name wasn't added to the database");
            _Messages.Add(ErrorCode.ACCOUNT_OR_PIN_INCORRECT, "The account or pin code suplied was incorrect");
            _Messages.Add(ErrorCode.CANNOT_LOAD_PERMISSIONS, "Cannot load the permissions for this user on this application");
            #endregion

            #region Branch General Settings
            _Messages.Add(ErrorCode.FAILED_GETTING_SETTING_VALUE, "There's a database problem trying to store this new general setting value");
            _Messages.Add(ErrorCode.FAILED_STORE_GENERAL_SETTING_VALUE, "Because a database problem is not possible to retreive the setting value");
            _Messages.Add(ErrorCode.ERROR_ON_LOCATION_INFO, "Access to location information cannot be possible");
            #endregion

            #region Encryption and Decryption
            _Messages.Add(ErrorCode.DONGLE_COM_ERROR, "Error in COM component for usb dongle devices");
            #endregion

            #region System Messaging Queue
            _Messages.Add(ErrorCode.QUEUE_SEND_FAILED, "The destiny queue is unreachabled");
            _Messages.Add(ErrorCode.QUEUE_PREPARING_TO_SEND_FAILED, "Publishing messages had been failed");
            _Messages.Add(ErrorCode.QUEUE_MAINTENANCE, "There's a problem in the internal maintenance of the messaging system");
            #endregion

            #region Report Mail Sender
            _Messages.Add(ErrorCode.ERROR_SENDING_MAIL, "Error sending mail");
            _Messages.Add(ErrorCode.ERROR_SAVING_LOG, "Error saving log");
            _Messages.Add(ErrorCode.ERROR_HANDLING_XML, "Error while handling XML file");
            _Messages.Add(ErrorCode.ERROR_GENERATING_REPORT, "Error generating a report");
            _Messages.Add(ErrorCode.ERROR_CREATING_FILE, "Error creating a file");
            _Messages.Add(ErrorCode.ERROR_PARSING_CONFIGURATION, "Error parsing general configuration");
            #endregion

            #region Web Socket Service

            _Messages.Add(ErrorCode.ERROR_STARTING_WEBSOCKET_SERVER, "Error starting the web scoket server");
            _Messages.Add(ErrorCode.ERROR_SENDING_MESSAGE_WS, "Error in the web scoket server while sending a message");
            _Messages.Add(ErrorCode.ERROR_RECEIVING_MESSAGE_WS, "Error in the web scoket server while receiving a message");
            _Messages.Add(ErrorCode.ERROR_DESERIALIZING_JSON_WS, "Error in the web scoket server while deserialiazing a JSON message");
            _Messages.Add(ErrorCode.ERROR_OPENING_CONNECTION_WS, "Error in the web scoket server while opening a new client connection");
            _Messages.Add(ErrorCode.ERROR_CLOSING_CONNECTION_WS, "Error in the web scoket server while closing a client connection");
            _Messages.Add(ErrorCode.ERROR_BROADCASTING_MESSAGE_WS, "Error in the web scoket server while trying to broadcast a message");
            _Messages.Add(ErrorCode.ERROR_RESTARTING_WEBSOCKET_SERVER, "Error restarting the web socket server");
            _Messages.Add(ErrorCode.ERROR_STOPPING_WEBSOCKET_SERVER, "Error stopping the web socket server");
            _Messages.Add(ErrorCode.ERROR_GETTING_WEBSOCKET_CONFIGURATION, "Error getting the web socket configuration");

            #endregion
        }
		#endregion Constructors

		#region Properties
		/// <summary>
		/// Method to get Singleton instance of the CoreExceptionMessages
		/// </summary>
		/// <returns></returns>
		/// <summary>
		/// Gets the singleton class instance
		/// </summary>
		public static CoreExceptionMessages Instance
		{
			get
			{
				if (_SingletonInstance == null)
				{
					lock (LockObj)
					{
						if (_SingletonInstance == null)
						{
							_SingletonInstance = new CoreExceptionMessages();
						}
					}
				}
				return _SingletonInstance;
			}
		}
		/// <summary>
		/// Gets the message associated with the specified ExceptionErrorCode
		/// </summary>
		/// <param name="pErrorCode">ErrorCode to get the message</param>
		/// <returns>The message associated with the error code</returns>
		public string this[ErrorCode pErrorCode]
		{
			get
			{
				return _Messages[pErrorCode];
			}
		}
		#endregion Properties

		#region Attributes
		/// <summary>
		/// Stores all messages for exceptions indexed by ErrorCode
		/// </summary>
		private readonly Dictionary<ErrorCode,string> _Messages = new Dictionary<ErrorCode, string>();
		/// <summary>
		/// Stores the singleton instance of this class
		/// </summary>
		private static CoreExceptionMessages _SingletonInstance;
		/// <summary>
		/// Use as flag to lock the singleton instance
		/// </summary>
		private static readonly Object LockObj = new object();
		#endregion Attributes
	}
}
