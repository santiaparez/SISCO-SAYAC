using Microsoft.EntityFrameworkCore.Migrations;

namespace SISCO_SAYACv3._5.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Obras_Contratistas",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_ContratistasId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "ContratistasId",
                table: "Obras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContratistasId",
                table: "Obras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ContratistasId",
                table: "Obras",
                column: "ContratistasId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Obras_Contratistas",
                table: "Obras",
                column: "ContratistasId",
                principalTable: "Contratistas",
                principalColumn: "ContratistasId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
