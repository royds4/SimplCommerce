using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Entities
{
    public class Confirmation
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
        [JsonProperty(PropertyName = "title_response")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "text_response")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "data")]
        public ConfirmationData Data { get; set; }
    }

    public class ConfirmationData
    {
        [JsonProperty(PropertyName = "x_cust_id_cliente")]
        public int ClientId { get; set; }
        [JsonProperty(PropertyName = "x_ref_payco")]
        public string RefPayco { get; set; }
        [JsonProperty(PropertyName = "x_id_factura")]
        public string Receipt { get; set; }
        [JsonProperty(PropertyName = "x_id_invoice")]
        public string Invoice { get; set; }
        [JsonProperty(PropertyName = "x_bank_name")]
        public string BankName { get; set; }
        [JsonProperty(PropertyName = "x_transaction_id")]
        public string TransactionId { get; set; }
    }
}
