using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class AddESCO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Localization_Culture",
                columns: new[] { "Id", "Name" },
                values: new object[] { "es-CO","Español" });

    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localization_Culture",
                keyColumn: "Id",
                keyValue: "es-CO");
        }
    }
}
