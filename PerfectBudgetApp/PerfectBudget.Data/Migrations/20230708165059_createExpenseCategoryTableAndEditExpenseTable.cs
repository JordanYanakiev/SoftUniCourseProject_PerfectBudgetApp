using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectBudgetApp.Data.Migrations
{
    public partial class createExpenseCategoryTableAndEditExpenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetsExpenses_Expenses_ExpenseId",
                table: "BudgetsExpenses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Expenses");

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => new { x.CategoryId, x.ExpenseId });
                    table.ForeignKey(
                        name: "FK_ExpenseCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseCategory_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategory_ExpenseId",
                table: "ExpenseCategory",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetsExpenses_Expenses_ExpenseId",
                table: "BudgetsExpenses",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetsExpenses_Expenses_ExpenseId",
                table: "BudgetsExpenses");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Expenses",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetsExpenses_Expenses_ExpenseId",
                table: "BudgetsExpenses",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
