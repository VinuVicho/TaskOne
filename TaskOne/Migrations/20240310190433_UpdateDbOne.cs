using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskOne.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Executors",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Executors",
                newName: "Password");
        }
    }
}
