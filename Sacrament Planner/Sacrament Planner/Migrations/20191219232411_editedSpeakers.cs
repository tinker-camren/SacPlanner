using Microsoft.EntityFrameworkCore.Migrations;

namespace Sacrament_Planner.Migrations
{
    public partial class editedSpeakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "SpeakerID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "SacramentID",
                table: "Speaker");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Speaker",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Speaker");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerID",
                table: "Speaker",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SacramentID",
                table: "Speaker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker",
                column: "SpeakerID");
        }
    }
}
