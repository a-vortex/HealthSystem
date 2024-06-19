using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoHealthPlanIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_HealthPlans_HealthPlanId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "HealthPlanId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_HealthPlans_HealthPlanId",
                table: "Customers",
                column: "HealthPlanId",
                principalTable: "HealthPlans",
                principalColumn: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_HealthPlans_HealthPlanId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "HealthPlanId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_HealthPlans_HealthPlanId",
                table: "Customers",
                column: "HealthPlanId",
                principalTable: "HealthPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
