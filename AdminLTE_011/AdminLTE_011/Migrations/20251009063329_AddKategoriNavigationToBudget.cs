using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminLTE_011.Migrations
{
    /// <inheritdoc />
    public partial class AddKategoriNavigationToBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Budget_KategoriId",
                table: "Budget",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Kategori_KategoriId",
                table: "Budget",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Kategori_KategoriId",
                table: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Budget_KategoriId",
                table: "Budget");
        }
    }
}
