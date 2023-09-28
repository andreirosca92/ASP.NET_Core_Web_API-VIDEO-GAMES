using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_API_GAMES.Migrations
{
    /// <inheritdoc />
    public partial class DBGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
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
                name: "Publisher",
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
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Genre = table.Column<int>(type: "integer", nullable: true),
                    Platform = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uuid", nullable: true),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ccb4bb29-1c2c-4ba1-9605-d8349ae4abd3"), "4A Games" },
                    { new Guid("d1456296-16ea-4e11-ab71-a2d59805000d"), "Infinity Ward" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("156b737b-1f6c-4977-bebd-c4a01307b781"), "Activision" },
                    { new Guid("2cb2beed-c229-4c9f-9a08-df385ec0d548"), "THQ" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DeveloperId", "Genre", "Name", "Platform", "PublisherId", "Rating", "Time" },
                values: new object[,]
                {
                    { new Guid("79279c60-511f-45e5-99b5-e974ba347fca"), "Metro 2033", new Guid("ccb4bb29-1c2c-4ba1-9605-d8349ae4abd3"), 2, "Metro 2033", 1, new Guid("2cb2beed-c229-4c9f-9a08-df385ec0d548"), 9.0, new DateTime(2023, 9, 28, 23, 56, 25, 492, DateTimeKind.Local).AddTicks(3613) },
                    { new Guid("ccb4bb29-1c2c-4ba1-9605-d8349ae4abd3"), "Modern Warfare 3 is a first-person shooter video game much like its predecessors. Modern Warfare 3 for Microsoft Windows has dedicated server support.", new Guid("d1456296-16ea-4e11-ab71-a2d59805000d"), 2, "Call of Duty: Modern Warfare 3", 0, new Guid("156b737b-1f6c-4977-bebd-c4a01307b781"), 10.0, new DateTime(2023, 9, 28, 23, 56, 25, 492, DateTimeKind.Local).AddTicks(3536) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
