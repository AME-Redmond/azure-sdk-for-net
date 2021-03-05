// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SubscriptionResourceIdentifier : TenantLevelResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        public SubscriptionResourceIdentifier(string subscriptionId) 
            : base(new ResourceType("Microsoft.Resources", "subscriptions"), subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; }

        internal override string ToResourceString()
        {
            return $"/subscriptions/{SubscriptionId}";
        }
    }
}
