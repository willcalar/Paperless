using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Diagnostics;
using System.Reflection;

namespace Exceptions
{
	public class ExceptionManager
    {
        #region Contructors

        /// <summary>
        /// 
        /// </summary>
        static ExceptionManager()
        {
            TraceExceptions = (new BooleanSwitch("TraceExceptions", string.Empty)).Enabled;
        }

        #endregion

        #region Methods
        /// <summary>
		/// Handle the exception according to the params
		/// </summary>
		/// <param name="pException">The exception to be handled</param>
		/// <param name="pPolicy">Policy to handle this exception, must exist in the app.config for the Exception handling application block</param>
		/// <param name="pErrorCode">The error code of this exception</param>
		/// <param name="pMessage">The message to use in the replace exception</param>
		/// <param name="pExceptionType">The exception type to replace to current exception</param>
        /// <param name="pStackException">True if the new exception should have as inner exception pException</param>
		/// <returns>True if the policy specified to rethrow the exception, false otherwise.</returns>
		public static void HandleException(Exception pException, string pPolicy, Type pExceptionType, int pErrorCode, string pMessage,bool pStackException)
		{
            if (pException != null)
            {

                Trace.WriteLineIf(TraceExceptions, "** EXCEPTION HANDLED: " + pException.Message + " / INTERNAL MESSAGE: " + pMessage);

                pException.Data[ERROR_CODE_DATA_KEY] = pErrorCode;
                pException.Data[ERROR_MESSAGE_DATA_KEY] = pMessage;

                bool rethrow = false;

                try
                {
                    rethrow = ExceptionPolicy.HandleException(pException, pPolicy);
                }
                catch
                {
                    Trace.WriteLineIf(TraceExceptions, "** EXCEPTION HANDLED: Invalid Exception Policy: " + pPolicy);
                    return;
                }

                if (rethrow)
                {
                    Exception exceptionToThrow;

                    if (pExceptionType != null)
                    {
                        if (pExceptionType.IsSubclassOf(typeof(Exception)))
                        {
                            try
                            {
                                exceptionToThrow = (Exception)Activator.CreateInstance(pExceptionType, pMessage);                                                                
                            }
                            catch
                            {
                                try
                                {
                                    exceptionToThrow = (Exception)Activator.CreateInstance(pExceptionType);
                                }
                                catch
                                {
                                    exceptionToThrow = new GeneralException(pExceptionType.FullName, pException);
                                }
                            }                            
                        }
                        else
                        {
                            exceptionToThrow = new GeneralException(pExceptionType.FullName, pException);
                        }
                    }
                    else
                    {                        
                        exceptionToThrow = pException;
                    }

                    exceptionToThrow.Data[ERROR_CODE_DATA_KEY] = pErrorCode;

                    if (pStackException && exceptionToThrow != pException)
                    {
                        FieldInfo innerExceptionField = typeof(Exception).GetField("_innerException", BindingFlags.Instance | BindingFlags.NonPublic);
                        innerExceptionField.SetValue(exceptionToThrow, pException);
                    }

                    throw exceptionToThrow;
                }
            }
		}

        /// <summary>
		/// Handle the exception according to the params
		/// </summary>
		/// <param name="pException">The exception to be handled</param>
		/// <param name="pPolicy">Policy to handle this exception, must exist in the app.config for the Exception handling application block</param>
		/// <param name="pErrorCode">The error code of this exception</param>
		/// <param name="pMessage">The message to use in the replace exception</param>
		/// <param name="pExceptionType">The exception type to replace to current exception</param>
		/// <returns>True if the policy specified to rethrow the exception, false otherwise.</returns>
        public static void HandleException(Exception pException, string pPolicy, Type pExceptionType, int pErrorCode, string pMessage)
        {
            HandleException(pException, pPolicy, pExceptionType, pErrorCode, pMessage, true);
        }

		/// <summary>
		/// Handle the exception according to the params, using a message with parameters. Those parameters are specified in the pParams
		/// </summary>
		/// <param name="pException">The exception to be handled</param>
		/// <param name="pPolicy">Policy to handle this exception, must exist in the app.config for the Exception handling application block</param>
		/// <param name="pErrorCode">The error code of this exception</param>
		/// <param name="pMessage">The message to use in the replace exception</param>
		/// <param name="pExceptionType">The exception type to replace to current exception</param>
		/// <param name="pParams">Several string params to format the message</param>
		/// <returns>True if the policy specified to rethrow the exception, false otherwise.</returns>
		public static void HandleException(Exception pException, string pPolicy, Type pExceptionType, int pErrorCode, string pMessage, params string[] pParams)
		{
			string message = string.Format(pMessage, pParams);
			HandleException(pException, pPolicy, pExceptionType, pErrorCode, message);
		}

		#endregion Methods

        #region Atributes

        /// <summary>
        /// True if configured to trace errors at app.config
        /// </summary>
        private static bool TraceExceptions;

        #endregion

        #region Constants
        /// <summary>
		/// Used to get/set the Error message in Data dictionary
		/// </summary>
		public const string ERROR_MESSAGE_DATA_KEY = "ErrorMessage";
		/// <summary>
		/// Used to get/set the Error code in Data dictionary
		/// </summary>
		public const string ERROR_CODE_DATA_KEY = "ErrorCode";
		/// <summary>
		/// Message used in the Exception generated when pExceptionType doesn't inherit from <c>Exception</c>
		/// </summary>
		private const string WRONG_EXCEPTION_TYPE_MESSAGE = "The exception type must be specified and must inherit from Exception";

		#endregion Constants
	}
}
