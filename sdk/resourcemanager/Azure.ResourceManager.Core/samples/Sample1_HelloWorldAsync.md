# Example: Getting a susbcription

>Note: Before getting started with the samples, make sure to go trought [prerequisites guide](<--./docs/Prerequistes.md-->).

The following code shows how to get the default subscription:

```csharp Snippet:HelloWorld_GetDefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
Console.WriteLine(subscription.Id);
```

It is possible to get an specific subscription as it's shown next:

``` csharp Snippet:HelloWorld_GetSpecificSubscription
string subscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.GetSubscriptions().TryGetAsync(subscriptionId);
Console.WriteLine(subscription.Id);
```

With the `Async` keyword at the end of methods that perform API calls, it is possible to differentiate the asynchronous and synchronous variants of any method.

From here, it is possible to get the resource groups from the retrieved subscription:

```csharp Snippet:HelloWorld_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
```

## Next stepts
Take a look at the [Managing Resource Groups](<--ManagingResourceGroups.md-->) samples.