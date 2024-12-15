using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabtopInfo.Migrations
{
    public partial class LabtopDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labtops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labtops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "labtopCategoris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    laptopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labtopCategoris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labtopCategoris_labtops_laptopId",
                        column: x => x.laptopId,
                        principalTable: "labtops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "labtops",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ", "Asus" });

            migrationBuilder.CreateIndex(
                name: "IX_labtopCategoris_laptopId",
                table: "labtopCategoris",
                column: "laptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labtopCategoris");

            migrationBuilder.DropTable(
                name: "labtops");
        }
    }
}
