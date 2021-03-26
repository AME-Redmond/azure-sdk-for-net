using System.Runtime.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Identity;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class GenericResourceTests : ResourceManagerTestBase
    {
        private string _rgName;

        private readonly string _location = "southcentralus";

        public GenericResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public void LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            var subscriptionOperations = GlobalClient.GetSubscriptionOperations(SessionEnvironment.SubscriptionId);
            _ = subscriptionOperations.GetResourceGroupContainer().Construct(_location).StartCreateOrUpdateAsync(_rgName).ConfigureAwait(false).GetAwaiter().GetResult().Value;
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public void GetGenerics()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            _ = GetArmClient(options); // setup providers client
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            var subOp = Client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsConfirmException()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = Client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            try
            {
                await genericResourceOperations.GetAsync();
                Assert.Fail("No RequestFailedException thrown");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(ex.Status, 404);
            }
        }

        [TestCase]
        [RecordedTest]
        public void GetGenericsBadNameSpace()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.NotAValidNameSpace123/availabilitySets/testavset";
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = Client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await genericResourceOperations.GetAsync());
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadApiVersion()
        {
            ResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            options.ApiVersions.SetApiVersion(rgid.Type, "1500-10-10");
            var client = GetArmClient(options);
            var subOp = client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            try
            {
                await genericResourceOperations.GetAsync();
                Assert.Fail("No RequestFailedException thrown");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsTrue(ex.Message.Contains("InvalidApiVersionParameter"));
            }
        }
    }
}
