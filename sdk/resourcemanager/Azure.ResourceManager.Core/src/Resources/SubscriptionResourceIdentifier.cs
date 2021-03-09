// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SubscriptionResourceIdentifier : TenantLevelResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionOrResourceId"></param>
        public SubscriptionResourceIdentifier(string subscriptionOrResourceId) 
            : base(new ResourceType("Microsoft.Resources", "subscriptions"), GetSubscriptionId(subscriptionOrResourceId))
        {
            SubscriptionId = GetSubscriptionId(subscriptionOrResourceId);
        }

        internal static string GetSubscriptionId(string subscriptionOrResourceId)
        {
            if (string.IsNullOrWhiteSpace(subscriptionOrResourceId))
                throw new ArgumentException("Not a valid subscriptionid resource.", nameof(subscriptionOrResourceId));
            var parts = subscriptionOrResourceId.Split( new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count > 1 && string.Equals(parts[0], NewResourceIdentifier.SubscriptionsKey, StringComparison.InvariantCultureIgnoreCase))
                return parts[1];
            Guid subscriptionGuid;
            if (Guid.TryParse(subscriptionOrResourceId, out subscriptionGuid))
                return subscriptionOrResourceId;
            throw new ArgumentException("Not a valid subscriptionid resource.", nameof(subscriptionOrResourceId));
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public override bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = SubscriptionId;
            return true;
        }

        internal override string ToResourceString()
        {
            return $"/subscriptions/{SubscriptionId}";
        }
    }
}
