// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Represents resources homed in a resource group.
    /// </summary>
    public class ResourceGroupLevelResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupLevelResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceGroup">The respource group containign this resource.</param>
        /// <param name="resourceNamespace">The namespace of the resource.</param>
        /// <param name="resourceType">The type name of the resource.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public ResourceGroupLevelResourceIdentifier(ResourceGroupResourceIdentifier resourceGroup, string resourceNamespace, string resourceType, string resourceName)
            : base(resourceGroup, new ResourceType(resourceNamespace, resourceType), resourceName)
        {
            SubscriptionId = resourceGroup.SubscriptionId;
            ResourceGroupName = resourceGroup.ResourceGroupName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupLevelResourceIdentifier"/> class for a Child resource.
        /// </summary>
        /// <param name="parent">The <see cref="ResourceGroupLevelResourceIdentifier"/> of the parent of this child resource.</param>
        /// <param name="childResourceType">The simple resource type name of the child resource - this should not contain namespace or parent types.</param>
        /// <param name="childResourceName">The name of the child resource.</param>
        public ResourceGroupLevelResourceIdentifier(ResourceGroupLevelResourceIdentifier parent, string childResourceType, string childResourceName)
            : base(parent, new ResourceType(parent.ResourceType.Namespace, $"{parent.ResourceType.Type }/{childResourceType}"), childResourceName)
        {
            SubscriptionId = parent.SubscriptionId;
            ResourceGroupName = parent.ResourceGroupName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupLevelResourceIdentifier"/> class for an extension resource.
        /// </summary>
        /// <param name="target">he <see cref="ResourceGroupLevelResourceIdentifier"/> of the target of this extension resource.</param>
        /// <param name="extensionProviderNamespace">The provider namespace of the extension.</param>
        /// <param name="extensionResourceType">The full ARM resource type of the extension.</param>
        /// <param name="extensionResourceName">The name of the extension resource.</param>
        public ResourceGroupLevelResourceIdentifier(ResourceGroupLevelResourceIdentifier target, string extensionProviderNamespace, string extensionResourceType, string extensionResourceName)
            : base(target, new ResourceType(extensionProviderNamespace, extensionResourceType), extensionResourceName)
        {
            SubscriptionId = target.SubscriptionId;
            ResourceGroupName = target.ResourceGroupName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        public ResourceGroupLevelResourceIdentifier(string resourceId)
        {
            var id = NewResourceIdentifier.Create(resourceId) as ResourceGroupLevelResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            ResourceGroupName = id.ResourceGroupName;
            SubscriptionId = id.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ResourceGroupName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public override bool TryGetResourceGroupName(out string resourceGroupName)
        {
            resourceGroupName = ResourceGroupName;
            return true;
        }

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
