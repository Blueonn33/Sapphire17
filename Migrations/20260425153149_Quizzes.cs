using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapphire17.Migrations
{
    /// <inheritdoc />
    public partial class Quizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_QuizCollections_QuizCollectionId",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.RenameTable(
                name: "Quiz",
                newName: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Quizzes",
                newName: "CorrectAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_QuizCollectionId",
                table: "Quizzes",
                newName: "IX_Quizzes_QuizCollectionId");

            migrationBuilder.AddColumn<string>(
                name: "AnswerA",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerB",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerC",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerD",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizCollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizResults_QuizCollections_QuizCollectionId",
                        column: x => x.QuizCollectionId,
                        principalTable: "QuizCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_QuizCollectionId",
                table: "QuizResults",
                column: "QuizCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_UserId",
                table: "QuizResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_QuizCollections_QuizCollectionId",
                table: "Quizzes",
                column: "QuizCollectionId",
                principalTable: "QuizCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_QuizCollections_QuizCollectionId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "QuizResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerA",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerB",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerC",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerD",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Quizzes");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quiz");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "Quiz",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_QuizCollectionId",
                table: "Quiz",
                newName: "IX_Quiz_QuizCollectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_QuizCollections_QuizCollectionId",
                table: "Quiz",
                column: "QuizCollectionId",
                principalTable: "QuizCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
