using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApplication.Migrations
{
    /// <inheritdoc />
    public partial class removeIdentityFromProductM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_AspNetUsers_IdentityUser",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_IdentityUser",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IdentityUser",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUser",
                table: "products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_IdentityUser",
                table: "products",
                column: "IdentityUser");

            migrationBuilder.AddForeignKey(
                name: "FK_products_AspNetUsers_IdentityUser",
                table: "products",
                column: "IdentityUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
