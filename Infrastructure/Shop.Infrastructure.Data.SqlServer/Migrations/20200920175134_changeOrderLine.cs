using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Data.SqlServer.Migrations
{
    public partial class changeOrderLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MasterProducts_MasterProductId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "MasterProductsId",
                table: "OrderLines");

            migrationBuilder.AlterColumn<long>(
                name: "MasterProductId",
                table: "OrderLines",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_MasterProducts_MasterProductId",
                table: "OrderLines",
                column: "MasterProductId",
                principalTable: "MasterProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_MasterProducts_MasterProductId",
                table: "OrderLines");

            migrationBuilder.AlterColumn<long>(
                name: "MasterProductId",
                table: "OrderLines",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "MasterProductsId",
                table: "OrderLines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_MasterProducts_MasterProductId",
                table: "OrderLines",
                column: "MasterProductId",
                principalTable: "MasterProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
