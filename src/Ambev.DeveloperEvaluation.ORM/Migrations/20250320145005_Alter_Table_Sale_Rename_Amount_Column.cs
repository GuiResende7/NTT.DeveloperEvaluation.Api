using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_Sale_Rename_Amount_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmoutWithDiscount",
                table: "Sales",
                newName: "TotalAmountWithDiscount");

            migrationBuilder.RenameColumn(
                name: "TotalAmout",
                table: "Sales",
                newName: "TotalAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmountWithDiscount",
                table: "Sales",
                newName: "TotalAmoutWithDiscount");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Sales",
                newName: "TotalAmout");
        }
    }
}
