using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersManegementSystem.Migrations
{
    /// <inheritdoc />
    public partial class foreignKey3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_id_role",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "id_role",
                table: "User",
                newName: "Id_role");

            migrationBuilder.RenameIndex(
                name: "IX_User_id_role",
                table: "User",
                newName: "IX_User_Id_role");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_Id_role",
                table: "User",
                column: "Id_role",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_Id_role",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Id_role",
                table: "User",
                newName: "id_role");

            migrationBuilder.RenameIndex(
                name: "IX_User_Id_role",
                table: "User",
                newName: "IX_User_id_role");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_id_role",
                table: "User",
                column: "id_role",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
