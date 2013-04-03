
namespace LogManager.Library
{
	public class Constants
	{
		/// <summary>
		/// Category used to add activities to the activities log
		/// </summary>
		public const string ACTIVITIES_CATEGORY = "Activity";
		/// <summary>
		/// Constant used to set and retrieve the extended property used for the source id
		/// </summary>
		public const string SOURCE_ID_PROPERTY_KEY = "SourceId";
		/// <summary>
		/// Constant used to set and retrieve the extended property used for the source id
		/// </summary>
		public const string REFERENCE_OBJEC_ID_PROPERTY_KEY = "ReferenceObjectId";
	}

    /// <summary>
    /// Enum that defines how the date is filter when log is retrieval
    /// </summary>
    public enum LogActivityFilterType { HOUR=1, SIX_HOURS, TODAY, YESTERDAY, THIS_WEEK };

}
