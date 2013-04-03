
using System;
using System.Data;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using DataAccess=Paperless.DataAccess;
using LogManager.Library;
using Exceptions;
using System.Security.Cryptography;
using System.Collections.Generic;
using ExceptionManager=Exceptions.ExceptionManager;

namespace LogManager.DataAccess
{
    public class LogDataAccess : Paperless.DataAccess.DataAccess, ILogDataAccess
	{
		#region Constructor
		/// <summary>
		/// Private constructor for singleton pattern
		/// </summary>
        /*private LogDataAccess(): base(CORE_DATABASE)
		{
			// nothing
		}*/

		#endregion Constructors

		#region Properties
		/// <summary>
		/// Method to get Singleton instance of the dataaccess
		/// </summary>
		/// <returns></returns>
		/// <summary>
		/// Gets the singleton class instance
		/// </summary>
		/*public static LogDataAccess Instance
		{
			get
			{
                if (_InstanceDataAccess == null)
                {
                    lock (LockObj)
                    {
                        if (_InstanceDataAccess == null)
                        {
                            _InstanceDataAccess = new LogDataAccess();
                        }
                    }
                }
                return (LogDataAccess)_InstanceDataAccess;
			}
		}*/

		#endregion Properties

		#region Methods
		/// <summary>
		/// Write a log to database
		/// </summary>
		/// <param name="pMessage">Message or description of the log</param>
		/// <param name="pType">Type of the log, according to the CO_ActivityType table</param>
		/// <param name="pSourceId">Source of the log, according to CO_LogSource table</param>
		/// <param name="pReferenceObjectId">Identifier of the source object</param>
		public void WriteLog( string pMessage, int pType, int pSourceId, string pReferenceObjectId )
		{
			try
			{
				//Get IpAddresses
				var computerName = Dns.GetHostName();
				var ipAddress = string.Empty;
				var localIPs = Dns.GetHostAddresses(computerName);

				foreach (var ip in localIPs)
				{
					ipAddress += ip + IP_SEPARATOR;
				}
				ipAddress = ipAddress.Substring(0, ipAddress.Length - IP_SEPARATOR.Length);

				// Generate Checksum
				var wholeDataBuilder = new StringBuilder();
				wholeDataBuilder.Append(pType);
				wholeDataBuilder.Append(DATA_SEPARATOR);
				wholeDataBuilder.Append(pMessage);
				wholeDataBuilder.Append(DATA_SEPARATOR);
				wholeDataBuilder.Append(pSourceId);
				wholeDataBuilder.Append(DATA_SEPARATOR);
				/*wholeDataBuilder.Append(Identity.GetInstance().MachineName);
				wholeDataBuilder.Append(DATA_SEPARATOR);*/
				wholeDataBuilder.Append(ipAddress);
				wholeDataBuilder.Append(DATA_SEPARATOR);
				/*wholeDataBuilder.Append(Identity.GetInstance().Username);
				wholeDataBuilder.Append(DATA_SEPARATOR);*/
				wholeDataBuilder.Append(pReferenceObjectId);
				var allData = wholeDataBuilder.ToString();
                var checksum = MD5.Create().ComputeHash(Encoding.Default.GetBytes(allData));


				//pType, pMessage, pSourceId, Identity.GetInstance().MachineName, string.Empty, Environment.NickName, pReferenceObjectId,
                _AccesoDB.ExecuteNonQuery("dbo.PLSSP_EscribirLog", new List<SqlParameter>()
				                                   	{
				                                   		new SqlParameter("@tipoActividad", pType),
				                                   		new SqlParameter("@descripcion", pMessage),
				                                   		new SqlParameter("@fuenteId", pSourceId),
				                                   		new SqlParameter("@nombreComputadora", computerName),
				                                   		new SqlParameter("@ipComputadora", ipAddress),
				                                   		new SqlParameter("@usuario", "CAMBIAR ESTO"),
				                                   		new SqlParameter("@reference1", pReferenceObjectId),
				                                   		new SqlParameter("@checksum", checksum)
				                                   	});
			}
			catch (Exception ex)
			{
				ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, null, 66000, "Error has occured while writing log to database");
			}
		}

		/// <summary>
		/// Retrieve the latest log added to database
		/// </summary>
		/// <returns>Dataset with the latest log</returns>
		public DataSet GetLatestLog()
		{
            var dsLatestLog = _AccesoDB.ExecuteQuery("dbo.PLSSP_ObtenerUltimoLog", new List<SqlParameter>());
			return dsLatestLog;
		}

        /// <summary>
        /// Extract the list of recently Activity logs 
        /// </summary>
		/// <param name="pFilterType">Time filter type</param>
		/// <param name="pCategoryName">CategoryName to look for</param>
		/// <param name="pBaseId">This is the LogId used to extract an expecific size of log, use -1 in order to retreive all</param>
        /// <param name="pRecordCount">Number that said how many total records are in this query</param>
        /// <param name="pAmountOfRecordsToReturn">Amount of total records to be return in this procedure</param>
        public List<LogInfo> GetLogActivities(LogActivityFilterType pFilterType, string pCategoryName, int pBaseId, ref int pRecordCount, int pAmountOfRecordsToReturn)
        {
            var result = new List<LogInfo>();
            try
            {
                var cantRegistros = new SqlParameter("@CantidadRegistros", 0);

                var dsLogActivities = _AccesoDB.ExecuteQuery("dbo.PLSSP_ObtenerLogActividad", new List<SqlParameter>() { 
                    new SqlParameter("@tipoFiltro", (byte)pFilterType),
                    new SqlParameter("@NombreCategoriaActividad", pCategoryName),
                    new SqlParameter("@TopRecordCount", pAmountOfRecordsToReturn),                    
                    new SqlParameter("@baseId", pBaseId),
                    cantRegistros,
					//new SqlParameter("@MachineName", DbType.String, ParameterDirection.Input, Identity.GetInstance().MachineName)
					
                    });

                pRecordCount = (int)cantRegistros.Value;
                if ((dsLogActivities != null) && (dsLogActivities.Tables.Count > 0) && (dsLogActivities.Tables[0].Rows.Count > 0))
                {

                    foreach(DataRow record in dsLogActivities.Tables[0].Rows) 
                    {
                        var entry = new LogInfo();
                        entry.ActivityType = int.Parse(record["ActivityType"].ToString());
                        entry.ActivityTypeName = record["ActivityTypeName"].ToString();
                        entry.Category = record["CategoryName"].ToString();
                        entry.ComputerIp = record["ComputerIp"].ToString();
                        entry.ComputerName = record["ComputerName"].ToString();
                        entry.Description = record["Description"].ToString();
                        entry.LogId = int.Parse(record["LogId"].ToString());
                        entry.Reference = record["ReferenceObject"].ToString();
                        entry.Severity = record["Name"].ToString();
                        entry.Source = record["Source"].ToString();
                        entry.TimeStamp = DateTime.Parse(record["TimeStamp"].ToString());
                        entry.UserName = record["UserName"].ToString();
                        result.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, null, 66001, "Error retreiving recently activity logs");
            }
            return result;
        }

        /// <summary>
        /// Method used to prepare the database for testing purpose
        /// </summary>
       /* public void PrepareLogForTesting()
        {
            try
            {
                ExecuteNonQuery("dbo.CORESP_PrepareEventLogForTesting", new DataParameter[0]);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, Policy.DATA_ACCESS, null, 66001, "Error preparing the log for testing");
            }
        }*/
		#endregion Methods

		#region Constants
		/// <summary>
		/// Used to separate data when generating the checksum
		/// </summary>
		public const string DATA_SEPARATOR = "-*-";
		/// <summary>
		/// Used to separate all the ip addresses in the machine
		/// </summary>
		public const string IP_SEPARATOR = " / ";
		#endregion Constants

        #region Attributtes
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static Paperless.DataAccess.DataAccess _InstanceDataAccess;
        /// <summary>
        /// Log for the creation of the singleton class
        /// </summary>
        protected static readonly Object LockObj = new Object();
        #endregion

        #region Singleton
        private LogDataAccess() { }

        public static LogDataAccess Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new LogDataAccess();
                        instance._AccesoDB = new Paperless.DataAccess.DataAccess();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
        private static volatile LogDataAccess instance;
        private static object syncRoot = new Object();
        private Paperless.DataAccess.DataAccess _AccesoDB;
        #endregion
    }
}
