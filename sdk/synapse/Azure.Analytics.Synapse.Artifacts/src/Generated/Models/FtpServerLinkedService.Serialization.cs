// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    public partial class FtpServerLinkedService : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            if (Optional.IsDefined(ConnectVia))
            {
                writer.WritePropertyName("connectVia");
                writer.WriteObjectValue(ConnectVia);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsCollectionDefined(Parameters))
            {
                writer.WritePropertyName("parameters");
                writer.WriteStartObject();
                foreach (var item in Parameters)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(Annotations))
            {
                writer.WritePropertyName("annotations");
                writer.WriteStartArray();
                foreach (var item in Annotations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("typeProperties");
            writer.WriteStartObject();
            writer.WritePropertyName("host");
            writer.WriteObjectValue(Host);
            if (Optional.IsDefined(Port))
            {
                writer.WritePropertyName("port");
                writer.WriteObjectValue(Port);
            }
            if (Optional.IsDefined(AuthenticationType))
            {
                writer.WritePropertyName("authenticationType");
                writer.WriteStringValue(AuthenticationType.Value.ToString());
            }
            if (Optional.IsDefined(UserName))
            {
                writer.WritePropertyName("userName");
                writer.WriteObjectValue(UserName);
            }
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("password");
                writer.WriteObjectValue(Password);
            }
            if (Optional.IsDefined(EncryptedCredential))
            {
                writer.WritePropertyName("encryptedCredential");
                writer.WriteObjectValue(EncryptedCredential);
            }
            if (Optional.IsDefined(EnableSsl))
            {
                writer.WritePropertyName("enableSsl");
                writer.WriteObjectValue(EnableSsl);
            }
            if (Optional.IsDefined(EnableServerCertificateValidation))
            {
                writer.WritePropertyName("enableServerCertificateValidation");
                writer.WriteObjectValue(EnableServerCertificateValidation);
            }
            writer.WriteEndObject();
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static FtpServerLinkedService DeserializeFtpServerLinkedService(JsonElement element)
        {
            string type = default;
            Optional<IntegrationRuntimeReference> connectVia = default;
            Optional<string> description = default;
            Optional<IDictionary<string, ParameterSpecification>> parameters = default;
            Optional<IList<object>> annotations = default;
            object host = default;
            Optional<object> port = default;
            Optional<FtpAuthenticationType> authenticationType = default;
            Optional<object> userName = default;
            Optional<SecretBase> password = default;
            Optional<object> encryptedCredential = default;
            Optional<object> enableSsl = default;
            Optional<object> enableServerCertificateValidation = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("connectVia"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    connectVia = IntegrationRuntimeReference.DeserializeIntegrationRuntimeReference(property.Value);
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, ParameterSpecification> dictionary = new Dictionary<string, ParameterSpecification>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, ParameterSpecification.DeserializeParameterSpecification(property0.Value));
                    }
                    parameters = dictionary;
                    continue;
                }
                if (property.NameEquals("annotations"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<object> array = new List<object>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetObject());
                    }
                    annotations = array;
                    continue;
                }
                if (property.NameEquals("typeProperties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("host"))
                        {
                            host = property0.Value.GetObject();
                            continue;
                        }
                        if (property0.NameEquals("port"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            port = property0.Value.GetObject();
                            continue;
                        }
                        if (property0.NameEquals("authenticationType"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            authenticationType = new FtpAuthenticationType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("userName"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            userName = property0.Value.GetObject();
                            continue;
                        }
                        if (property0.NameEquals("password"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            password = SecretBase.DeserializeSecretBase(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("encryptedCredential"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            encryptedCredential = property0.Value.GetObject();
                            continue;
                        }
                        if (property0.NameEquals("enableSsl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            enableSsl = property0.Value.GetObject();
                            continue;
                        }
                        if (property0.NameEquals("enableServerCertificateValidation"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            enableServerCertificateValidation = property0.Value.GetObject();
                            continue;
                        }
                    }
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new FtpServerLinkedService(type, connectVia.Value, description.Value, Optional.ToDictionary(parameters), Optional.ToList(annotations), additionalProperties, host, port.Value, Optional.ToNullable(authenticationType), userName.Value, password.Value, encryptedCredential.Value, enableSsl.Value, enableServerCertificateValidation.Value);
        }
    }
}
