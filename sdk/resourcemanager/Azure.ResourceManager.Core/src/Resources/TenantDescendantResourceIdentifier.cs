// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantDescendantResourceIdentifier : ContainedResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childTypeName"></param>
        /// <param name="childResourceName"></param>
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
    }
}
