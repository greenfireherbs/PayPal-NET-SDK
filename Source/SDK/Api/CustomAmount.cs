using Newtonsoft.Json;

namespace PayPal.Api
{
    public class CustomAmount : PayPalSerializableObject
    {
        /// <summary>
        /// Custom amount label. 25 characters max.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "label")]
        public string label { get; set; }

        /// <summary>
        /// Custom amount value. Range of 0 to 999999.99.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Currency amount { get; set; }
    }
}
