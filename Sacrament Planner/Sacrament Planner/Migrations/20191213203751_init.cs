using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sacrament_Planner.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sacrament_Plan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    ConductingLeader = table.Column<string>(maxLength: 50, nullable: false),
                    OpeningSong = table.Column<string>(maxLength: 50, nullable: false),
                    SacramentHymn = table.Column<string>(maxLength: 50, nullable: false),
                    ClosingSong = table.Column<string>(maxLength: 50, nullable: false),
                    MusicalNumber = table.Column<string>(maxLength: 50, nullable: true),
                    IntermediateHymn = table.Column<string>(maxLength: 50, nullable: true),
                    OpeningPrayer = table.Column<string>(maxLength: 50, nullable: false),
                    ClosingPrayer = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfSpeakers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacrament_Plan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Subject = table.Column<string>(maxLength: 50, nullable: false),
                    Sacrament_PlanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_Sacrament_Plan_Sacrament_PlanID",
                        column: x => x.Sacrament_PlanID,
                        principalTable: "Sacrament_Plan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_Sacrament_PlanID",
                table: "Speaker",
                column: "Sacrament_PlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Sacrament_Plan");
        }
    }
}
