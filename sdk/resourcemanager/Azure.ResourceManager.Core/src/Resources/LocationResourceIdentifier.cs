// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LocationResourceIdentifier : SubscriptionLevelResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        public static ResourceType Type { get; } = new ResourceType("Microsoft.Resources", "locations");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="location"></param>
        public LocationResourceIdentifier(string subscriptionId, LocationData location) 
            : base(new SubscriptionResourceIdentifier(subscriptionId), Type, location.Name)
        {
            Location = location;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        public LocationResourceIdentifier(string resourceId)
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

        internal override bool IsChild => true;

        /// <summary>
        /// 
        /// </summary>
        public LocationData Location { get; internal set; }

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

        internal override string ToResourceString()
        {
            return $"/subscriptions/{SubscriptionId}/locations/{Location.Name}";
        }
    }
}
