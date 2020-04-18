using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudFavs.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Owner = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    FolderId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IsPinned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "Owner" },
                values: new object[] { new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"), "Learning", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "Owner" },
                values: new object[] { new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"), "News", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "Owner" },
                values: new object[] { new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"), "Games", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "Id", "DateCreated", "FolderId", "IsPinned", "Name", "OwnerId", "Uri" },
                values: new object[] { new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"), true, "BBC News", new Guid("00000000-0000-0000-0000-000000000000"), "http://www.bbcnews.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_FolderId",
                table: "Favorites",
                column: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
