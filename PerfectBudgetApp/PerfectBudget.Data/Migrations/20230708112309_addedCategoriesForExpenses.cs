using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectBudgetApp.Data.Migrations
{
    public partial class addedCategoriesForExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Groceries" },
                    { 2, "Utilities" },
                    { 3, "Car" },
                    { 4, "Loan" },
                    { 5, "Internet" },
                    { 6, "Mobile" },
                    { 7, "Leasing" },
                    { 8, "Electricity" },
                    { 9, "Water" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
