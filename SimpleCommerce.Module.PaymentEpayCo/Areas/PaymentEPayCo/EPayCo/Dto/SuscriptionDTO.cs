using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto
{
    public class SuscriptionDTO
    {
        public string Id_Plan { get; set; }
        public string Customer { get; set; }
        public string Token_Card { get; set; }
        public string Doc_Type { get; set; }
        public decimal Doc_Number { get; set; }
    }
}
