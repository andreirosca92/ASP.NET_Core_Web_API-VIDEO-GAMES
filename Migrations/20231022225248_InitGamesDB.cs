using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_API_GAMES.Migrations
{
    /// <inheritdoc />
    public partial class InitGamesDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Developer");

            migrationBuilder.EnsureSchema(
                name: "GameDeveloper");

            migrationBuilder.EnsureSchema(
                name: "Games");

            migrationBuilder.EnsureSchema(
                name: "Inventories");

            migrationBuilder.EnsureSchema(
                name: "OrderItems");

            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.EnsureSchema(
                name: "Publisher");

            migrationBuilder.CreateTable(
                name: "Developer",
                schema: "Developer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SubTotal = table.Column<double>(type: "double precision", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "Games",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: true),
                    Platform = table.Column<string>(type: "text", nullable: true),
                    Conditions = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalSchema: "Publisher",
                        principalTable: "Publisher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameDeveloper",
                schema: "GameDeveloper",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDeveloper", x => new { x.GameId, x.DeveloperId });
                    table.ForeignKey(
                        name: "FK_GameDeveloper_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "Developer",
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDeveloper_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "Games",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                schema: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StockLevelNew = table.Column<string>(type: "text", nullable: false),
                    StockLevelUsed = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Games_Id",
                        column: x => x.Id,
                        principalSchema: "Games",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "OrderItems",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.GameId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "Games",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Orders",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Developer",
                table: "Developer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("587644c5-9947-456b-99ee-5f2da10ac5ea"), "4A Games" },
                    { new Guid("fe1db982-53e8-481f-830b-11f79c3a5bde"), "Infinity Ward" }
                });

            migrationBuilder.InsertData(
                schema: "Games",
                table: "Games",
                columns: new[] { "Id", "Conditions", "Description", "Genre", "Name", "Platform", "PublisherId", "Rating", "Time" },
                values: new object[,]
                {
                    { new Guid("260f8851-336d-4c72-9917-e3d7af61b790"), "NEW", "Modern Warfare 3 is a first-person shooter video game much like its predecessors. Modern Warfare 3 for Microsoft Windows has dedicated server support.", "First_Person_shooter", "Call of Duty: Modern Warfare 3", "WINDOWS", null, 10.0, new DateTime(2023, 10, 23, 0, 52, 48, 183, DateTimeKind.Local).AddTicks(566) },
                    { new Guid("e82b4a7b-d40b-4436-b97e-3425a9a557dc"), "NEW", "Metro 2033", "First_Person_shooter", "Metro 2033", "PS5", null, 9.0, new DateTime(2023, 10, 23, 0, 52, 48, 183, DateTimeKind.Local).AddTicks(911) }
                });

            migrationBuilder.InsertData(
                schema: "Publisher",
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b23737ed-6ac3-40a5-830b-e25f00727f81"), "THQ" },
                    { new Guid("c0b0220a-630a-4bf8-8850-f9845e6def31"), "Activision" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDeveloper_DeveloperId",
                schema: "GameDeveloper",
                table: "GameDeveloper",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                schema: "Games",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_GameId",
                schema: "OrderItems",
                table: "OrderItems",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDeveloper",
                schema: "GameDeveloper");

            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "OrderItems");

            migrationBuilder.DropTable(
                name: "Developer",
                schema: "Developer");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "Games");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Publisher",
                schema: "Publisher");
        }
    }
}
