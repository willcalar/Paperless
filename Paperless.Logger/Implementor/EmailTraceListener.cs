using System;
using System.Diagnostics;
using System.Net.Mail;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace LogManager.Implementor
{
	[ConfigurationElementType(typeof(CustomTraceListenerData))]
	public class EmailTraceListener : CustomTraceListener
	{
		/*public EmailTraceListener()
		{
            _SettingsImplementor = SettingsImplementor.Instance;

			SendEmails = _SettingsImplementor.GetBoolValue("SEND_EMAIL_ERROR_REPORT");
		}*/

		#region Properties
		/// <summary>
		/// Indicates if emails should be send
		/// </summary>
		public static bool SendEmails
		{
			get;
			set;
		}
		#endregion Properties
		/// <summary>
		/// Method used by the logging application block to catch logs
		/// </summary>
		/*public override void TraceData(TraceEventCache pEventCache, string pSource, TraceEventType pEventType, int pId, object pData)
		{
			if (pData is LogEntry && SendEmails)
			{
				try
				{
					var log = pData as LogEntry;
					var mail = new MailMessage
					           	{
									From = new MailAddress(_SettingsImplementor.GetValue(EMAIL_FROM_ADDRESS_KEY)),
					           		Subject = DEFAULT_EMAIL_SUBJECT,
					           		Body = Formatter.Format(log),
					           		IsBodyHtml = false
					           	};
					string[] addresses = _SettingsImplementor.GetValue(EMAIL_TO_ADDRESS_KEY).Split(';');
					foreach (var address in addresses)
					{
						mail.To.Add(address);
					}
					

					Mailer.Instance.EnqueueMessage(mail);
				}
				catch(Exception ex)
				{
					Trace.WriteLine(ex.ToString());
				}
			}
			else
			{
				 Trace.WriteLine("EmailTraceListener only works with LogEntry and with these two extended properties: Core.Libraries.LogManager.Contants.SOURCE_ID_PROPERTY_KEY AND Core.Libraries.LogManager.Contants.REFERENCE_OBJEC_ID_PROPERTY_KEY");
			}
		}*/


		/// <summary>
		/// When overridden in a derived class, writes the specified pMessage to the listener you create in the derived class.
		/// </summary>
		/// <param name="pMessage">A message to write. </param><filterpriority>2</filterpriority>
		public override void Write(string pMessage)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// When overridden in a derived class, writes a pMessage to the listener you create in the derived class, followed by a line terminator.
		/// </summary>
		/// <param name="pMessage">A message to write. </param><filterpriority>2</filterpriority>
		public override void WriteLine(string pMessage)
		{
			throw new NotSupportedException();
		}

		#region Attributes
		/// <summary>
		/// Default subject to send emails report
		/// </summary>
		private const string DEFAULT_EMAIL_SUBJECT = "Error & Exception Report";
		/// <summary>
		/// Key to get email address to send the email to, from app config
		/// </summary>
		private const string EMAIL_TO_ADDRESS_KEY = "REPORT_ERRORS_TO_EMAIL";
		/// <summary>
		/// Key to get email address to use as from in the email report
		/// </summary>
		private const string EMAIL_FROM_ADDRESS_KEY = "REPORT_ERRORS_FROM";
		/// <summary>
		/// To Get/Set App Settings
		/// </summary>
		//private readonly SettingsImplementor _SettingsImplementor;

		#endregion Attributes
	}
}
