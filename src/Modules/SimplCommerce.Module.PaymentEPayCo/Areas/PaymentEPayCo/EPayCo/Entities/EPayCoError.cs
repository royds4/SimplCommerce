using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Entities
{
    public class EPayCoError 
    {
        [JsonProperty("charge")]
        public string ChargeId { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("decline_code")]
        public string DeclineCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("param")]
        public string Parameter { get; set; }
        [JsonProperty("type")]
        public string ErrorType { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
