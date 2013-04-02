using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Exceptions
{
    /// <summary>
    /// Class used to have a external log file
    /// </summary>
    public class FileLog
    {
        /// <summary>
        /// Constructor that initialize the Chrons and create a log file named FileLog.txt
        /// </summary>
        private FileLog()
        {
            _Writer = new StreamWriter("FileLog.txt");
            _Chrons = new Hashtable();
            Enabled = true; 
        }


        /// <summary>
        /// Implementation for the singleton pattern
        /// </summary>
        public static FileLog Instance
        {
            get
            {
                if (_FileLog == null)
                {
                    _FileLog = new FileLog();
                }
                return _FileLog;
            }
        }

        /// <summary>
        /// Indicate if the log is enabled or not
        /// </summary>
        public bool Enabled
        {
            get;
            set;
        }

        #region Methods
        /// <summary>
        /// Write all the values in params format 
        /// </summary>
        /// <param name="pValues">Params to be written</param>
        public void WriteLog(params String[] pValues)
        {
            if (Enabled)
            {
                foreach (string value in pValues)
                {
                    _Writer.Write(value+",");
                }
                _Writer.Flush();
                _Writer.WriteLine(string.Empty);
            }
        }

        /// <summary>
        /// Start a chronometer with a specific name
        /// </summary>
        /// <param name="pValue">Name for the chronometer</param>
        public void Cron(string pValue)
        {
            if (Enabled)
            {
                if (!_Chrons.ContainsKey(pValue))
                {
                    _Chrons.Add(pValue, DateTime.Now);
                }
            }
        }

        /// <summary>
        /// Stop one specific chronometer and record the value in the log file
        /// </summary>
        /// <param name="pValue">Chronometer name</param>
        public void StopCron(string pValue)
        {
            if (Enabled)
            {
                if (_Chrons.ContainsKey(pValue))
                {
                    WriteLog(pValue,DateTime.Now.ToShortDateString(),DateTime.Now.ToShortTimeString(),(DateTime.Now - ((DateTime)_Chrons[pValue])).Milliseconds.ToString());
                    _Chrons.Remove(pValue);
                }
                else
                {
                    WriteLog(pValue, "NA");
                }
            }
        }

        /// <summary>
        /// Close the current file
        /// </summary>
        public void Close()
        {
            _Writer.Close();
            Enabled = false;
        }
        #endregion

        #region Attributes
        /// <summary>
        /// Hashtable to stored all chronometers 
        /// </summary>
        private Hashtable _Chrons;
        /// <summary>
        /// Implement single instance pattern
        /// </summary>
        private static FileLog _FileLog;
        /// <summary>
        /// Object used to read and write files
        /// </summary>
        private TextWriter _Writer;
        #endregion
    }
}
