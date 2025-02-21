using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersManegementSystem.Migrations
{
    /// <inheritdoc />
    public partial class foreignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_id_role",
                table: "User",
                column: "id_role");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_id_role",
                table: "User",
                column: "id_role",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_id_role",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_id_role",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
