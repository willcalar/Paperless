
using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using LogManager.DataAccess;
using LogManager.Library;
using LogEntry = Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry;

namespace LogManager.Implementor
{
	/// <summary>
	/// Custom tracer for Enterprise Library Logging applica
	/// </summary>
	[ConfigurationElementType(typeof(CustomTraceListenerData))]
	public class LogTraceListener : CustomTraceListener
	{

		/// <summary>
		/// Method used by the logging application block to catch logs
		/// </summary>
		public override void TraceData(TraceEventCache pEventCache, string pSource, TraceEventType pEventType, int pId, object pData)
		{
			if (pData is LogEntry)
			{
				var log = pData as LogEntry;
				LogDataAccess.Instance.WriteLog(log.Message, log.EventId, (int)log.ExtendedProperties[Constants.SOURCE_ID_PROPERTY_KEY], (string)log.ExtendedProperties[Constants.REFERENCE_OBJEC_ID_PROPERTY_KEY]);
			}
			else
			{
				Trace.WriteLine("LogTraceListener only works with LogEntry and with these two extended properties: Core.Libraries.LogManager.Contants.SOURCE_ID_PROPERTY_KEY AND Core.Libraries.LogManager.Contants.REFERENCE_OBJEC_ID_PROPERTY_KEY");
			}
		}


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
	}
}
