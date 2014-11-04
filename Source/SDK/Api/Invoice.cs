using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using PayPal.Util;

namespace PayPal.Api
{
    public class Invoice : PayPalSerializableObject
    {
        /// <summary>
        /// Unique invoice resource identifier.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Unique number that appears on the invoice. If left blank will be auto-incremented from the last number. 25 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "number")]
        public string number { get; set; }

        /// <summary>
        /// URI of the invoice resource.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "uri")]
        public string uri { get; set; }

        /// <summary>
        /// Status of the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
        public string status { get; set; }

        /// <summary>
        /// Information about the merchant who is sending the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_info")]
        public MerchantInfo merchant_info { get; set; }

        /// <summary>
        /// Email address of invoice recipient (required) and optional billing information. (Note: We currently only allow one recipient).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "billing_info")]
        public List<BillingInfo> billing_info { get; set; }

        /// <summary>
        /// Shipping information for entities to whom items are being shipped.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "shipping_info")]
        public ShippingInfo shipping_info { get; set; }

        /// <summary>
        /// List of items included in the invoice. 100 items max per invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "items")]
        public List<InvoiceItem> items { get; set; }

        /// <summary>
        /// Date on which the invoice was enabled. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "invoice_date")]
        public string invoice_date { get; set; }

        /// <summary>
        /// Optional field to pass payment deadline for the invoice. Either term_type or due_date can be passed, but not both.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_term")]
        public PaymentTerm payment_term { get; set; }

        /// <summary>
        /// Invoice level discount in percent or amount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "discount")]
        public Cost discount { get; set; }

        /// <summary>
        /// Shipping cost in percent or amount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "shipping_cost")]
        public ShippingCost shipping_cost { get; set; }

        /// <summary>
        /// Custom amount applied on an invoice. If a label is included then the amount cannot be empty.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "custom")]
        public CustomAmount custom { get; set; }

        /// <summary>
        /// Indicates whether tax is calculated before or after a discount. If false (the default), the tax is calculated before a discount. If true, the tax is calculated after a discount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax_calculated_after_discount")]
        public bool? tax_calculated_after_discount { get; set; }

        /// <summary>
        /// A flag indicating whether the unit price includes tax. Default is false
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax_inclusive")]
        public bool? tax_inclusive { get; set; }

        /// <summary>
        /// General terms of the invoice. 4000 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "terms")]
        public string terms { get; set; }

        /// <summary>
        /// Note to the payer. 4000 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note")]
        public string note { get; set; }

        /// <summary>
        /// Bookkeeping memo that is private to the merchant. 150 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "merchant_memo")]
        public string merchant_memo { get; set; }

        /// <summary>
        /// Full URL of an external image to use as the logo. 4000 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "logo_url")]
        public string logo_url { get; set; }

        /// <summary>
        /// The total amount of the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "total_amount")]
        public Currency total_amount { get; set; }

        /// <summary>
        /// List of payment details for the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "payment_details")]
        public List<PaymentDetail> payment_details { get; set; }

        /// <summary>
        /// List of refund details for the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "refund_details")]
        public List<RefundDetail> refund_details { get; set; }

        /// <summary>
        /// Audit information for the invoice.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "metadata")]
        public Metadata metadata { get; set; }

        /// <summary>
        /// Creates a new invoice Resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <returns>Invoice</returns>
        public Invoice Create(APIContext apiContext)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            var resourcePath = "v1/invoicing/invoices";
            return PayPalResource.ConfigureAndExecute<Invoice>(apiContext, HttpMethod.POST, resourcePath, this.ConvertToJson());
        }

        /// <summary>
        /// Search for invoice resources.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="search">Search</param>
        /// <returns>Invoices</returns>
        public Invoices Search(APIContext apiContext, Search search)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(search, "search");

            // Configure and send the request
            var resourcePath = "v1/invoicing/search";
            return PayPalResource.ConfigureAndExecute<Invoices>(apiContext, HttpMethod.POST, resourcePath, search.ConvertToJson());
        }

        /// <summary>
        /// Sends a legitimate invoice to the payer.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="notifyMerchant">Specifies if the invoice send notification is needed for merchant</param>
        public void Send(APIContext apiContext, bool notifyMerchant = true)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}/send?notify_merchant={1}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { this.id, notifyMerchant });
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath);
        }

        /// <summary>
        /// Reminds the payer to pay the invoice.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="notification">Notification</param>
        public void Remind(APIContext apiContext, Notification notification)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(notification, "notification");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}/remind";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { this.id });
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, notification.ConvertToJson());
        }

        /// <summary>
        /// Cancels an invoice.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="cancelNotification">CancelNotification</param>
        public void Cancel(APIContext apiContext, CancelNotification cancelNotification)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(cancelNotification, "cancelNotification");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}/cancel";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { this.id });
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, cancelNotification.ConvertToJson());
        }

        /// <summary>
        /// Mark the status of the invoice as paid.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="paymentDetail">PaymentDetail</param>
        public void RecordPayment(APIContext apiContext, PaymentDetail paymentDetail)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(paymentDetail, "paymentDetail");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}/record-payment";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { this.id });
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, paymentDetail.ConvertToJson());
        }

        /// <summary>
        /// Mark the status of the invoice as refunded.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="refundDetail">RefundDetail</param>
        public void RecordRefund(APIContext apiContext, RefundDetail refundDetail)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");
            ArgumentValidator.Validate(refundDetail, "refundDetail");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}/record-refund";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { this.id });
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.POST, resourcePath, refundDetail.ConvertToJson());
        }

        /// <summary>
        /// Get the invoice resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="invoiceId">Identifier of the invoice resource to obtain the data for.</param>
        /// <returns>Invoice</returns>
        public static Invoice Get(APIContext apiContext, string invoiceId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(invoiceId, "invoiceId");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { invoiceId });
            return PayPalResource.ConfigureAndExecute<Invoice>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Get all invoices of a merchant.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="page">Start index.</param>
        /// <param name="pageSize">Number of invoices to be returned by the GET API.</param>
        /// <param name="totalCountRequired">A flag to depict that total_count should be returned in the response.</param>
        /// <returns>Invoices</returns>
        public static Invoices GetAll(APIContext apiContext, int page = 1, int pageSize = 20, bool totalCountRequired = false)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);

            // Configure and send the request
            var pattern = "v1/invoicing/invoices?page={0}&page_size={1}&total_count_required={2}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { page, pageSize, totalCountRequired });
            return PayPalResource.ConfigureAndExecute<Invoices>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Full update of the invoice resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="notifyMerchant">Specifies if the invoice update notification is needed for merchant</param>
        /// <returns>Invoice</returns>
        public Invoice Update(APIContext apiContext, bool notifyMerchant = true)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(this.id, "Id");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}?notify_merchant={1}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { this.id, notifyMerchant });
            return PayPalResource.ConfigureAndExecute<Invoice>(apiContext, HttpMethod.PUT, resourcePath, this.ConvertToJson());
        }

        /// <summary>
        /// Delete invoice resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="invoiceId">Identifier of the invoice resource to be updated.</param>
        public static void Delete(APIContext apiContext, string invoiceId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(invoiceId, "invoiceId");

            // Configure and send the request
            apiContext.MaskRequestId = true;
            var pattern = "v1/invoicing/invoices/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { invoiceId });
            PayPalResource.ConfigureAndExecute<object>(apiContext, HttpMethod.DELETE, resourcePath);
        }

        /// <summary>
        /// Generates QR code for the Invoice URL identified by invoice_id.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="invoiceId">Identifier of the invoice resource for which QR code has to be generated.</param>
        /// <param name="width">Indicates the width of the QR code image in pixels. Range : 150-500. Default 500.</param>
        /// <param name="height">Indicates the height of the QR code image in pixels. Range : 150-500. Default 500.</param>
        /// <param name="action">Specifies the type of URL for which the QR code has the be generated.</param>
        /// <returns>Image</returns>
        public static Image QrCode(APIContext apiContext, string invoiceId, int width = 500, int height = 500, string action = "pay")
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(invoiceId, "invoiceId");

            // Configure and send the request
            var pattern = "v1/invoicing/invoices/{0}/qr-code?width={1}&height={2}&action={3}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { invoiceId, width, height, action });
            return PayPalResource.ConfigureAndExecute<Image>(apiContext, HttpMethod.GET, resourcePath);
        }
    }
}
