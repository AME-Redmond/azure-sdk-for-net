// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Analytics.Synapse.Monitoring.Models
{
    public partial class SparkJob
    {
        internal static SparkJob DeserializeSparkJob(JsonElement element)
        {
            Optional<string> state = default;
            Optional<string> name = default;
            Optional<string> submitter = default;
            Optional<string> compute = default;
            Optional<string> sparkApplicationId = default;
            Optional<string> livyId = default;
            Optional<IReadOnlyList<string>> timing = default;
            Optional<string> sparkJobDefinition = default;
            Optional<IReadOnlyList<SparkJob>> pipeline = default;
            Optional<string> jobType = default;
            Optional<DateTimeOffset?> submitTime = default;
            Optional<DateTimeOffset?> endTime = default;
            Optional<string> queuedDuration = default;
            Optional<string> runningDuration = default;
            Optional<string> totalDuration = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("state"))
                {
                    state = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("submitter"))
                {
                    submitter = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("compute"))
                {
                    compute = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sparkApplicationId"))
                {
                    sparkApplicationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("livyId"))
                {
                    livyId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timing"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    timing = array;
                    continue;
                }
                if (property.NameEquals("sparkJobDefinition"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        sparkJobDefinition = null;
                        continue;
                    }
                    sparkJobDefinition = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("pipeline"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        pipeline = null;
                        continue;
                    }
                    List<SparkJob> array = new List<SparkJob>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeSparkJob(item));
                    }
                    pipeline = array;
                    continue;
                }
                if (property.NameEquals("jobType"))
                {
                    jobType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("submitTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        submitTime = null;
                        continue;
                    }
                    submitTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("endTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        endTime = null;
                        continue;
                    }
                    endTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("queuedDuration"))
                {
                    queuedDuration = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("runningDuration"))
                {
                    runningDuration = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("totalDuration"))
                {
                    totalDuration = property.Value.GetString();
                    continue;
                }
            }
            return new SparkJob(state.Value, name.Value, submitter.Value, compute.Value, sparkApplicationId.Value, livyId.Value, Optional.ToList(timing), sparkJobDefinition.Value, Optional.ToList(pipeline), jobType.Value, Optional.ToNullable(submitTime), Optional.ToNullable(endTime), queuedDuration.Value, runningDuration.Value, totalDuration.Value);
        }
    }
}
