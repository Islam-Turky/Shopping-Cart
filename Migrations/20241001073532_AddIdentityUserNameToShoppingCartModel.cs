using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserNameToShoppingCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdentityNameId",
                table: "shoppingCarts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_UserIdentityNameId",
                table: "shoppingCarts",
                column: "UserIdentityNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_UserIdentityNameId",
                table: "shoppingCarts",
                column: "UserIdentityNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_UserIdentityNameId",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_UserIdentityNameId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserIdentityNameId",
                table: "shoppingCarts");
        }
    }
}
