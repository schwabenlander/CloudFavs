using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudFavs.Api.Migrations
{
    public partial class Rename_LastUpdated_to_LastModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Favorites");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Folders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Favorites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"),
                column: "LastModified",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                column: "LastModified",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"),
                column: "LastModified",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"),
                column: "LastModified",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Favorites");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Folders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Favorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"),
                column: "LastUpdated",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                column: "LastUpdated",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"),
                column: "LastUpdated",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"),
                column: "LastUpdated",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
