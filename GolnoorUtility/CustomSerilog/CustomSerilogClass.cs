using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using GolnoorUtility.Extentions;

namespace GolnoorUtility.Utilities.CustomSerilog
{
    public class PropertyBagEnricher :ILogEventEnricher
    {
        private readonly Dictionary<string, Tuple<object, bool>> _properties;

        /// <summary>
        /// Creates a new <see cref="PropertyBagEnricher" /> instance.
        /// </summary>
        public PropertyBagEnricher()
        {
            _properties = new Dictionary<string, Tuple<object, bool>>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Enriches the <paramref name="logEvent" /> using the values from the property bag.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">The factory used to create the property.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            
            //logEvent.MessageTemplate.
            //ww
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("PersianDateTime", logEvent.Timestamp.DateTime.ToPersianDateTime()));
            //logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("PersianDateTime", ));
            
            //var ssfsf = context.HttpContext.Request.Headers["Authorization"];
        }

        /// <summary>
        /// Add a property that will be added to all log events enriched by this enricher.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="value">The property value.</param>
        /// <param name="destructureObject">
        /// Whether to destructure the value. See https://github.com/serilog/serilog/wiki/Structured-Data
        /// </param>
        /// <returns>The enricher instance, for chaining Add operations together.</returns>
        public PropertyBagEnricher Add(string key, object value, bool destructureObject = false)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            if (!_properties.ContainsKey(key)) _properties.Add(key, Tuple.Create(value, destructureObject));

            return this;
        }
    }
    public static class LoggingExtensions
    {
        public static LoggerConfiguration WithReleaseNumber(
            this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
                throw new ArgumentNullException(nameof(enrich));

            return enrich.With<PropertyBagEnricher>();
        }
    }
}
