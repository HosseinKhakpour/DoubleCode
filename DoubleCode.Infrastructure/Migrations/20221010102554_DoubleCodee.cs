using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoubleCode.Infrastructure.Migrations
{
    public partial class DoubleCodee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ArticleComment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_UserId",
                table: "ArticleComment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleComment_AspNetUsers_UserId",
                table: "ArticleComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleComment_AspNetUsers_UserId",
                table: "ArticleComment");

            migrationBuilder.DropIndex(
                name: "IX_ArticleComment_UserId",
                table: "ArticleComment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ArticleComment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
