using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentEPayCo.Data
{
    public class PaymentEPayCoCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().HasData(
                new PaymentProvider("EPayCo") {Name="EPayCo", LandingViewComponentName="EPayCoLanding", ConfigureUrl="payments-epayco-config", IsEnabled=true,AdditionalSettings= "{\"PublicKey\":\"2f9e0e3ea8fe2f4e98a21c618cd8ba4a\",\"PrivateKey\":\"f57cad0bf01a1f58b8d12b2cdfe05f6a\",\"Test\":\"true\"}" }
                );
        }
    }
}
