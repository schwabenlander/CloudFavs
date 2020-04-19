using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudFavs.Api.Migrations
{
    public partial class Change_Folder_Model_Property_Owner_to_OwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Folders");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Folders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Folders");

            migrationBuilder.AddColumn<Guid>(
                name: "Owner",
                table: "Folders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
