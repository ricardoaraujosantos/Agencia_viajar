using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia_viajar.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    PassagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Embarque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desembarque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_passagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_passagem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.PassagemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");
        }
    }
}
