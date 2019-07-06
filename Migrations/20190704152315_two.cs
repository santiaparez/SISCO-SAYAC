using Microsoft.EntityFrameworkCore.Migrations;

namespace SISCO_SAYACv3._5.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "primer_apellido",
                table: "Contratistas",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "primer_apellido",
                table: "Contratistas",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);
        }
    }
}
