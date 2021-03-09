// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// New representation of Resource Identifier
    /// </summary>
    public abstract class NewResourceIdentifier
    {
        internal const string ProvidersKey = "providers", SubscriptionsKey = "subscriptions", ResourceGroupsKey = "resourceGroups", LocationsKey = "locations";

        /// <summary>
        /// For internal use only
        /// </summary>
        internal NewResourceIdentifier()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="name"></param>
        internal NewResourceIdentifier(ResourceType resourceType, string name)
        {
            ResourceType = resourceType;
            Name = name;
        }

        internal NewResourceIdentifier(string resourceId)
        {
            var parts = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
            {
                ResourceType = new ResourceType(parts[1], parts[2]);
                Name = parts[3];
            }

            throw new ArgumentException("Not a valid tenant level resource id.", nameof(resourceId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static NewResourceIdentifier Create(string resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            var parts = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count < 2)
                throw new ArgumentException("Not a valid resource id.", nameof(resourceId));
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
            {
                return CreateFromParts(new TenantLevelResourceIdentifier(parts[1], parts[2], parts[3]), parts.Skip(4).ToList());
            }

            if (parts.Count > 1 && string.Equals(parts[0], SubscriptionsKey, StringComparison.InvariantCultureIgnoreCase))
            {
                return CreateFromParts(new SubscriptionResourceIdentifier(parts[1]), parts.Skip(2).ToList());
            }

            throw new ArgumentException("Invalid resource id", nameof(resourceId));
        }

        internal static NewResourceIdentifier CreateFromParts(TenantLevelResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new TenantDescendantResourceIdentifier(parent, new ResourceType(parent.ResourceType, parts[0]), string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new TenantDescendantResourceIdentifier(parent, new ResourceType(parts[1], parts[2]), parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new TenantDescendantResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }

        internal static NewResourceIdentifier CreateFromParts(TenantDescendantResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new TenantDescendantResourceIdentifier(parent, new ResourceType(parent.ResourceType, parts[0]), string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new TenantDescendantResourceIdentifier(parent, new ResourceType(parts[1], parts[2]), parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new TenantDescendantResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }

        internal static NewResourceIdentifier CreateFromParts(SubscriptionResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new SubscriptionLevelResourceIdentifier(parent, new ResourceType(parts[1], parts[2]), parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
            {
                switch (parts[0].ToLowerInvariant())
                {
                    case LocationsKey:
                        return CreateFromParts(new LocationResourceIdentifier(parent.SubscriptionId, parts[1]), parts.Skip(2).ToList());
                    case ResourceGroupsKey:
                        return CreateFromParts(new ResourceGroupResourceIdentifier(parent.SubscriptionId, parts[1]), parts.Skip(2).ToList());
                    default:
                        return CreateFromParts(new SubscriptionLevelResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
                }
            }

            throw new InvalidOperationException("Invalid resource id");
        }

        internal static NewResourceIdentifier CreateFromParts(SubscriptionLevelResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new SubscriptionLevelResourceIdentifier(parent, new ResourceType(parent.ResourceType, parts[0]), string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new SubscriptionLevelResourceIdentifier(parent, new ResourceType(parts[1], parts[2]), parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new SubscriptionLevelResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }

        internal static NewResourceIdentifier CreateFromParts(LocationResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new LocationLevelResourceIdentifier(parent, new ResourceType(parts[1], parts[2]), parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new LocationLevelResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }
        internal static NewResourceIdentifier CreateFromParts(LocationLevelResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new LocationLevelResourceIdentifier(parent, new ResourceType(parent.ResourceType, parts[0]), string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new LocationLevelResourceIdentifier(parent, new ResourceType(parts[1], parts[2]), parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new LocationLevelResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }

        internal static NewResourceIdentifier CreateFromParts(ResourceGroupResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new ResourceGroupLevelResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Skip(4).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }

        internal static NewResourceIdentifier CreateFromParts(ResourceGroupLevelResourceIdentifier parent, IList<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new ResourceGroupLevelResourceIdentifier(parent, parts[0], string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new ResourceGroupLevelResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Skip(4).ToList());
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateFromParts(new ResourceGroupLevelResourceIdentifier(parent, parts[0], parts[1]), parts.Skip(2).ToList());
            throw new InvalidOperationException("Invalid resource id");
        }

        private object lockObject = new object();
        private string _stringValue;

        /// <summary>
        /// 
        /// </summary>
        internal string StringValue
        {
            get
            {
                lock (lockObject)
                {
                    if (_stringValue is null)
                    {
                        _stringValue = ToResourceString();
                    }

                    return _stringValue;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ResourceType ResourceType { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public virtual bool TryGetContainerId(out NewResourceIdentifier containerId)
        {
            return TryGetResourceAncestor(out containerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public virtual bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = default(string);
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public virtual bool TryGetResourceGroupName(out string resourceGroupName)
        {
            resourceGroupName = default(string);
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public virtual bool TryGetLocation(out LocationData location)
        {
            location = default(LocationData);
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal abstract bool TryGetResourceAncestor<T>(out T result, Func<T, bool> filter = null) where T : NewResourceIdentifier;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal abstract string ToResourceString();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return StringValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public static implicit operator string(NewResourceIdentifier other) => other.ToString();
    }
}
