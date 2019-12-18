using Microsoft.EntityFrameworkCore.Migrations;

namespace Sacrament_Planner.Migrations
{
    public partial class SpeakersTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Sacrament_Plan_Sacrament_PlanID",
                table: "Speaker");

            migrationBuilder.AlterColumn<int>(
                name: "Sacrament_PlanID",
                table: "Speaker",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Sacrament_Plan_Sacrament_PlanID",
                table: "Speaker",
                column: "Sacrament_PlanID",
                principalTable: "Sacrament_Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Sacrament_Plan_Sacrament_PlanID",
                table: "Speaker");

            migrationBuilder.AlterColumn<int>(
                name: "Sacrament_PlanID",
                table: "Speaker",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Sacrament_Plan_Sacrament_PlanID",
                table: "Speaker",
                column: "Sacrament_PlanID",
                principalTable: "Sacrament_Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
