// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Get VPN client connection health detail per P2S client connection of the virtual network gateway in the specified resource group. </summary>
    public partial class VirtualNetworkGatewaysGetVpnclientConnectionHealthOperation : Operation<VpnClientConnectionHealthDetailListResult>, IOperationSource<VpnClientConnectionHealthDetailListResult>
    {
        private readonly ArmOperationHelpers<VpnClientConnectionHealthDetailListResult> _operation;

        /// <summary> Initializes a new instance of VirtualNetworkGatewaysGetVpnclientConnectionHealthOperation for mocking. </summary>
        protected VirtualNetworkGatewaysGetVpnclientConnectionHealthOperation()
        {
        }

        internal VirtualNetworkGatewaysGetVpnclientConnectionHealthOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<VpnClientConnectionHealthDetailListResult>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualNetworkGatewaysGetVpnclientConnectionHealthOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VpnClientConnectionHealthDetailListResult Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VpnClientConnectionHealthDetailListResult>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VpnClientConnectionHealthDetailListResult>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VpnClientConnectionHealthDetailListResult IOperationSource<VpnClientConnectionHealthDetailListResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VpnClientConnectionHealthDetailListResult.DeserializeVpnClientConnectionHealthDetailListResult(document.RootElement);
        }

        async ValueTask<VpnClientConnectionHealthDetailListResult> IOperationSource<VpnClientConnectionHealthDetailListResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VpnClientConnectionHealthDetailListResult.DeserializeVpnClientConnectionHealthDetailListResult(document.RootElement);
        }
    }
}
