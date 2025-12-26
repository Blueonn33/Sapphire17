using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapphire17.Migrations
{
    /// <inheritdoc />
    public partial class ResultsDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAnswered",
                table: "Results",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAnswered",
                table: "Results");
        }
    }
}
