// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A resource identifier for resources that are children or extensions of a tenant-level resource.
    /// </summary>
    public class TenantDescendantResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantDescendantResourceIdentifier"/> class for a direct child of a tenant resource.
        /// </summary>
        /// <param name="parent">The parent of the resource id.</param>
        /// <param name="childTypeName">The simple type name of the child resource.  It should contain no forward slashes (/). </param>
        /// <param name="childResourceName">The resource name of the child resource.</param>
        public TenantDescendantResourceIdentifier(TenantLevelResourceIdentifier parent, string childTypeName, string childResourceName)
            : base(parent, new ResourceType(parent.ResourceType, childTypeName), childResourceName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childTypeName"></param>
        /// <param name="extensionResourceName"></param>
        public TenantDescendantResourceIdentifier(TenantDescendantResourceIdentifier parent, string childTypeName, string extensionResourceName)
            : base(parent, new ResourceType(parent.ResourceType, childTypeName), extensionResourceName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="extensionResourceType"></param>
        /// <param name="extensionResourceName"></param>
        public TenantDescendantResourceIdentifier(TenantLevelResourceIdentifier target, ResourceType extensionResourceType, string extensionResourceName)
            : base(target, extensionResourceType, extensionResourceName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="extensionResourceType"></param>
        /// <param name="extensionResourceName"></param>
        public TenantDescendantResourceIdentifier(TenantDescendantResourceIdentifier target, ResourceType extensionResourceType, string extensionResourceName)
            : base(target, extensionResourceType, extensionResourceName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        public TenantDescendantResourceIdentifier(string resourceId)
        {
            var id = NewResourceIdentifier.Create(resourceId) as TenantDescendantResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
        }
    }
}
