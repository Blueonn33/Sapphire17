using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapphire17.Migrations
{
    /// <inheritdoc />
    public partial class QuizResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_AspNetUsers_UserId",
                table: "QuizResults");

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "QuizResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_AspNetUsers_UserId",
                table: "QuizResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_AspNetUsers_UserId",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "QuizResults");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_AspNetUsers_UserId",
                table: "QuizResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
