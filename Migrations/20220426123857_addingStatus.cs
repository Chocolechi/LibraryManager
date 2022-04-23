using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class addingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookStatusId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookStatusId",
                table: "Book",
                column: "BookStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookStatus_BookStatusId",
                table: "Book",
                column: "BookStatusId",
                principalTable: "BookStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookStatus_BookStatusId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookStatus");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookStatusId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookStatusId",
                table: "Book");
        }
    }
}
