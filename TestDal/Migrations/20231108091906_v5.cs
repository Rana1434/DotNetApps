using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDal.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeofChild2",
                table: "Parents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDateOfChild2",
                table: "Parents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "toOnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatedToOneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toOnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_toOnes_Ones_RelatedToOneId",
                        column: x => x.RelatedToOneId,
                        principalTable: "Ones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_toOnes_RelatedToOneId",
                table: "toOnes",
                column: "RelatedToOneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toOnes");

            migrationBuilder.DropTable(
                name: "Ones");

            migrationBuilder.DropColumn(
                name: "AgeofChild2",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "BirthDateOfChild2",
                table: "Parents");
        }
    }
}
