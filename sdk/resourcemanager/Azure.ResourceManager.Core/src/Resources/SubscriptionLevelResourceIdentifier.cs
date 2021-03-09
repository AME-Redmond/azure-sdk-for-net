// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class SubscriptionLevelResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// Internal use only
        /// </summary>
        internal SubscriptionLevelResourceIdentifier()
        {
        }

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
        /// <param name="parent"></param>
        /// <param name="extensionResourceType"></param>
        /// <param name="resourceName"></param>
        public SubscriptionLevelResourceIdentifier(SubscriptionLevelResourceIdentifier parent, ResourceType extensionResourceType, string resourceName)
            :base(parent, extensionResourceType, resourceName)
        {
            SubscriptionId = parent.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childResourceType"></param>
        /// <param name="childResourceName"></param>
        public SubscriptionLevelResourceIdentifier( SubscriptionLevelResourceIdentifier parent, string childResourceType, string childResourceName) 
            : base(parent, new ResourceType(parent.ResourceType, childResourceType), childResourceName)
        {
            SubscriptionId = parent.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        public SubscriptionLevelResourceIdentifier(string resourceId)
        {
            var id = NewResourceIdentifier.Create(resourceId) as SubscriptionLevelResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            SubscriptionId = id.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; internal set; }

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
    }
}
