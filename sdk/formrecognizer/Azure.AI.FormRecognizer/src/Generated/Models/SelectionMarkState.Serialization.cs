// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class SelectionMarkStateExtensions
    {
        public static string ToSerialString(this SelectionMarkState value) => value switch
        {
            SelectionMarkState.Selected => "selected",
            SelectionMarkState.Unselected => "unselected",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SelectionMarkState value.")
        };

        public static SelectionMarkState ToSelectionMarkState(this string value)
        {
            if (string.Equals(value, "selected", StringComparison.InvariantCultureIgnoreCase)) return SelectionMarkState.Selected;
            if (string.Equals(value, "unselected", StringComparison.InvariantCultureIgnoreCase)) return SelectionMarkState.Unselected;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SelectionMarkState value.");
        }
    }
}
