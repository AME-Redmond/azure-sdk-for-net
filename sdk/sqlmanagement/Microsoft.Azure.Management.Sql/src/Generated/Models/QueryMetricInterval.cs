// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Properties of a query metrics interval.
    /// </summary>
    public partial class QueryMetricInterval
    {
        /// <summary>
        /// Initializes a new instance of the QueryMetricInterval class.
        /// </summary>
        public QueryMetricInterval()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the QueryMetricInterval class.
        /// </summary>
        /// <param name="intervalStartTime">The start time for the metric
        /// interval (ISO-8601 format).</param>
        /// <param name="intervalType">Interval type (length). Possible values
        /// include: 'PT1H', 'P1D'</param>
        /// <param name="executionCount">Execution count of a query in this
        /// interval.</param>
        /// <param name="metrics">List of metric objects for this
        /// interval</param>
        public QueryMetricInterval(string intervalStartTime = default(string), string intervalType = default(string), long? executionCount = default(long?), IList<QueryMetricProperties> metrics = default(IList<QueryMetricProperties>))
        {
            IntervalStartTime = intervalStartTime;
            IntervalType = intervalType;
            ExecutionCount = executionCount;
            Metrics = metrics;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the start time for the metric interval (ISO-8601 format).
        /// </summary>
        [JsonProperty(PropertyName = "intervalStartTime")]
        public string IntervalStartTime { get; private set; }

        /// <summary>
        /// Gets interval type (length). Possible values include: 'PT1H', 'P1D'
        /// </summary>
        [JsonProperty(PropertyName = "intervalType")]
        public string IntervalType { get; private set; }

        /// <summary>
        /// Gets execution count of a query in this interval.
        /// </summary>
        [JsonProperty(PropertyName = "executionCount")]
        public long? ExecutionCount { get; private set; }

        /// <summary>
        /// Gets or sets list of metric objects for this interval
        /// </summary>
        [JsonProperty(PropertyName = "metrics")]
        public IList<QueryMetricProperties> Metrics { get; set; }

    }
}
