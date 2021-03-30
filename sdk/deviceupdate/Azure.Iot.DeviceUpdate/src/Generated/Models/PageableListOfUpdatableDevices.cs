// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.IoT.DeviceUpdate.Models
{
    /// <summary> The list of updatable devices. </summary>
    internal partial class PageableListOfUpdatableDevices
    {
        /// <summary> Initializes a new instance of PageableListOfUpdatableDevices. </summary>
        internal PageableListOfUpdatableDevices()
        {
            Value = new ChangeTrackingList<UpdatableDevices>();
        }

        /// <summary> Initializes a new instance of PageableListOfUpdatableDevices. </summary>
        /// <param name="value"> The collection of pageable items. </param>
        /// <param name="nextLink"> The link to the next page of items. </param>
        internal PageableListOfUpdatableDevices(IReadOnlyList<UpdatableDevices> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The collection of pageable items. </summary>
        public IReadOnlyList<UpdatableDevices> Value { get; }
        /// <summary> The link to the next page of items. </summary>
        public string NextLink { get; }
    }
}
