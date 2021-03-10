﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Abstract class for long-running or synchronous applications.
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="OperationsBase"/> to return representing the result of the ArmOperation. </typeparam>
    public abstract class ArmOperation<TOperations> : Operation<TOperations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class.
        /// </summary>
        /// <param name="syncValue"> The <see cref="OperationsBase"/> representing the result of the ArmOperation. </param>
        protected ArmOperation(TOperations syncValue)
        {
            CompletedSynchronously = syncValue != null;
            SyncValue = syncValue;
        }

        /// <summary>
        /// Gets a value indicating whether or not the operation completed synchronously.
        /// </summary>
        protected bool CompletedSynchronously { get; }

        /// <summary>
        /// Gets the <see cref="OperationsBase"/> representing the result of the ArmOperation.
        /// </summary>
        protected TOperations SyncValue { get; }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public ArmResponse<TOperations> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            var pollingInterval = ArmOperationHelpers<TOperations>.DefaultPollingInterval;
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse()) as ArmResponse<TOperations>;
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
