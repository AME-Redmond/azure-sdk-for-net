// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ResourceGroupResourceIdentifier : SubscriptionLevelResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        public static ResourceType Type { get; } = new ResourceType("Microsoft.Resources", "resourceGroups");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="resourceGroupName"></param>
        public ResourceGroupResourceIdentifier(string subscriptionId, string resourceGroupName)
            : base(new SubscriptionResourceIdentifier(subscriptionId), Type, resourceGroupName)
        {
            ResourceGroupName = resourceGroupName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        public ResourceGroupResourceIdentifier( string resourceId)
        {
            var id = NewResourceIdentifier.Create(resourceId) as ResourceGroupResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            ResourceGroupName = id.ResourceGroupName;
            SubscriptionId = id.SubscriptionId;
        }

        internal override bool IsChild => true;

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

        internal override string ToResourceString()
        {
            return $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}";
        }
    }
}
