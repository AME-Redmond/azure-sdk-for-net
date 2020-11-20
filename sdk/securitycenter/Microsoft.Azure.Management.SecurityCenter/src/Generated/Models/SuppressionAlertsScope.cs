// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Security.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SuppressionAlertsScope
    {
        /// <summary>
        /// Initializes a new instance of the SuppressionAlertsScope class.
        /// </summary>
        public SuppressionAlertsScope()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SuppressionAlertsScope class.
        /// </summary>
        /// <param name="allOf">All the conditions inside need to be true in
        /// order to suppress the alert</param>
        public SuppressionAlertsScope(IList<ScopeElement> allOf)
        {
            AllOf = allOf;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets all the conditions inside need to be true in order to
        /// suppress the alert
        /// </summary>
        [JsonProperty(PropertyName = "allOf")]
        public IList<ScopeElement> AllOf { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AllOf == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AllOf");
            }
        }
    }
}
