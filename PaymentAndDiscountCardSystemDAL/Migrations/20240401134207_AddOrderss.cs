using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentAndDiscountCardSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Orders",
                newName: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "OrderID");
        }
    }
}
