using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabtopInfo.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "labtopCategoris",
                columns: new[] { "Id", "Description", "Name", "laptopId" },
                values: new object[] { 1, "This is a test... ", "Rog", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "labtopCategoris",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
