// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class SubscriptionLevelResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceName"></param>
        public SubscriptionLevelResourceIdentifier(SubscriptionResourceIdentifier subscription, ResourceType resourceType, string resourceName) 
            : base(subscription, resourceType, resourceName)
        {
            SubscriptionId = subscription.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="providerNamespace"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceName"></param>
        public SubscriptionLevelResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string resourceName)
            : base(new SubscriptionResourceIdentifier(subscriptionId), new ResourceType(providerNamespace, resourceType), resourceName)
        {
            SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; }
    }
}
