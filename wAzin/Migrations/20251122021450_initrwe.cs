using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wAzin.Migrations
{
    /// <inheritdoc />
    public partial class initrwe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Expenses",
                newName: "SavingPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expenses",
                newName: "IX_Expenses_SavingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_SavingPlanId",
                table: "Expenses",
                column: "SavingPlanId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_SavingPlanId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "SavingPlanId",
                table: "Expenses",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_SavingPlanId",
                table: "Expenses",
                newName: "IX_Expenses_BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
