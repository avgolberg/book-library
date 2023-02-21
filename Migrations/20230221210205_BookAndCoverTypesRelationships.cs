using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class BookAndCoverTypesRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTypes_Books_BookId",
                table: "BookTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CoverTypes_Books_BookId",
                table: "CoverTypes");

            migrationBuilder.DropIndex(
                name: "IX_CoverTypes_BookId",
                table: "CoverTypes");

            migrationBuilder.DropIndex(
                name: "IX_BookTypes_BookId",
                table: "BookTypes");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "CoverTypes");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookTypes");

            migrationBuilder.CreateTable(
                name: "BookBookType",
                columns: table => new
                {
                    BookTypesId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookType", x => new { x.BookTypesId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookBookType_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookType_BookTypes_BookTypesId",
                        column: x => x.BookTypesId,
                        principalTable: "BookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCoverType",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CoverTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCoverType", x => new { x.BooksId, x.CoverTypesId });
                    table.ForeignKey(
                        name: "FK_BookCoverType_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCoverType_CoverTypes_CoverTypesId",
                        column: x => x.CoverTypesId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookType_BooksId",
                table: "BookBookType",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCoverType_CoverTypesId",
                table: "BookCoverType",
                column: "CoverTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookType");

            migrationBuilder.DropTable(
                name: "BookCoverType");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "CoverTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoverTypes_BookId",
                table: "CoverTypes",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTypes_BookId",
                table: "BookTypes",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTypes_Books_BookId",
                table: "BookTypes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoverTypes_Books_BookId",
                table: "CoverTypes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
