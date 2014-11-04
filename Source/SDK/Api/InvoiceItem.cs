using Newtonsoft.Json;

namespace PayPal.Api
{
    public class InvoiceItem : PayPalSerializableObject
    {
        /// <summary>
        /// Name of the item. 60 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// Description of the item. 1000 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
        public string description { get; set; }

        /// <summary>
        /// Quantity of the item. Range of 0 to 9999.999.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "quantity")]
        public float quantity { get; set; }

        /// <summary>
        /// Unit price of the item. Range of -999999.99 to 999999.99.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "unit_price")]
        public Currency unit_price { get; set; }

        /// <summary>
        /// Tax associated with the item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax")]
        public Tax tax { get; set; }

        /// <summary>
        /// Date on which the item or service was provided. Date format yyyy-MM-dd z, as defined in [ISO8601](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "date")]
        public string date { get; set; }

        /// <summary>
        /// Item discount in percent or amount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "discount")]
        public Cost discount { get; set; }
    }
}
