using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectBudgetApp.Data.Migrations
{
    public partial class addedNamesForLoanGiverAndLoanAsker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoanGiver",
                table: "Debts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoanRequester",
                table: "Debts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanGiver",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "LoanRequester",
                table: "Debts");
        }
    }
}
