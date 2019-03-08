using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.LogWriteApp
{
    public sealed class EnterpriseLibraryLogWriter : ILogWriter
    {
        /// <summary>
        /// The <see cref="LogWriter"/> which will be used to write data to the logs.
        /// </summary>
        private LogWriter LogWriter { get; set; }

        /// <summary>
        /// Initializes a default instance of the <see cref="EnterpriseLibraryLogWriter"/> class.
        /// </summary>
        public EnterpriseLibraryLogWriter()
        {
            var factory = new LogWriterFactory();
            this.LogWriter = factory.Create();
        }

        /// <summary>
        /// Writes a new log entry with a specific category, priority, event ID, severity, title and dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log. Value from ToString() method from message object.</param>
        /// <param name="category">The category name which pertains to the entry.</param>
        /// <param name="priority">The proirity of the entry. Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventID">Event number or identifier.</param>
        /// <param name="severity">Log message severity as a <see cref="System.Diagnostics.TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        /// <param name="title">An additional description of the log entry message.</param>
        /// <param name="properties">A dictionary of additional key/value pairs to log.</param>
        public void Write(object message, string category, int priority, int eventID = 0,
                TraceEventType severity = TraceEventType.Information, string title = null, IDictionary<string, object> properties = null)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                if (properties != null)
                {
                    properties.ToList().ForEach(delegate (KeyValuePair<string, object> entry)
                    {
                        if (entry.Value != null)
                        {
                            data.Add(entry.Key, entry.Value);
                        }
                    });
                }

                LogEntry log = new LogEntry();
                log.Message = message.ToString();
                log.Categories.Add(category);
                log.Priority = priority;
                log.EventId = eventID;
                log.Severity = severity;
                log.Title = title;
                log.ExtendedProperties = data;
                this.LogWriter.Write(log);
            }
            catch
            {
                // Do nothing.
            }
        }

        /// <summary>
        /// Writes a new log entry with a specific set of categories, a priority, event ID, severity, title and dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log. Value from ToString() method from message object.</param>
        /// <param name="categories">A collection of category names that pertain to the entry.</param>
        /// <param name="priority">The proirity of the entry. Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventID">Event number or identifier.</param>
        /// <param name="severity">Log message severity as a <see cref="System.Diagnostics.TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        /// <param name="title">An additional description of the log entry message.</param>
        /// <param name="properties">A dictionary of additional key/value pairs to log.</param>
        public void Write(object message, IEnumerable<string> categories, int priority, int eventID = 0,
                TraceEventType severity = TraceEventType.Information, string title = null, IDictionary<string, object> properties = null)
        {
            try
            {
                LogEntry log = new LogEntry();
                log.Message = message.ToString();
                log.Categories = categories.ToList();
                log.Priority = priority;
                log.EventId = eventID;
                log.Severity = severity;
                log.Title = title;
                log.ExtendedProperties = properties;
                this.LogWriter.Write(log);
                //this.LogWriter.Write(message, categories, priority, eventID, severity, title, properties);
            }
            catch
            {
                // Do nothing.
            }
        }


        public void LogException(object objexception, string title = null, IDictionary<string, object> properties = null, TraceEventType? eventType = null)
        {
            try
            {
                Exception exception = (Exception)objexception;

                var message = this.GetCompleteException(exception);

                Dictionary<string, object> data = new Dictionary<string, object>();
                if (properties != null)
                {
                    properties.ToList().ForEach(delegate (KeyValuePair<string, object> entry)
                    {
                        if (entry.Value != null)
                        {
                            data.Add(entry.Key, entry.Value);
                        }
                    });
                }

                LogEntry log = new LogEntry();
                log.Message = message.ToString();
                //log.Categories = "";
                log.Priority = 0;
                log.EventId = 0;
                log.Severity = eventType.HasValue ? eventType.Value : TraceEventType.Error;
                log.Title = title;
                log.ExtendedProperties = data;
                this.LogWriter.Write(log);
                //this.LogWriter.Write(message, "", 0, 0, eventType.HasValue ? eventType.Value : TraceEventType.Error, title, data);
            }
            catch
            {
                //Swallow error.
            }
        }

        #region Helpers
        private string GetCompleteException(Exception ex)
        {
            if (ex != null)
            {
                return string.Format("{0} : {1} >\n\n {2} ", ex.Message, ex.StackTrace, GetCompleteException(ex.InnerException));
            }

            return string.Empty;
        }
        #endregion
    }
}
