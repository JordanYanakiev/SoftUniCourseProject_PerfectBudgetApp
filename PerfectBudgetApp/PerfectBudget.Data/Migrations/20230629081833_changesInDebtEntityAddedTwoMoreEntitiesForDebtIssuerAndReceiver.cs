using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectBudgetApp.Data.Migrations
{
    public partial class changesInDebtEntityAddedTwoMoreEntitiesForDebtIssuerAndReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Giver",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "Taker",
                table: "Debts");

            migrationBuilder.CreateTable(
                name: "DebtsIssuers",
                columns: table => new
                {
                    DebtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtIssuerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtsIssuers", x => new { x.DebtId, x.DebtIssuerId });
                    table.ForeignKey(
                        name: "FK_DebtsIssuers_AspNetUsers_DebtIssuerId",
                        column: x => x.DebtIssuerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtsIssuers_Debts_DebtId",
                        column: x => x.DebtId,
                        principalTable: "Debts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtsReceivers",
                columns: table => new
                {
                    DebtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtsReceivers", x => new { x.DebtId, x.DebtReceiverId });
                    table.ForeignKey(
                        name: "FK_DebtsReceivers_AspNetUsers_DebtReceiverId",
                        column: x => x.DebtReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtsReceivers_Debts_DebtId",
                        column: x => x.DebtId,
                        principalTable: "Debts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtsIssuers_DebtIssuerId",
                table: "DebtsIssuers",
                column: "DebtIssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtsReceivers_DebtReceiverId",
                table: "DebtsReceivers",
                column: "DebtReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtsIssuers");

            migrationBuilder.DropTable(
                name: "DebtsReceivers");

            migrationBuilder.AddColumn<string>(
                name: "Giver",
                table: "Debts",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Taker",
                table: "Debts",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");
        }
    }
}
