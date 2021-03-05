// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// New representation of Resource Identifier
    /// </summary>
    public abstract class XResourceIdentifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="name"></param>
        internal XResourceIdentifier(ResourceType resourceType, string name)
        {
            ResourceType = resourceType;
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static XResourceIdentifier Parse(string resourceId)
        {
            throw new NotImplementedException();
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
        public virtual ResourceType ResourceType { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public virtual bool TryGetContainerId(out XResourceIdentifier containerId)
        {
            return TryGetResourceAncestor(out containerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        internal abstract bool TryGetResourceAncestor<T>(out T result, Func<T, bool> filter = null) where T : XResourceIdentifier;

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
    }
}
