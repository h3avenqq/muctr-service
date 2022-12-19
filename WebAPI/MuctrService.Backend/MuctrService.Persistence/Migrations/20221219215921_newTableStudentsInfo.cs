using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuctrService.Persistence.Migrations
{
    public partial class newTableStudentsInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsInfo_Id",
                table: "StudentsInfo",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsInfo");
        }
    }
}
