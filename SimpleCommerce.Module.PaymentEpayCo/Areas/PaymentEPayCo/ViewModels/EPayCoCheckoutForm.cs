namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.ViewModels
{
    public class EPayCoCheckoutForm
    {
        public string Key { get; set; }
        public long Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public bool Test { get; set; }
    }
}
