// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> Represents the response to a List Firewall Rules request. </summary>
    public partial class FirewallRuleListResult
    {
        /// <summary> Initializes a new instance of FirewallRuleListResult. </summary>
        internal FirewallRuleListResult()
        {
            Value = new ChangeTrackingList<FirewallRule>();
        }

        /// <summary> Initializes a new instance of FirewallRuleListResult. </summary>
        /// <param name="value"> The list of server firewall rules. </param>
        internal FirewallRuleListResult(IReadOnlyList<FirewallRule> value)
        {
            Value = value;
        }

        /// <summary> The list of server firewall rules. </summary>
        public IReadOnlyList<FirewallRule> Value { get; }
    }
}