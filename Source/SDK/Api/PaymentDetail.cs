using Newtonsoft.Json;

namespace PayPal.Api
{
    public class PaymentDetail : PayPalSerializableObject
    {
        /// <summary>
        /// PayPal payment detail indicating whether payment was made in an invoicing flow via PayPal or externally. In the case of the mark-as-paid API, payment type is EXTERNAL and this is what is now supported. The PAYPAL value is provided for backward compatibility.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
        public string type { get; set; }

        /// <summary>
        /// PayPal payment transaction id. Mandatory field in case the type value is PAYPAL.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_id")]
        public string transaction_id { get; set; }

        /// <summary>
        /// Type of the transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_type")]
        public string transaction_type { get; set; }

        /// <summary>
        /// Date when the invoice was paid. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "date")]
        public string date { get; set; }

        /// <summary>
        /// Payment mode or method. This field is mandatory if the value of the type field is OTHER.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "method")]
        public string method { get; set; }

        /// <summary>
        /// Optional note associated with the payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "note")]
        public string note { get; set; }
    }
}
