using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersManegementSystem.Migrations
{
    /// <inheritdoc />
    public partial class foreignKey5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photo",
                table: "User",
                newName: "Photo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "User",
                newName: "photo");
        }
    }
}
