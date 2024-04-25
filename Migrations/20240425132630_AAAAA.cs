using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B_Deneme.Migrations
{
    public partial class AAAAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "CandidateUsers");

            migrationBuilder.DropColumn(
                name: "IsPasivve",
                table: "CandidateUsers");

            migrationBuilder.AddColumn<int>(
                name: "Statu",
                table: "CandidateUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statu",
                table: "CandidateUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "CandidateUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPasivve",
                table: "CandidateUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
