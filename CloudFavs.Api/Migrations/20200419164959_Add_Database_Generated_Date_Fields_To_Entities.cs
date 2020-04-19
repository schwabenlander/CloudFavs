using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudFavs.Api.Migrations
{
    public partial class Add_Database_Generated_Date_Fields_To_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Favorites");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Folders",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Folders",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Favorites",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Favorites",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"),
                column: "OwnerId",
                value: new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                column: "OwnerId",
                value: new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"),
                column: "OwnerId",
                value: new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"),
                column: "OwnerId",
                value: new Guid("66a5db8a-47f7-48a5-98f8-80b34452bf34"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Favorites");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Favorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: new Guid("1e114a99-26ad-4e33-9cd1-8c592aabb2bf"),
                columns: new[] { "DateCreated", "OwnerId" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("25641521-06e9-4e89-8425-ef22e365c5a4"),
                column: "OwnerId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("43d0b777-8548-4710-a7b2-fcd8aabf9488"),
                column: "OwnerId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: new Guid("995d12ac-b84c-4dac-bcff-27857a1e9f95"),
                column: "OwnerId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
