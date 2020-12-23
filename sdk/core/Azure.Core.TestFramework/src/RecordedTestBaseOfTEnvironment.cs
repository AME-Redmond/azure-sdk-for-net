// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.Pipeline;
using System;

namespace Azure.Core.TestFramework
{
#pragma warning disable SA1649 // File name should match first type name
    public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
    {
        protected ResourceGroupCleanupPolicy CleanupPolicy { get; set; }
        protected RecordedTestBase(bool isAsync) : base(isAsync)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        protected RecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        public override void StartTestRecording()
        {
            // Set the TestEnvironment Mode here so that any Mode changes in RecordedTestBase are picked up here also.
            TestEnvironment.Mode = Mode;

            base.StartTestRecording();
            TestEnvironment.SetRecording(Recording);
        }

        protected ResourceGroupClient GetResourceManagementClient()
        {
            var options = InstrumentClientOptions(new CleanUpClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);
            return new ResourceGroupClient(
                TestEnvironment.SubscriptionId, 
                TestEnvironment.Credential, 
                options);

            /*return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);*/
        }

        protected async Task CleanupResourceGroupsAsync()
        {
            if (CleanupPolicy != null && Mode != RecordedTestMode.Playback)
            {
                var resourceGroupsClient = new ResourcesManagementClient(
                    TestEnvironment.SubscriptionId,
                    TestEnvironment.Credential,
                    new ResourcesManagementClientOptions()).ResourceGroups;
                foreach (var resourceGroup in CleanupPolicy.ResourceGroupsCreated)
                {
                    await resourceGroupsClient.StartDeleteAsync(resourceGroup);
                }
            }
        }
        public TEnvironment TestEnvironment { get; }

        public class ResourceGroupClient
        {
            private readonly HttpPipeline _pipeline;
            private readonly Uri _endpoint;
            private readonly string _subscriptionId;

            internal ResourceGroupClient(string subscriptionId, TokenCredential tokenCredential, ClientOptions options)
            {
                _endpoint = new Uri("https://management.azure.com");;
                if (subscriptionId == null)
                {
                    throw new ArgumentNullException(nameof(subscriptionId));
                }
                _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, $"{_endpoint}/.default"));
                _subscriptionId = subscriptionId;
            }

            public Response<ResourceGroup> CreateOrUpdate(string resourceGroupName, ResourceGroup parameters, CancellationToken cancellationToken = default)
            {
                if (resourceGroupName == null)
                {
                    throw new ArgumentNullException(nameof(resourceGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                using var message = CreateCreateOrUpdateRequest(resourceGroupName, parameters);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                    case 201:
                        {
                            ResourceGroup value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = ResourceGroup.DeserializeResourceGroup(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
        }

        private class CleanUpClientOptions : ClientOptions 
        {
        }
    }
}