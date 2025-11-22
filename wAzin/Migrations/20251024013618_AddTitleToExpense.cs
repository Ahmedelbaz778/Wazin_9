using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wAzin.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleToExpense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "FullName");
        }
    }
}
