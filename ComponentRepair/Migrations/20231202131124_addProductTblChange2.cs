using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComponentRepair.Migrations
{
    /// <inheritdoc />
    public partial class addProductTblChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Component_ComponentId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Device_DeviceId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ComponentId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Component_ComponentId",
                table: "Product",
                column: "ComponentId",
                principalTable: "Component",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Device_DeviceId",
                table: "Product",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Component_ComponentId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Device_DeviceId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComponentId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Component_ComponentId",
                table: "Product",
                column: "ComponentId",
                principalTable: "Component",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Device_DeviceId",
                table: "Product",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
