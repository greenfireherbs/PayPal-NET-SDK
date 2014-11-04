using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayPal.Api
{
    public class Error : PayPalSerializableObject
    {
        /// <summary>
        /// Human readable, unique name of the error.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
        public string name { get; set; }

        /// <summary>
        /// PayPal internal identifier used for correlation purposes.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "debug_id")]
        public string debug_id { get; set; }

        /// <summary>
        /// Message describing the error.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "message")]
        public string message { get; set; }

        /// <summary>
        /// URI for detailed information related to this error for the developer.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "information_link")]
        public string information_link { get; set; }

        /// <summary>
        /// Additional details of the error
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "details")]
        public List<ErrorDetails> details { get; set; }
    }
}
