using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmsApiProject.Migrations
{
    public partial class mig_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Payment",
                table: "Farms",
                newName: "MilkingTime");

            migrationBuilder.RenameColumn(
                name: "OperationTime",
                table: "Farms",
                newName: "MilkingID");

            migrationBuilder.RenameColumn(
                name: "OperationID",
                table: "Farms",
                newName: "Liter");

            migrationBuilder.RenameColumn(
                name: "CustomerType",
                table: "Farms",
                newName: "AnimalType");

            migrationBuilder.RenameColumn(
                name: "CustomerStatus",
                table: "Farms",
                newName: "AnimalStatus");

            migrationBuilder.RenameColumn(
                name: "CustomerNo",
                table: "Farms",
                newName: "FarmID");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Farms",
                newName: "AnimalName");

            migrationBuilder.RenameColumn(
                name: "CoiffeurID",
                table: "Farms",
                newName: "AnimalIdentificationNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MilkingTime",
                table: "Farms",
                newName: "Payment");

            migrationBuilder.RenameColumn(
                name: "MilkingID",
                table: "Farms",
                newName: "OperationTime");

            migrationBuilder.RenameColumn(
                name: "Liter",
                table: "Farms",
                newName: "OperationID");

            migrationBuilder.RenameColumn(
                name: "FarmID",
                table: "Farms",
                newName: "CustomerNo");

            migrationBuilder.RenameColumn(
                name: "AnimalType",
                table: "Farms",
                newName: "CustomerType");

            migrationBuilder.RenameColumn(
                name: "AnimalStatus",
                table: "Farms",
                newName: "CustomerStatus");

            migrationBuilder.RenameColumn(
                name: "AnimalName",
                table: "Farms",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "AnimalIdentificationNo",
                table: "Farms",
                newName: "CoiffeurID");
        }
    }
}
