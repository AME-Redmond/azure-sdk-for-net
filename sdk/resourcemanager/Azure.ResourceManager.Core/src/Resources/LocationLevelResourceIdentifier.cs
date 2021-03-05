// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationLevelResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceName"></param>
        public LocationLevelResourceIdentifier(LocationResourceIdentifier location, ResourceType resourceType, string resourceName)
            : base(location, resourceType, resourceName)
        {
            Location = location.Name;
            SubscriptionId = location.SubscriptionId;
        }

        /// <summary>
        /// Create a child resource of an existing location level resource
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceName"></param>
        public LocationLevelResourceIdentifier(LocationLevelResourceIdentifier parent, string resourceType, string resourceName)
            : base(parent, new ResourceType(parent.ResourceType, resourceType), resourceName)
        {
            Location = parent.Location;
            SubscriptionId = parent.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="extensionResourceType"></param>
        /// <param name="extensionResourceName"></param>
        public LocationLevelResourceIdentifier(LocationLevelResourceIdentifier target, ResourceType extensionResourceType, string extensionResourceName)
            : base(target, extensionResourceType, extensionResourceName)
        {
            Location = target.Location;
            SubscriptionId = target.SubscriptionId;
        }

        /// <summary>
        /// 
        /// </summary>
        public LocationData Location { get; }

        /// <summary>
        /// 
        /// </summary>
        public string SubscriptionId { get; }
    }
}
