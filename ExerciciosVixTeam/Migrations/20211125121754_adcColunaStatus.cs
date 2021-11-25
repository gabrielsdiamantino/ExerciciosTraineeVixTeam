using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciciosVixTeam.Migrations
{
    public partial class adcColunaStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Situacao",
                table: "PessoaModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PessoaModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "PessoaModel");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PessoaModel");
        }
    }
}
