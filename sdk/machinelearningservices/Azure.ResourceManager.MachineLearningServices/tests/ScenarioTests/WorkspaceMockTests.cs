// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class WorkspaceMockTests : MockTestBase
    {
        public WorkspaceMockTests(bool isAsync) : base(isAsync)
        { }

        [RecordedTest]
        public async Task WorkspaceCrud()
        {
            //var resourceGroup = await GetArmClient().DefaultSubscription.GetResourceGroups().GetAsync("rg");
            var client = GetArmClient();
            var sub = await client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var rgs = sub.Value.GetResourceGroups();
            var resourceGroup = (await rgs.GetAsync("rg")).Value;
            Assert.NotNull(resourceGroup);

            WorkspaceData data = new WorkspaceData()
            {
                Location = "eastus",
                ApplicationInsights = resourceGroup.Id.AppendProviderResource("Microsoft.Insights", "components", Recording.GenerateAssetName("testappinsights")),
                KeyVault = resourceGroup.Id.AppendProviderResource("Microsoft.KeyVault", "vaults", Recording.GenerateAssetName("mltestkv")),
                StorageAccount = resourceGroup.Id.AppendProviderResource("Microsoft.Storage", "storageAccounts", Recording.GenerateAssetName("testsa")),
                Identity = new Identity()
                {
                    Type = ResourceIdentityType.None
                },
            };
            var workspace = await resourceGroup.GetWorkspaces().CreateOrUpdateAsync("ws", data);
            Assert.NotNull(workspace);
        }

        //[RecordedTest]
        //private async Task TestListAsync()
        //{
        //    var listResults = _resourceGroup.GetWorkspaces().ListAsync();
        //    Assert.AreEqual(1, await listResults.CountAsync());
        //}

        //private async Task TestGetAsync()
        //{
        //    var workspace = await _resourceGroup.GetWorkspaces().GetAsync(_workspace.Data.Name);
        //    Assert.NotNull(workspace);
        //    Assert.AreEqual(_workspace.Data.Id, workspace.Value.Data.Id);
        //}

        //private async Task TestUpdateAsync()
        //{
        //    // update via put
        //    var workspaceData = _workspace.Data;
        //    workspaceData.Tags = new Dictionary<string, string> { { "new", "tag" } };
        //    workspaceData.ContainerRegistry = null; // or else "message":"Property id '' at path 'properties.containerRegistry' is invalid. Expect fully qualified resource Id that start with '/subscriptions/{subscriptionId}' or '/providers/{resourceProviderNamespace}/'."
        //    _workspace = (await _resourceGroup.GetWorkspaces().CreateOrUpdateAsync(_workspace.Data.Name, workspaceData)).Value;
        //    Assert.AreEqual("tag", _workspace.Data.Tags["new"]);

        //    // update via patch
        //    var update = new WorkspaceUpdateParameters();
        //    update.Tags.Add("newer", "tag");
        //    await _workspace.UpdateAsync(update);
        //    _workspace = await _workspace.GetAsync();
        //    Assert.AreEqual("tag", _workspace.Data.Tags["newer"]);
        //}

        //private async Task TestRemoveAsync()
        //{
        //    var workspace = (await _resourceGroup.GetWorkspaces().GetAsync(_workspace.Data.Name)).Value;
        //    await workspace.DeleteAsync();
        //    var workspaces = _resourceGroup.GetWorkspaces().ListAsync();
        //    Assert.AreEqual(0, await workspaces.CountAsync());
        //}
    }
}
