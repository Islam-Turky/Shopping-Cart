using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApplication.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_AspNetUsers_UserIdentityId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserIdentityId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserIdentityId",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserIdentityId",
                table: "users",
                column: "UserIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_AspNetUsers_UserIdentityId",
                table: "users",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
