// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Authorization.Models
{
    public partial class RoleAssignment
    {
        internal static RoleAssignment DeserializeRoleAssignment(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            Optional<string> scope = default;
            Optional<string> roleDefinitionId = default;
            Optional<string> principalId = default;
            Optional<PrincipalType> principalType = default;
            Optional<bool> canDelegate = default;
            Optional<string> description = default;
            Optional<string> condition = default;
            Optional<string> conditionVersion = default;
            Optional<DateTimeOffset> createdOn = default;
            Optional<DateTimeOffset> updatedOn = default;
            Optional<string> createdBy = default;
            Optional<string> updatedBy = default;
            Optional<string> delegatedManagedIdentityResourceId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("scope"))
                        {
                            scope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("roleDefinitionId"))
                        {
                            roleDefinitionId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("principalId"))
                        {
                            principalId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("principalType"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            principalType = new PrincipalType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("canDelegate"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            canDelegate = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("description"))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("condition"))
                        {
                            condition = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("conditionVersion"))
                        {
                            conditionVersion = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("createdOn"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            createdOn = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("updatedOn"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            updatedOn = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("createdBy"))
                        {
                            createdBy = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("updatedBy"))
                        {
                            updatedBy = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("delegatedManagedIdentityResourceId"))
                        {
                            delegatedManagedIdentityResourceId = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new RoleAssignment(id.Value, name.Value, type.Value, scope.Value, roleDefinitionId.Value, principalId.Value, Optional.ToNullable(principalType), Optional.ToNullable(canDelegate), description.Value, condition.Value, conditionVersion.Value, Optional.ToNullable(createdOn), Optional.ToNullable(updatedOn), createdBy.Value, updatedBy.Value, delegatedManagedIdentityResourceId.Value);
        }
    }
}
