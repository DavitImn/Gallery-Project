using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gallery.Repository.Migrations
{
    public partial class AddComplexType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GalleryItems",
                newName: "Published_Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "GalleryItems",
                newName: "Published_Description");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "GalleryItems",
                newName: "Published_Data");

            migrationBuilder.AlterColumn<string>(
                name: "Published_Name",
                table: "GalleryItems",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Published_Description",
                table: "GalleryItems",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Published_Data",
                table: "GalleryItems",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Draft_Data",
                table: "GalleryItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Draft_Description",
                table: "GalleryItems",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Draft_Name",
                table: "GalleryItems",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draft_Data",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "Draft_Description",
                table: "GalleryItems");

            migrationBuilder.DropColumn(
                name: "Draft_Name",
                table: "GalleryItems");

            migrationBuilder.RenameColumn(
                name: "Published_Name",
                table: "GalleryItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Published_Description",
                table: "GalleryItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Published_Data",
                table: "GalleryItems",
                newName: "Data");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GalleryItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "GalleryItems",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "GalleryItems",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
