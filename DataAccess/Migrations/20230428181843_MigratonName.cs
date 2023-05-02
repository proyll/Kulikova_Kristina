using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filterr",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false),
                    category_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    subcategory_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    name_p = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    popular = table.Column<bool>(type: "bit", nullable: false),
                    material = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    size = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    sale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Filterr__D54EE9B4E4112E57", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Userss",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    user_email = table.Column<string>(type: "varchar(127)", unicode: false, maxLength: 127, nullable: true),
                    user_role = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    user_passord = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    name_p = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description_p = table.Column<string>(type: "varchar(127)", unicode: false, maxLength: 127, nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    product_availability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__Product__categor__29572725",
                        column: x => x.category_id,
                        principalTable: "Filterr",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK__Cart__customer_i__300424B4",
                        column: x => x.customer_id,
                        principalTable: "Userss",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DescriptionProduct",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    text_d = table.Column<string>(type: "varchar(436)", unicode: false, maxLength: 436, nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Descript__0BD4214D258BD463", x => new { x.product_id, x.customer_id });
                    table.ForeignKey(
                        name: "FK__Descripti__custo__2D27B809",
                        column: x => x.customer_id,
                        principalTable: "Userss",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Descripti__produ__2C3393D0",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: true),
                    status_b = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: false),
                    delivery = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    address_b = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK__Booking__cart_id__36B12243",
                        column: x => x.cart_id,
                        principalTable: "Cart",
                        principalColumn: "cart_id");
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    cart_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartItem__25ED2F5783B48207", x => new { x.product_id, x.cart_id });
                    table.ForeignKey(
                        name: "FK__CartItem__cart_i__33D4B598",
                        column: x => x.cart_id,
                        principalTable: "Cart",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "FK__CartItem__produc__32E0915F",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_cart_id",
                table: "Booking",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_customer_id",
                table: "Cart",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_cart_id",
                table: "CartItem",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionProduct_customer_id",
                table: "DescriptionProduct",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Userss__B0FBA212A4228677",
                table: "Userss",
                column: "user_email",
                unique: true,
                filter: "[user_email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "DescriptionProduct");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Userss");

            migrationBuilder.DropTable(
                name: "Filterr");
        }
    }
}
