using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddAmount_ShoopingCarts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "products");
        }
    }
}
