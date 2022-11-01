using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agencia_viajar.Migrations
{
    public partial class tablehospedagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospedagem",
                columns: table => new
                {
                    HospedagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_hospedagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_diaria = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedagem", x => x.HospedagemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospedagem");
        }
    }
}
