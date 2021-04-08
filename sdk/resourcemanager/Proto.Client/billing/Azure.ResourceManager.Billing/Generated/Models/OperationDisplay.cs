// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> The object that represents the operation. </summary>
    public partial class OperationDisplay
    {
        /// <summary> Initializes a new instance of OperationDisplay. </summary>
        internal OperationDisplay()
        {
        }

        /// <summary> Initializes a new instance of OperationDisplay. </summary>
        /// <param name="provider"> Service provider: Microsoft.Billing. </param>
        /// <param name="resource"> Resource on which the operation is performed such as invoice and billing subscription. </param>
        /// <param name="operation"> Operation type such as read, write and delete. </param>
        internal OperationDisplay(string provider, string resource, string operation)
        {
            Provider = provider;
            Resource = resource;
            Operation = operation;
        }

        /// <summary> Service provider: Microsoft.Billing. </summary>
        public string Provider { get; }
        /// <summary> Resource on which the operation is performed such as invoice and billing subscription. </summary>
        public string Resource { get; }
        /// <summary> Operation type such as read, write and delete. </summary>
        public string Operation { get; }
    }
}
