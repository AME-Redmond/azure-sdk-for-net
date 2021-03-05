// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core.Resources
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

        internal override bool IsChild => true;

        /// <summary>
        /// 
        /// </summary>
        public LocationData Location { get; }

        internal override string ToResourceString()
        {
            return $"/subscriptions/{SubscriptionId}/locations/{Location.Name}";
        }
    }
}
