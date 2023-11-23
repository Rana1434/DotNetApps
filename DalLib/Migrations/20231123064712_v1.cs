using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DalLib.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.custId);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    shoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shoePrice = table.Column<double>(type: "float", nullable: false),
                    shoeStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shoeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shoeSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.shoeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<int>(type: "int", nullable: false),
                    CustomercustId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomercustId",
                        column: x => x.CustomercustId,
                        principalTable: "Customer",
                        principalColumn: "custId");
                });

            migrationBuilder.CreateTable(
                name: "OrderShoes",
                columns: table => new
                {
                    orderedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrdersorderId = table.Column<int>(type: "int", nullable: true),
                    ShoesshoeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShoes", x => x.orderedId);
                    table.ForeignKey(
                        name: "FK_OrderShoes_Orders_OrdersorderId",
                        column: x => x.OrdersorderId,
                        principalTable: "Orders",
                        principalColumn: "orderId");
                    table.ForeignKey(
                        name: "FK_OrderShoes_Shoes_ShoesshoeId",
                        column: x => x.ShoesshoeId,
                        principalTable: "Shoes",
                        principalColumn: "shoeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomercustId",
                table: "Orders",
                column: "CustomercustId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShoes_OrdersorderId",
                table: "OrderShoes",
                column: "OrdersorderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShoes_ShoesshoeId",
                table: "OrderShoes",
                column: "ShoesshoeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderShoes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
