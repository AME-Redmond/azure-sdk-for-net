// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Resources
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

        internal override bool IsChild => true;

        /// <summary>
        /// 
        /// </summary>
        public string ResourceGroupName { get; }

        internal override string ToResourceString()
        {
            return $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}";
        }
    }
}
