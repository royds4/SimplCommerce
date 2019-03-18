using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddEPayCoPaymentProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.InsertData(
              table: "Payments_PaymentProvider",
              columns: new[] { "Id", "AdditionalSettings", "ConfigureUrl", "IsEnabled", "LandingViewComponentName", "Name" },
              values: new object[] { "EPayCo", "{\"PublicKey\":\"2f9e0e3ea8fe2f4e98a21c618cd8ba4a\",\"PrivateKey\":\"f57cad0bf01a1f58b8d12b2cdfe05f6a\",\"Test\":\"true\"}", "payments-epayco-config", true, "EPayCoLanding", "EPayCo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
              table: "Payments_PaymentProvider",
              keyColumn: "Id",
              keyValue: "EPayCo"
              );
        }
    }
}
