// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataMigration.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("DatabaseLevelErrorOutput")]
    public partial class MigrateOracleAzureDbPostgreSqlSyncTaskOutputDatabaseError : MigrateOracleAzureDbPostgreSqlSyncTaskOutput
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MigrateOracleAzureDbPostgreSqlSyncTaskOutputDatabaseError class.
        /// </summary>
        public MigrateOracleAzureDbPostgreSqlSyncTaskOutputDatabaseError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MigrateOracleAzureDbPostgreSqlSyncTaskOutputDatabaseError class.
        /// </summary>
        /// <param name="id">Result identifier</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="events">List of error events.</param>
        public MigrateOracleAzureDbPostgreSqlSyncTaskOutputDatabaseError(string id = default(string), string errorMessage = default(string), IList<SyncMigrationDatabaseErrorEvent> events = default(IList<SyncMigrationDatabaseErrorEvent>))
            : base(id)
        {
            ErrorMessage = errorMessage;
            Events = events;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets error message
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets list of error events.
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IList<SyncMigrationDatabaseErrorEvent> Events { get; set; }

    }
}
