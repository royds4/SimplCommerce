using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels
{
    public class EPayCoConfigForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string PublicKey { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string PrivateKey { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public bool Test { get; set; }
    }
}
