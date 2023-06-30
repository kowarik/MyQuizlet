using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyQuizlet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeckName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Term = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EnglishLevel = table.Column<int>(type: "int", nullable: false),
                    DeckId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreatedDate", "DeckId", "Definition", "EnglishLevel", "Term", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("70adbf2a-f318-4879-b065-01d73ab30bb8"), new DateTime(2023, 6, 25, 14, 51, 18, 172, DateTimeKind.Local).AddTicks(7797), null, "Яблоко", 1, "Apple", null },
                    { new Guid("f4d86b92-96cd-49e2-aa5d-f2a7fcfe9e64"), new DateTime(2023, 6, 25, 14, 51, 18, 172, DateTimeKind.Local).AddTicks(7840), null, "Test", 1, "Test", null }
                });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "CreatedDate", "DeckName", "Description", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a80f8082-3567-44a3-8ef5-6be234083f57"), new DateTime(2023, 6, 25, 14, 51, 18, 172, DateTimeKind.Local).AddTicks(7999), "MyTestDeck2", "this is my deck", null },
                    { new Guid("b03be600-2c0a-4b99-adb3-b48e897ae20d"), new DateTime(2023, 6, 25, 14, 51, 18, 172, DateTimeKind.Local).AddTicks(7988), "MyTestDeck1", "this is my deck", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId",
                table: "Cards",
                column: "DeckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");
        }
    }
}
