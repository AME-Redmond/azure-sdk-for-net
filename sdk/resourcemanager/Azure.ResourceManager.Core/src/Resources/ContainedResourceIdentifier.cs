// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ContainedResourceIdentifier : NewResourceIdentifier
    {
        internal ContainedResourceIdentifier()
        {
        }

        internal ContainedResourceIdentifier(NewResourceIdentifier containerId, ResourceType resourceType, string name) : base(resourceType, name)
        {
            Parent = containerId;
            IsChild = containerId.ResourceType.IsParentOf(resourceType);
        }

        /// <summary>
        /// 
        /// </summary>
        public NewResourceIdentifier Parent { get; internal set; }

        internal virtual bool IsChild { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public override bool TryGetContainerId(out NewResourceIdentifier containerId)
        {
            containerId = Parent;
            return true;
        }

        internal override bool TryGetResourceAncestor<T>(out T result, Func<T, bool> filter = null)
        {
            var target = this as T;
            if ((!(target is null)) && (filter is null || (filter(target))))
            {
                result = target;
                return true;
            }

            return Parent.TryGetResourceAncestor(out result, filter);
        }

        internal override string ToResourceString()
        {
            StringBuilder builder = new StringBuilder(Parent.ToResourceString());
            if (IsChild)
            {
                builder.Append($"/{ResourceType.Types.Last()}");
                if (!string.IsNullOrWhiteSpace(Name))
                    builder.Append($"/{Name}");
            }
            else
            {
                builder.Append($"/providers/{ResourceType.Namespace}/{ResourceType.Type}/{Name}");
            }

            return builder.ToString();
        }
    }
}
