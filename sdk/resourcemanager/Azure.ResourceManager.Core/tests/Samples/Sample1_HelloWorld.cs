﻿using System;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Sample1_HelloWorld
    {
        public Sample1_HelloWorld()
        {
        }

        [Test]
        public void GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_DefaultSubscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_DefaultSubscription
        }

        [Test]
        public void GettingSpecificSubscription()
        {
            #region Snippet:Hello_World_SpecificSubscription
            string subscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetSubscriptions().Get(subscriptionId);
            Console.WriteLine("Got subscription: " + subscription.Data.DisplayName);
            #endregion Snippet:Hello_World_SpecificSubscription
        }

        [Test]
        public void RetrieveResourceGroupContainer()
        {
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #region Snippet:Hello_World_ResourceGroupContainer
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_ResourceGroupContainer
        }
    }
}
