# Migrating from old to preview management sdk.

There are several differences between the old sdk and this preview. Here's an example of how to create a Virtual Machine with both SDKs:

## Create a Virtual Machine example

### Import the namespaces
#### Old (Microsoft.Azure.Management._)
```C#
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
```
#### New (Azure.Azure.ResourceManager._ Preview)
```C#
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Network;
using System;
using System.Threading.Tasks;
```

### Create a Resource Group
#### Old
```C#
var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
var resourceClient = new ResourcesManagementClient(subscriptionId, new DefaultAzureCredential());

var resourceGroups = resourceClient.ResourceGroups;
var location = "westus2";
var resourceGroupName = "QuickStartRG";
var resourceGroup = new ResourceGroup(location);
resourceGroup = await resourceGroups.CreateOrUpdateAsync(resourceGroupName, resourceGroup);
```
#### New
```C#
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

Location location = Location.WestUS2;
string rgName = "QuickStartRG";
ResourceGroup resourceGroup = await rgContainer.Construct(location).CreateOrUpdateAsync(rgName)
```

As you can see, authentication is now handled by Azure.Identity, you can get the default subscription trought the `ArmClient` and the Resource Group is created trought a container. Also, public locations are provided trought the `Location` object, but it can be specified as a string as well.

### Setting up the clients
#### Old
```C#
string vmName = "quickstartvm";
var computeClient = new ComputeManagementClient(subscriptionId, new DefaultAzureCredential());
var networkClient = new NetworkManagementClient(subscriptionId, new DefaultAzureCredential());
var virtualNetworksClient = networkClient.VirtualNetworks;
var networkInterfaceClient = networkClient.NetworkInterfaces;
var publicIpAddressClient = networkClient.PublicIPAddresses;
var availabilitySetsClient = computeClient.AvailabilitySets;
var virtualMachinesClient = computeClient.VirtualMachines;
```
#### New
No need to create more clients, everything can be done trought the `resourceGroup` object.

### Create an Availability Set
```C#
var availabilitySet = new AvailabilitySet(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new Azure.ResourceManager.Compute.Models.Sku() { Name = "Aligned" }
};
availabilitySet = await availabilitySetsClient.CreateOrUpdateAsync(resourceGroupName, vmName + "_aSet", availabilitySet);
```

### Create an IP Address
```C#
var ipAddress = new PublicIPAddress()
{
    PublicIPAddressVersion = Azure.ResourceManager.Network.Models.IPVersion.IPv4,
    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
    Location = location,
};

ipAddress = await publicIpAddressClient.StartCreateOrUpdate(resourceGroupName, vmName + "_ip", ipAddress)
    .WaitForCompletionAsync();
```

### Create a Virtual Network
```C#
var vnet = new VirtualNetwork()
{
    Location = location,
    AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16" } },
    Subnets = new List<Subnet>()
    {
        new Subnet()
        {
            Name = "mySubnet",
            AddressPrefix = "10.0.0.0/24",
        }
    },
};
vnet = await virtualNetworksClient
    .StartCreateOrUpdate(resourceGroupName, vmName + "_vent", vnet)
    .WaitForCompletionAsync();
```

### Create a Network Interface
```C#
var nic = new NetworkInterface()
{
    Location = location,
    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
    {
        new NetworkInterfaceIPConfiguration()
        {
            Name = "Primary",
            Primary = true,
            Subnet = new Subnet() { Id = vnet.Subnets.First().Id },
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            PublicIPAddress = new PublicIPAddress() { Id = ipAddress.Id }
        }
    }
};
nic = await networkInterfaceClient
    .StartCreateOrUpdate(resourceGroupName, vmName + "_nic", nic)
    .WaitForCompletionAsync();
```

### Create a Virtual Machine
```C#
string adminUsername = "<AdminUsername>";
string adminPassword = "<AdminPassword>";

var vm = new VirtualMachine(location)
{
    NetworkProfile = new Azure.ResourceManager.Compute.Models.NetworkProfile { NetworkInterfaces = new[] { new NetworkInterfaceReference() { Id = nic.Id } } },
    OsProfile = new OSProfile
    {
        ComputerName = vmName,
        AdminUsername = adminUsername,
        AdminPassword = adminPassword,
        LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVMAgent = true }
    },
    StorageProfile = new StorageProfile()
    {
        ImageReference = new ImageReference()
        {
            Offer = "UbuntuServer",
            Publisher = "Canonical",
            Sku = "18.04-LTS",
            Version = "latest"
        },
        DataDisks = new List<DataDisk>()
    },
    HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
    AvailabilitySet = new Azure.ResourceManager.Compute.Models.SubResource() { Id = availabilitySet.Id }
};

var operation = await virtualMachinesClient.StartCreateOrUpdateAsync(resourceGroupName, vmName, vm);
var result = (await operation.WaitForCompletionAsync()).Value;
Console.WriteLine("VM ID: " + result.Id);
```

## Create a Virtual Machine using this preview libraries

```C#

```