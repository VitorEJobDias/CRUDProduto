using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDProduto.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeTbProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbCategoria_Id",
                table: "tbProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_IdCategoria",
                table: "tbProduto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbCategoria_IdCategoria",
                table: "tbProduto",
                column: "IdCategoria",
                principalTable: "tbCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbCategoria_IdCategoria",
                table: "tbProduto");

            migrationBuilder.DropIndex(
                name: "IX_tbProduto_IdCategoria",
                table: "tbProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbCategoria_Id",
                table: "tbProduto",
                column: "Id",
                principalTable: "tbCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
