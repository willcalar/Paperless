using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogManager.Library;

namespace LogManager.DataAccess
{
    /// <summary>
    /// Interface for a strategy pattern in the Log operations for the system
    /// </summary>
    public interface ILogDataAccess
    {
		/// <summary>
		/// Write a log to database
		/// </summary>
		/// <param name="pMessage">Message or description of the log</param>
		/// <param name="pType">Type of the log, according to the ActivityType or similar table</param>
		/// <param name="pSourceId">Source of the log, according to LogSource or similar table</param>
		/// <param name="pReferenceObjectId">Identifier of the source object</param>
        void WriteLog(string pMessage, int pType, int pSourceId, string pReferenceObjectId);
        /// <summary>
		/// Retrieve the latest log added to database
		/// </summary>
		/// <returns>Dataset with the latest log</returns>
        DataSet GetLatestLog();
        /// <summary>
        /// Extract the list of recently Activity logs 
        /// </summary>
		/// <param name="pFilterType">Time filter type</param>
		/// <param name="pCategoryName">CategoryName to look for</param>
		/// <param name="pBaseId">This is the LogId used to extract an expecific size of log, use -1 in order to retreive all</param>
        /// <param name="pRecordCount">Number that said how many total records are in this query</param>
        /// <param name="pAmountOfRecordsToReturn">Amount of total records to be return in this procedure</param>
        List<LogInfo> GetLogActivities(LogActivityFilterType pFilterType, string pCategoryName, int pBaseId, ref int pRecordCount, int pAmountOfRecordsToReturn);
        /// <summary>
        /// Method used to prepare the database for testing purpose
        /// </summary>
        //void PrepareLogForTesting();
    }
}
