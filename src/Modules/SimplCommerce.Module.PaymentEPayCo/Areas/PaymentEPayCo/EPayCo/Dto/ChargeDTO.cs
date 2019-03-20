using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto
{
    public class ChargeDTO
    {
        public string Token_Card { get; set; }
        public string Customer_Id { get; set; }
        public string Doc_Type { get; set; }
        public long Doc_Number { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Bill { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Tax { get; set; }
        public int Tax_Base { get; set; }
        public string Currency { get; set; }
        public int Dues { get; set; }
    }
}
