using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Dto
{
    public class BankDTO
    {
        public long Invoice { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public decimal Tax_Base { get; set; }
        public string Currency { get; set; }
        public int Type_Person { get; set; }
        public string Doc_Type { get; set; }
        public long Doc_Number { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public long Cell_Phone { get; set; }
        public string Url_Response { get; set; }
        public string Url_Confirmation { get; set; }
        public string Method_Confirmation { get; set; }

    }
}
