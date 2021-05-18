﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public partial class LocationData : IEquatable<LocationData>, IComparable<LocationData>
    {
        /// <summary> The display name of the location and its region. </summary>
        public string RegionalDisplayName { get; }
        /// <summary> Metadata of the location, such as lat/long, paired region, and others. </summary>
        public LocationMetadata Metadata { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationData"/> class.
        /// </summary>
        private LocationData()
        {
        }

        /// <summary>
        /// Gets a location name consisting of only lowercase characters without white spaces or any separation character between words, e.g. "westus".
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a location display name consisting of titlecase words or alphanumeric characters separated by whitespaces, e.g. "West US"
        /// </summary>
        public string DisplayName { get; private set; }
    }
}
