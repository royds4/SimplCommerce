using SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo
{
    public class EPayCoException : Exception
    {
        public EPayCoException():base() { }
        public EPayCoException(string message):base(message) { }
        public EPayCoException(string message, Exception err):base(message,err) { }
        public EPayCoException(HttpStatusCode httpStatusCode, EPayCoError epaycoError, string message) { }

        public HttpStatusCode HttpStatusCode { get; set; }
        public EPayCoError StripeError { get; set; }
        //public EPayCoResponse StripeResponse { get; set; }
    }
}
