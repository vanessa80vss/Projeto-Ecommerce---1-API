using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ProjetoEcommerceAPI.Migrations
{
    public partial class Criandoproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeDoProduto = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    DescricaoDoProduto = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    PesoDoProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AlturaDoProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LarguraDoProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ComprimentoDoProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ValorDoProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    QuantidadeEmEstoqueDoProduto = table.Column<int>(type: "int", nullable: false),
                    CentroDeDistribuicao = table.Column<string>(type: "text", nullable: true),
                    StatusDoProduto = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataCriacaoDoProduto = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacaoDoProduto = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubCategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_SubCategorias_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_SubCategoriaId",
                table: "Produtos",
                column: "SubCategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
