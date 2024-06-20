using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMedicalAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_MedicalServices_MedicalServiceId",
                table: "MedicalAppointments");

            migrationBuilder.DropTable(
                name: "MedicalServices");

            migrationBuilder.DropIndex(
                name: "IX_MedicalAppointments_MedicalServiceId",
                table: "MedicalAppointments");

            migrationBuilder.RenameColumn(
                name: "MedicalServiceId",
                table: "MedicalAppointments",
                newName: "medicalService_Type");

            migrationBuilder.AddColumn<int>(
                name: "medicalService_Area",
                table: "MedicalAppointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "medicalService_Description",
                table: "MedicalAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "medicalService_Name",
                table: "MedicalAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "medicalService_Price",
                table: "MedicalAppointments",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "medicalService_Area",
                table: "MedicalAppointments");

            migrationBuilder.DropColumn(
                name: "medicalService_Description",
                table: "MedicalAppointments");

            migrationBuilder.DropColumn(
                name: "medicalService_Name",
                table: "MedicalAppointments");

            migrationBuilder.DropColumn(
                name: "medicalService_Price",
                table: "MedicalAppointments");

            migrationBuilder.RenameColumn(
                name: "medicalService_Type",
                table: "MedicalAppointments",
                newName: "MedicalServiceId");

            migrationBuilder.CreateTable(
                name: "MedicalServices",
                columns: table => new
                {
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServices", x => x.MedicalServiceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointments_MedicalServiceId",
                table: "MedicalAppointments",
                column: "MedicalServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_MedicalServices_MedicalServiceId",
                table: "MedicalAppointments",
                column: "MedicalServiceId",
                principalTable: "MedicalServices",
                principalColumn: "MedicalServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
