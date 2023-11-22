using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabDal.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManyStudentId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ManyStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyStudents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ManyStudentId",
                table: "Courses",
                column: "ManyStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_ManyStudents_ManyStudentId",
                table: "Courses",
                column: "ManyStudentId",
                principalTable: "ManyStudents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ManyStudents_ManyStudentId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "ManyStudents");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ManyStudentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ManyStudentId",
                table: "Courses");
        }
    }
}
