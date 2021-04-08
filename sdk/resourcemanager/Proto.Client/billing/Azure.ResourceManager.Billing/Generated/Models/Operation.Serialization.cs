// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    public partial class Operation
    {
        internal static Operation DeserializeOperation(JsonElement element)
        {
            Optional<string> name = default;
            Optional<OperationDisplay> display = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("display"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    display = OperationDisplay.DeserializeOperationDisplay(property.Value);
                    continue;
                }
            }
            return new Operation(name.Value, display.Value);
        }
    }
}
