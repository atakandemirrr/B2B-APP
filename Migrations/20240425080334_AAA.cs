using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B_Deneme.Migrations
{
    public partial class AAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPasivve",
                table: "Users",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPasivve",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPasivve",
                table: "CandidateUsers");
        }
    }
}
