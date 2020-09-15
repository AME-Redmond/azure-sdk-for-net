// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Automanage
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ConfigurationProfileAssignmentsOperations.
    /// </summary>
    public static partial class ConfigurationProfileAssignmentsOperationsExtensions
    {
            /// <summary>
            /// Creates an association between a VM and Automanage configuration profile
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// Name of the configuration profile assignment. Only default is supported.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update configuration profile
            /// assignment.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            public static ConfigurationProfileAssignment CreateOrUpdate(this IConfigurationProfileAssignmentsOperations operations, string configurationProfileAssignmentName, ConfigurationProfileAssignment parameters, string resourceGroupName, string vmName)
            {
                return operations.CreateOrUpdateAsync(configurationProfileAssignmentName, parameters, resourceGroupName, vmName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates an association between a VM and Automanage configuration profile
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// Name of the configuration profile assignment. Only default is supported.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update configuration profile
            /// assignment.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConfigurationProfileAssignment> CreateOrUpdateAsync(this IConfigurationProfileAssignmentsOperations operations, string configurationProfileAssignmentName, ConfigurationProfileAssignment parameters, string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(configurationProfileAssignmentName, parameters, resourceGroupName, vmName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get information about a configuration profile assignment
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// The configuration profile assignment name.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            public static ConfigurationProfileAssignment Get(this IConfigurationProfileAssignmentsOperations operations, string resourceGroupName, string configurationProfileAssignmentName, string vmName)
            {
                return operations.GetAsync(resourceGroupName, configurationProfileAssignmentName, vmName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get information about a configuration profile assignment
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// The configuration profile assignment name.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConfigurationProfileAssignment> GetAsync(this IConfigurationProfileAssignmentsOperations operations, string resourceGroupName, string configurationProfileAssignmentName, string vmName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, configurationProfileAssignmentName, vmName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a configuration profile assignment
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// Name of the configuration profile assignment
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            public static void Delete(this IConfigurationProfileAssignmentsOperations operations, string resourceGroupName, string configurationProfileAssignmentName, string vmName)
            {
                operations.DeleteAsync(resourceGroupName, configurationProfileAssignmentName, vmName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a configuration profile assignment
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// Name of the configuration profile assignment
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IConfigurationProfileAssignmentsOperations operations, string resourceGroupName, string configurationProfileAssignmentName, string vmName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, configurationProfileAssignmentName, vmName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get list of configuration profile assignments
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            public static IEnumerable<ConfigurationProfileAssignment> List(this IConfigurationProfileAssignmentsOperations operations, string resourceGroupName)
            {
                return operations.ListAsync(resourceGroupName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get list of configuration profile assignments
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<ConfigurationProfileAssignment>> ListAsync(this IConfigurationProfileAssignmentsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get list of configuration profile assignments under a given subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IEnumerable<ConfigurationProfileAssignment> ListBySubscription(this IConfigurationProfileAssignmentsOperations operations)
            {
                return operations.ListBySubscriptionAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get list of configuration profile assignments under a given subscription
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<ConfigurationProfileAssignment>> ListBySubscriptionAsync(this IConfigurationProfileAssignmentsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates an association between a VM and Automanage configuration profile
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// Name of the configuration profile assignment. Only default is supported.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update configuration profile
            /// assignment.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            public static ConfigurationProfileAssignment BeginCreateOrUpdate(this IConfigurationProfileAssignmentsOperations operations, string configurationProfileAssignmentName, ConfigurationProfileAssignment parameters, string resourceGroupName, string vmName)
            {
                return operations.BeginCreateOrUpdateAsync(configurationProfileAssignmentName, parameters, resourceGroupName, vmName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates an association between a VM and Automanage configuration profile
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='configurationProfileAssignmentName'>
            /// Name of the configuration profile assignment. Only default is supported.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the create or update configuration profile
            /// assignment.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name.
            /// </param>
            /// <param name='vmName'>
            /// The name of the virtual machine.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ConfigurationProfileAssignment> BeginCreateOrUpdateAsync(this IConfigurationProfileAssignmentsOperations operations, string configurationProfileAssignmentName, ConfigurationProfileAssignment parameters, string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(configurationProfileAssignmentName, parameters, resourceGroupName, vmName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}