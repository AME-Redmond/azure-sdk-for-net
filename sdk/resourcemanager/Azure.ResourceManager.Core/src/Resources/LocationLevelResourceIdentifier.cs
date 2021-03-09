// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationLevelResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        public LocationLevelResourceIdentifier(string resourceId)
        {
            var id = NewResourceIdentifier.Create(resourceId) as LocationLevelResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            Location = id.Location;
            SubscriptionId = id.SubscriptionId;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public override bool TryGetLocation(out LocationData location)
        {
            location = Location;
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
