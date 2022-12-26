using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuctrService.Persistence.Migrations
{
    public partial class NewTableDeans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deans_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deans_FacultyId",
                table: "Deans",
                column: "FacultyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deans_Id",
                table: "Deans",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deans");
        }
    }
}
