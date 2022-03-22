﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNotesApi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreationTime", "ModifiedTime", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ut sapien id purus sagittis pellentesque. Donec egestas quam ut lorem semper, nec varius tortor congue. Nam est mauris, dictum non nunc at, tempus tristique odio. Pellentesque iaculis tortor sem, in elementum magna eleifend ut.", new DateTime(2022, 3, 22, 10, 42, 6, 238, DateTimeKind.Local).AddTicks(4551), new DateTime(2022, 3, 22, 10, 42, 6, 239, DateTimeKind.Local).AddTicks(3572), "Sample Note 1" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Content", "CreationTime", "ModifiedTime", "Title" },
                values: new object[] { 2, "Etiam eu ligula fringilla mi placerat convallis. Aliquam tempus, mauris id tempus commodo, quam justo gravida nibh, scelerisque condimentum metus velit et felis. Morbi mi ipsum, maximus blandit condimentum ut, consectetur vitae ante. Ut viverra mollis metus, sollicitudin gravida felis imperdiet sed.", new DateTime(2022, 3, 22, 10, 42, 6, 239, DateTimeKind.Local).AddTicks(4603), new DateTime(2022, 3, 22, 10, 42, 6, 239, DateTimeKind.Local).AddTicks(4608), "Sample Note 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}