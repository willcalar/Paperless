
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using LogManager.Library;
using LogEntry = Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry;
using LogManager.DataAccess;
using System.Collections.Generic;


namespace LogManager.Implementor
{
	public class LogManager
    {
        #region Constructor
        
        
        /// <summary>
        /// Static constructor for LogManager
        /// </summary>
        static LogManager()
        {            
            TraceLogs = (new BooleanSwitch("TraceLogApplicationBlock", string.Empty)).Enabled;
        }


        /// <summary>
        /// Default constructor initialized in order to control paging
        /// </summary>
        /*public LogManager()
        {
            _Settings = SettingsImplementor.Instance;
            MAX_RECORD_PER_PAGE = _Settings.GetIntValue(BranchSettings.Implementor.Constants.MAX_PAGE_RECORDS_IN_ACTIVITY_LOG);
            _BottonIds = new List<int>(); // stack to control the paging
            _TopIds = new List<int>(); // stack to control the paging
            PageNumber = 1;
        }*/
        #endregion

        #region Properties
        /// <summary>
        /// Current category selected 
        /// </summary>
        public string CategorySelected
        {
            get;
            set;
        }
        /// <summary>
        /// Filter about the datetime where to extract the activities
        /// </summary>
        public LogActivityFilterType FilterSelected
        {
            get;
            set;
        }

        public int PageNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Get the total pages required to view all data requested
        /// </summary>
        public int TotalPages
        {
            get
            {
                return _CantidadRegistros / MAX_RECORD_PER_PAGE + (_CantidadRegistros % MAX_RECORD_PER_PAGE > 0 ? 1 : 0);
            }
        }
        #endregion

        #region Methods
        /// <summary>
		/// Add an activity to the activity log
		/// </summary>
		/// <param name="pMessage">Description or message of the activity</param>
		/// <param name="pType">Activity Type, activities types are retrieved from database</param>
		/// <param name="pSourceId">Object, component, control or piece of hardware where the activity occurred</param>
		/// <param name="pReferenceObjectId">The identifier of the object source </param>
		public static void LogActivity( int pType,int pSourceId,string pReferenceObjectId,string pMessage )
		{
			var log = new LogEntry
			          	{
			          		EventId = pType, 
							Message = pMessage, 
							Severity = TraceEventType.Information,
							Priority = 2
			          	};

			log.Categories.Add(Library.Constants.ACTIVITIES_CATEGORY);
            log.ExtendedProperties[Library.Constants.SOURCE_ID_PROPERTY_KEY] = pSourceId;
            log.ExtendedProperties[Library.Constants.REFERENCE_OBJEC_ID_PROPERTY_KEY] = pReferenceObjectId;

            if (TraceLogs)
            {
                string traceMessage = "** LOG APPLICATION BLOCK: " + pMessage;
                Trace.WriteLine(traceMessage);
            }

			_LogWriter.Write(log);
		}

		/// <summary>
		/// Add an activity to the activity log
		/// </summary>
		/// <param name="pMessage">Description or message of the activity</param>
		/// <param name="pType">Activity Type, activities types are retrieved from database</param>
		/// <param name="pSourceId">Object, component, control or piece of hardware where the activity occurred</param>
		/// <param name="pReferenceObjectId">The identifier of the object source </param>
		/// <param name="pParams">Several strings to format the message, when it has paraameter. Ex: "Message {0} to device {1}" </param>
		public static void LogActivity( int pType,int pSourceId,string pReferenceObjectId,string pMessage,params object[] pParams )
		{
			LogActivity( pType, pSourceId, pReferenceObjectId,string.Format( pMessage, pParams) );
        }

        /// <summary>
        /// Extract the next records from activity log based on the last request 
        /// </summary>
        /// <returns>List of LogInfo object</returns>
        public List<LogInfo> GetNextLogActivities()
        {
            List<LogInfo> result;
            if (_BottonIds.Count > 0)
            {
                int countPage = _BottonIds.Count;
                result = GetLogActivities(FilterSelected, CategorySelected, _BottonIds[_BottonIds.Count - 1], true);
                PageNumber = countPage!=_BottonIds.Count? ++PageNumber: PageNumber;
                return result;
            }

        	result = GetLogActivities(FilterSelected, CategorySelected, int.MaxValue, true);
        	return result;
        }

        /// <summary>
        /// Extract the previous LogInfo records based on the current position of the log activity
        /// </summary>
        /// <returns>List of LogInfo object</returns>
        public List<LogInfo> GetPreviousLogActivities()
        {
            List<LogInfo> result;
            if (_TopIds.Count > 0)
            {
                _TopIds.RemoveAt(_TopIds.Count-1);
                _BottonIds.RemoveAt(_BottonIds.Count - 1);
                --PageNumber;
            }
            if (_TopIds.Count > 0)
            {
                // is neccesary use the +1 modifier, because if not the query will exclude the record in the top
                result = GetLogActivities(FilterSelected, CategorySelected, _TopIds[_TopIds.Count - 1]+1, false);
            }
            else
            {
                result = GetLogActivities(FilterSelected, CategorySelected, int.MaxValue, false);
            }
            return result; 
        }


        /// <summary>
        /// Returns the list of all the recently activity events happend in this computer using the criteria
        /// </summary>
		/// <param name="pFilterType">Determines the time to extract</param>
		/// <param name="pCcategoryName">The category to look for</param>
		/// <param name="pBaseId">Initialial logid where to start the searching, use -1 if all data is requiere or 0 to start from the beggining until 16 records</param>
        /// <param name="pForward"></param>
        /// <returns>List of LogEntry for the current parameters</returns>
        public List<LogInfo> GetLogActivities(LogActivityFilterType pFilterType, string pCcategoryName, int pBaseId, bool pForward)
        {
            // extract records from the beggining
            FilterSelected = pFilterType;
            CategorySelected = pCcategoryName;

            List<LogInfo> result = LogDataAccess.Instance.GetLogActivities(pFilterType, pCcategoryName,
                                    pBaseId, ref _CantidadRegistros, MAX_RECORD_PER_PAGE);

            if (pBaseId == int.MaxValue) // if the list restart
            {
                _BottonIds.Clear();
                _TopIds.Clear();
                PageNumber = 1;
            }

            if ((result.Count > 0) && (pForward))
            {
                _TopIds.Add(result[0].LogId);
                _BottonIds.Add(result[result.Count - 1].LogId);
            }

            return result;
        }

        /// <summary>
        /// Method used to prepare the database for testing purpose
        /// </summary>
        /*public void PrepareLogForTesting()
        {
            LogDataAccess.Instance.PrepareLogForTesting();
        }*/

        #endregion

        #region Attributes
        /// <summary>
        /// Used to control paging when access the activity log
        /// </summary>
        private List<int> _BottonIds;
        /// <summary>
        /// Used to control paging when access the activity log
        /// </summary>
        private List<int> _TopIds;
        /// <summary>
        /// Cantidad de registros total
        /// </summary>
        private int _CantidadRegistros;
        /// <summary>
        /// Settings implementor in order to get some setup values
        /// </summary>
        //private readonly SettingsManager _Settings = null;
        /// <summary>
        /// Indicate how many records are showed per page
        /// </summary>
        private readonly int MAX_RECORD_PER_PAGE;

        /// <summary>
        /// True if configured to trace logs at app.config
        /// </summary>
        private static bool TraceLogs;
		/// <summary>
		/// Userd to write logs
		/// </summary>
		private static LogWriter _LogWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
		#endregion

		#region Constantes

		#endregion
    }
}
