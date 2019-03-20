using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto
{
    public class CardDTO
    {
        public long Number { get; set; }
        public string Exp_Number { get; set; }
        public string Exp_Month { get; set; }
        public int CVC { get; set; }
    }
}
