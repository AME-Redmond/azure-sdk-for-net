// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Cdn
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ValidateOperations.
    /// </summary>
    public static partial class ValidateOperationsExtensions
    {
            /// <summary>
            /// Validate a Secret in the profile.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='secretSource'>
            /// The secret source.
            /// </param>
            /// <param name='secretType'>
            /// The secret type. Possible values include: 'UrlSigningKey',
            /// 'ManagedCertificate', 'CustomerCertificate'
            /// </param>
            public static ValidateSecretOutput SecretMethod(this IValidateOperations operations, ResourceReference secretSource, string secretType)
            {
                return operations.SecretMethodAsync(secretSource, secretType).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Validate a Secret in the profile.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='secretSource'>
            /// The secret source.
            /// </param>
            /// <param name='secretType'>
            /// The secret type. Possible values include: 'UrlSigningKey',
            /// 'ManagedCertificate', 'CustomerCertificate'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ValidateSecretOutput> SecretMethodAsync(this IValidateOperations operations, ResourceReference secretSource, string secretType, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SecretMethodWithHttpMessagesAsync(secretSource, secretType, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
