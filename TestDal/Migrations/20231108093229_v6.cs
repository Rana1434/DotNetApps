using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDal.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "toManyId",
                table: "Ones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tooMany1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tooMany1s", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ones_toManyId",
                table: "Ones",
                column: "toManyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ones_tooMany1s_toManyId",
                table: "Ones",
                column: "toManyId",
                principalTable: "tooMany1s",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ones_tooMany1s_toManyId",
                table: "Ones");

            migrationBuilder.DropTable(
                name: "tooMany1s");

            migrationBuilder.DropIndex(
                name: "IX_Ones_toManyId",
                table: "Ones");

            migrationBuilder.DropColumn(
                name: "toManyId",
                table: "Ones");
        }
    }
}
