using Newtonsoft.Json;

namespace PayPal.Api
{
    public class ShippingCost : PayPalSerializableObject
    {
        /// <summary>
        /// Shipping cost in amount. Range of 0 to 999999.99.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }

        /// <summary>
        /// Tax percentage on shipping amount.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tax")]
        public Tax tax { get; set; }
    }
}
