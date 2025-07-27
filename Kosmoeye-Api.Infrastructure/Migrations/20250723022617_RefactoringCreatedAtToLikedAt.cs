using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kosmoeye_Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringCreatedAtToLikedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Likes",
                newName: "LikedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LikedAt",
                table: "Likes",
                newName: "CreatedAt");
        }
    }
}
