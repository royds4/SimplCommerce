using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto
{
    public class ChargeDTO
    {
        public string Token_Card { get; set; }
        public long Customer_Id { get; set; }
        public string Doc_Type { get; set; }
        public long Doc_Number { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Bill { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public decimal Tax_Base { get; set; }
        public string Currency { get; set; }
        public int Dues { get; set; }
    }
}
