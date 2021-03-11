// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    /// <summary> An invoice. </summary>
    public partial class Invoice : Resource
    {
        /// <summary> Initializes a new instance of Invoice. </summary>
        public Invoice()
        {
            Documents = new ChangeTrackingList<Document>();
            Payments = new ChangeTrackingList<PaymentProperties>();
            RebillDetails = new ChangeTrackingDictionary<string, RebillDetails>();
        }

        /// <summary> Initializes a new instance of Invoice. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="dueDate"> The due date for the invoice. </param>
        /// <param name="invoiceDate"> The date when the invoice was generated. </param>
        /// <param name="status"> The current status of the invoice. </param>
        /// <param name="amountDue"> The amount due as of now. </param>
        /// <param name="azurePrepaymentApplied"> The amount of Azure prepayment applied to the charges. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="billedAmount"> The total charges for the invoice billing period. </param>
        /// <param name="creditAmount"> The total refund for returns and cancellations during the invoice billing period. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="freeAzureCreditApplied"> The amount of free Azure credits applied to the charges. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="subTotal"> The pre-tax amount due. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="taxAmount"> The amount of tax charged for the billing period. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="totalAmount"> The amount due when the invoice was generated. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="invoicePeriodStartDate"> The start date of the billing period for which the invoice is generated. </param>
        /// <param name="invoicePeriodEndDate"> The end date of the billing period for which the invoice is generated. </param>
        /// <param name="invoiceType"> Invoice type. </param>
        /// <param name="isMonthlyInvoice"> Specifies if the invoice is generated as part of monthly invoicing cycle or not. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </param>
        /// <param name="billingProfileId"> The ID of the billing profile for which the invoice is generated. </param>
        /// <param name="billingProfileDisplayName"> The name of the billing profile for which the invoice is generated. </param>
        /// <param name="purchaseOrderNumber"> An optional purchase order number for the invoice. </param>
        /// <param name="documents"> List of documents available to download such as invoice and tax receipt. </param>
        /// <param name="payments"> List of payments. </param>
        /// <param name="rebillDetails"> Rebill details for an invoice. </param>
        /// <param name="documentType"> The type of the document. </param>
        /// <param name="billedDocumentId"> The Id of the active invoice which is originally billed after this invoice was voided. This field is applicable to the void invoices only. </param>
        /// <param name="creditForDocumentId"> The Id of the invoice which got voided and this credit note was issued as a result. This field is applicable to the credit notes only. </param>
        /// <param name="subscriptionId"> The ID of the subscription for which the invoice is generated. </param>
        internal Invoice(string id, string name, string type, DateTimeOffset? dueDate, DateTimeOffset? invoiceDate, InvoiceStatus? status, Amount amountDue, Amount azurePrepaymentApplied, Amount billedAmount, Amount creditAmount, Amount freeAzureCreditApplied, Amount subTotal, Amount taxAmount, Amount totalAmount, DateTimeOffset? invoicePeriodStartDate, DateTimeOffset? invoicePeriodEndDate, InvoiceType? invoiceType, bool? isMonthlyInvoice, string billingProfileId, string billingProfileDisplayName, string purchaseOrderNumber, IReadOnlyList<Document> documents, IReadOnlyList<PaymentProperties> payments, IReadOnlyDictionary<string, RebillDetails> rebillDetails, InvoiceDocumentType? documentType, string billedDocumentId, string creditForDocumentId, string subscriptionId) : base(id, name, type)
        {
            DueDate = dueDate;
            InvoiceDate = invoiceDate;
            Status = status;
            AmountDue = amountDue;
            AzurePrepaymentApplied = azurePrepaymentApplied;
            BilledAmount = billedAmount;
            CreditAmount = creditAmount;
            FreeAzureCreditApplied = freeAzureCreditApplied;
            SubTotal = subTotal;
            TaxAmount = taxAmount;
            TotalAmount = totalAmount;
            InvoicePeriodStartDate = invoicePeriodStartDate;
            InvoicePeriodEndDate = invoicePeriodEndDate;
            InvoiceType = invoiceType;
            IsMonthlyInvoice = isMonthlyInvoice;
            BillingProfileId = billingProfileId;
            BillingProfileDisplayName = billingProfileDisplayName;
            PurchaseOrderNumber = purchaseOrderNumber;
            Documents = documents;
            Payments = payments;
            RebillDetails = rebillDetails;
            DocumentType = documentType;
            BilledDocumentId = billedDocumentId;
            CreditForDocumentId = creditForDocumentId;
            SubscriptionId = subscriptionId;
        }

        /// <summary> The due date for the invoice. </summary>
        public DateTimeOffset? DueDate { get; }
        /// <summary> The date when the invoice was generated. </summary>
        public DateTimeOffset? InvoiceDate { get; }
        /// <summary> The current status of the invoice. </summary>
        public InvoiceStatus? Status { get; }
        /// <summary> The amount due as of now. </summary>
        public Amount AmountDue { get; }
        /// <summary> The amount of Azure prepayment applied to the charges. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public Amount AzurePrepaymentApplied { get; }
        /// <summary> The total charges for the invoice billing period. </summary>
        public Amount BilledAmount { get; }
        /// <summary> The total refund for returns and cancellations during the invoice billing period. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public Amount CreditAmount { get; }
        /// <summary> The amount of free Azure credits applied to the charges. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public Amount FreeAzureCreditApplied { get; }
        /// <summary> The pre-tax amount due. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public Amount SubTotal { get; }
        /// <summary> The amount of tax charged for the billing period. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public Amount TaxAmount { get; }
        /// <summary> The amount due when the invoice was generated. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public Amount TotalAmount { get; }
        /// <summary> The start date of the billing period for which the invoice is generated. </summary>
        public DateTimeOffset? InvoicePeriodStartDate { get; }
        /// <summary> The end date of the billing period for which the invoice is generated. </summary>
        public DateTimeOffset? InvoicePeriodEndDate { get; }
        /// <summary> Invoice type. </summary>
        public InvoiceType? InvoiceType { get; }
        /// <summary> Specifies if the invoice is generated as part of monthly invoicing cycle or not. This field is applicable to billing accounts with agreement type Microsoft Customer Agreement. </summary>
        public bool? IsMonthlyInvoice { get; }
        /// <summary> The ID of the billing profile for which the invoice is generated. </summary>
        public string BillingProfileId { get; }
        /// <summary> The name of the billing profile for which the invoice is generated. </summary>
        public string BillingProfileDisplayName { get; }
        /// <summary> An optional purchase order number for the invoice. </summary>
        public string PurchaseOrderNumber { get; }
        /// <summary> List of documents available to download such as invoice and tax receipt. </summary>
        public IReadOnlyList<Document> Documents { get; }
        /// <summary> List of payments. </summary>
        public IReadOnlyList<PaymentProperties> Payments { get; }
        /// <summary> Rebill details for an invoice. </summary>
        public IReadOnlyDictionary<string, RebillDetails> RebillDetails { get; }
        /// <summary> The type of the document. </summary>
        public InvoiceDocumentType? DocumentType { get; }
        /// <summary> The Id of the active invoice which is originally billed after this invoice was voided. This field is applicable to the void invoices only. </summary>
        public string BilledDocumentId { get; }
        /// <summary> The Id of the invoice which got voided and this credit note was issued as a result. This field is applicable to the credit notes only. </summary>
        public string CreditForDocumentId { get; }
        /// <summary> The ID of the subscription for which the invoice is generated. </summary>
        public string SubscriptionId { get; }
    }
}
