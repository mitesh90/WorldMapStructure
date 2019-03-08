using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap.LogWriteApp
{
    public interface ILogWriter
    {
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
        void Write(object message, string category, int priority = 100, int eventID = 0,
                TraceEventType severity = TraceEventType.Information, string title = null, IDictionary<string, object> properties = null);

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
        void Write(object message, IEnumerable<string> categories, int priority = 100, int eventID = 0,
                TraceEventType severity = TraceEventType.Information, string title = null, IDictionary<string, object> properties = null);

        /// <summary>
        /// Writes a new log entry about the exception with a complete inner exception.
        /// </summary>
        /// <param name="objexception">An exception object contains the exception.</param>
        /// <param name="title"></param>
        /// <param name="properties"></param>
        void LogException(object objexception, string title = null, IDictionary<string, object> properties = null, TraceEventType? eventType = null);

    }
}
