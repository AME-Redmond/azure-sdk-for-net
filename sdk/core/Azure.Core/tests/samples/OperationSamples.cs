// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class OperationSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task OperationCompletion()
        {
            #region Snippet:OperationCompletion
            // create a client
            SecretClient client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            // Start the operation
            DeleteSecretOperation operation = await client.StartDeleteSecretAsync("SecretName");

            Response<DeletedSecret> response = await operation.WaitForCompletionAsync();
            DeletedSecret value = response.Value;

            Console.WriteLine(value.Name);
            Console.WriteLine(value.ScheduledPurgeDate);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task OperationUpdateStatus()
        {
            // create a client
            SecretClient client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            #region Snippet:OperationUpdateStatus
            // Start the operation
            DeleteSecretOperation operation = await client.StartDeleteSecretAsync("SecretName");

            await operation.UpdateStatusAsync();

            // HasCompleted indicates if operation has completed successfully or otherwise
            Console.WriteLine(operation.HasCompleted);
            // HasValue indicated is operation Value is available, for some operations it can return true even when operation
            // hasn't completed yet.
            Console.WriteLine(operation.HasValue);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetValuesAsyncSample()
        {
            #region Snippet:PageableOperationGetValuesAsync
            // create a client
            var client = new TextAnalyticsClient(new Uri("http://example.com"), new DefaultAzureCredential());
            var document = new List<string>() { "document with information" };

            // Start the operation
            AnalyzeHealthcareEntitiesOperation healthOperation = client.StartAnalyzeHealthcareEntities(document);

            await healthOperation.WaitForCompletionAsync();

            await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.GetValuesAsync())
            {
                foreach (HealthcareEntity entity in documentsInPage[0].Entities)
                {
                    Console.WriteLine($"    Entity: {entity.Text}");
                }
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetValuesSample()
        {
            #region Snippet:PageableOperationGetValues
            // create a client
            var client = new TextAnalyticsClient(new Uri("http://example.com"), new DefaultAzureCredential());
            var document = new List<string>() { "document with information" };

            // Start the operation
            AnalyzeHealthcareEntitiesOperation healthOperation = client.StartAnalyzeHealthcareEntities(document);

            await healthOperation.WaitForCompletionAsync();

            foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.GetValues())
            {
                foreach (HealthcareEntity entity in documentsInPage[0].Entities)
                {
                    Console.WriteLine($"    Entity: {entity.Text}");
                }
            }
            #endregion
        }
    }
}
