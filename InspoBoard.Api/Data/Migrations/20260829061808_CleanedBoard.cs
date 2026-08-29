using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InspoBoard.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class CleanedBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Boards_BoardId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_BoardId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Items_BoardId",
                table: "Items",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Boards_BoardId",
                table: "Items",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
