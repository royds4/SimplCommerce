using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo
{
    public class Token
    {
        string url = @"/v1/tokens";

        public object Create(object options=null)
        {
            return new { };
        }
    }
}
