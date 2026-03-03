using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapphire17.Migrations
{
    /// <inheritdoc />
    public partial class Videos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Videos",
                newName: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Videos",
                newName: "Link");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Videos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
