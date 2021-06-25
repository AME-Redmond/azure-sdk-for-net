// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class MockTestBase : RecordedTestBase<MockTestEnvironment>
    {
        public MockTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        protected ArmClient GetArmClient(ArmClientOptions clientOptions = default)
        {
            var options = InstrumentClientOptions(clientOptions ?? new ArmClientOptions());

            return new ArmClient(
                TestEnvironment.SubscriptionId,
                new Uri("https://localhost:8443/"), //new Uri(TestEnvironment.ResourceManagerUrl),
                TestEnvironment.Credential,
                options);
        }

        public override void StopTestRecording()
        {
            ValidateClientInstrumentation = false;
            base.StopTestRecording();
        }
    }
}
