using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdentityToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForigenKey_IdentityUser_AspUser",
                table: "products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ForigenKey_IdentityUser_AspUser",
                table: "products",
                column: "ForigenKey_IdentityUser_AspUser");

            migrationBuilder.AddForeignKey(
                name: "FK_products_AspNetUsers_ForigenKey_IdentityUser_AspUser",
                table: "products",
                column: "ForigenKey_IdentityUser_AspUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_AspNetUsers_ForigenKey_IdentityUser_AspUser",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ForigenKey_IdentityUser_AspUser",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ForigenKey_IdentityUser_AspUser",
                table: "products");
        }
    }
}
