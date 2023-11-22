using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabDal.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManyCourseId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ManyCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyCourses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ManyCourseId",
                table: "Students",
                column: "ManyCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ManyCourses_ManyCourseId",
                table: "Students",
                column: "ManyCourseId",
                principalTable: "ManyCourses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_ManyCourses_ManyCourseId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ManyCourses");

            migrationBuilder.DropIndex(
                name: "IX_Students_ManyCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ManyCourseId",
                table: "Students");
        }
    }
}
