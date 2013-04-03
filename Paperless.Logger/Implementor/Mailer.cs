using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace LogManager.Implementor
{
	public class Mailer
	{
		#region Constructor
		/// <summary>
		/// Private constructor to prevent instantiating this class directly, it is a singleton class
		/// </summary>
		private Mailer()
		{
			_MessagesToSend = new Queue<MailMessage>();

			_BackgroundWorker = new BackgroundWorker
			                    	{
			                    		WorkerReportsProgress = true, 
										WorkerSupportsCancellation = true
			                    	};

			_BackgroundWorker.DoWork += SendMails;
			_BackgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
		}
		#endregion Constructor

		#region Properties
		/// <summary>
		/// Method to get Singleton instance of the dataaccess
		/// </summary>
		/// <returns></returns>
		/// <summary>
		/// Gets the singleton class instance
		/// </summary>
		public static Mailer Instance
		{
			get
			{
				if (_StaticInstance == null)
				{
					lock (LockObj)
					{
						if (_StaticInstance == null)
						{
							_StaticInstance = new Mailer();
						}
					}
				}
				return _StaticInstance;
			}
		}
		#endregion Properties

		#region Methods

		/// <summary>
		/// Add a mail to the queue
		/// </summary>
		/// <param name="pMessage">Message to send</param>
		public void EnqueueMessage(MailMessage pMessage)
		{
			_MessagesToSend.Enqueue(pMessage);

			//If backgroundworker is stopped, start sending emails
			if (!_Sending)
			{
				_BackgroundWorker.RunWorkerAsync();
			}
		}

		/// <summary>
		/// Process to send mails
		/// </summary>
		private void SendMails(object sender, DoWorkEventArgs e)
		{
			_Sending = true;

			var smtp = new SmtpClient();
			while(_MessagesToSend.Count > 0)
			{
				smtp.Send(_MessagesToSend.Dequeue());                
			}

			_Sending = false;
		}

		/// <summary>
		/// Handles when the background worker finishes, because work is finished or error or cancelation.
		/// </summary>
		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_Sending = false;
		}

		#endregion Methods

		#region Attributes
		/// <summary>
		/// Store the singleton instance
		/// </summary>
		private static Mailer _StaticInstance;
		/// <summary>
		/// Log for the creation of the singleton class
		/// </summary>
		protected static readonly Object LockObj = new Object();
		/// <summary>
		/// Queue to handle messages to send
		/// </summary>
		private Queue<MailMessage> _MessagesToSend;
		/// <summary>
		/// Flag that indicates if process is sending emails
		/// </summary>
		private bool _Sending;
		/// <summary>
		/// Backgroundworker to send emails
		/// </summary>
		private BackgroundWorker _BackgroundWorker;
		#endregion Attributes
	}
}
