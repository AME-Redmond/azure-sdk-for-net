// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Parameters for updating a workspace resource. </summary>
    public partial class WorkspaceUpdateParameters
    {

        /// <summary> The resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
        /// <summary> Managed service identity of the workspace. </summary>
        public WorkspaceIdentity Identity { get; }
    }
}
