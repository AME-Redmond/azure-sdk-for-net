// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantLevelResourceIdentifier : XResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="name"></param>
        internal TenantLevelResourceIdentifier(ResourceType resourceType, string name) : base(resourceType, name)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerNamespace"></param>
        /// <param name="typeName"></param>
        /// <param name="resourceName"></param>
        public TenantLevelResourceIdentifier(string providerNamespace, string typeName, string resourceName) 
            : this (new ResourceType(providerNamespace, typeName), resourceName)
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal override bool TryGetResourceAncestor<T>(out T result, Func<T, bool> filter = null)
        {
            var target = this as T;
            if ((!(target is null)) && (filter is null || (filter(target))))
            {
                result = target;
                return true;
            }

            result = default(T);
            return false;
        }

        internal override string ToResourceString()
        {
            return $"/providers/{ResourceType.Namespace}/{ResourceType.Type}/{Name}";
        }
    }
}
