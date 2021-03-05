// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class ResourceGroupLevelResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroup"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceName"></param>
        public ResourceGroupLevelResourceIdentifier(ResourceGroupResourceIdentifier resourceGroup, ResourceType resourceType, string resourceName)
            : base(resourceGroup, resourceType, resourceName)
        {
            SubscriptionId = resourceGroup.SubscriptionId;
            ResourceGroupName = resourceGroup.ResourceGroupName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childResourceType"></param>
        /// <param name="childResourceName"></param>
        public ResourceGroupLevelResourceIdentifier(ResourceGroupLevelResourceIdentifier parent, string childResourceType, string childResourceName)
            : base(parent, new ResourceType(parent.ResourceType.Namespace, $"{parent.ResourceType.Type }/{childResourceType}"), childResourceName)
        {
            SubscriptionId = parent.SubscriptionId;
            ResourceGroupName = parent.ResourceGroupName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="extensionResourceType"></param>
        /// <param name="extensionResourceName"></param>
        public ResourceGroupLevelResourceIdentifier(ResourceGroupLevelResourceIdentifier target, ResourceType extensionResourceType, string extensionResourceName)
            : base(target, extensionResourceType, extensionResourceName)
        {
            SubscriptionId = target.SubscriptionId;
            ResourceGroupName = target.ResourceGroupName;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ResourceGroupName { get; }
    }
}
