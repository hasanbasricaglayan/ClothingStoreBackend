using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStoreWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Homme" },
                    { 2, "Femme" },
                    { 3, "Enfant" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BillingAddress", "DateOfBirth", "DeliveryAddress", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Grenoble, France", new DateOnly(1999, 1, 1), "Grenoble, France", "mouhammad.nour@gmail.com", "Mouhammad", true, "Nour", "MouhammadN_1", "0606060601" },
                    { 2, "Clermont-Ferrand, France", new DateOnly(2000, 1, 1), "Clermont-Ferrand, France", "hasanbasri.caglayan@gmail.com", "Hasan-Basri", true, "Caglayan", "HasanBasriC_2", "0606060602" },
                    { 3, "Paris, France", new DateOnly(2001, 1, 1), "Paris, France", "victor.hugo@gmail.com", "Victor", false, "Hugo", "VictorH_3", "0606060603" },
                    { 4, "Marseille, France", new DateOnly(2002, 1, 1), "Marseille, France", "albert.camus@gmail.com", "Albert", false, "Camus", "AlbertC_4", "0606060604" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 3, 4), "Validée", 1 },
                    { 2, new DateOnly(2024, 3, 1), "En attente", 1 },
                    { 3, new DateOnly(2024, 2, 29), "Expédiée", 2 },
                    { 4, new DateOnly(2024, 2, 14), "Livrée", 2 },
                    { 5, new DateOnly(2023, 12, 15), "Livrée", 3 },
                    { 6, new DateOnly(2023, 12, 18), "Livrée", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "CategoryId", "Color", "Description", "ImageURL", "Name", "Price", "QuantityInStock", "Size" },
                values: new object[,]
                {
                    { 1, "Charles Tyrwhitt", 1, "Bleu ciel", "Fabriqué en pur coton doux et respirant.", "https://www.charlestyrwhitt.com/on/demandware.static/-/Sites-ctshirts-master/default/dwebe4f658/hi-res/FON0409SKY_COLLAR_DETAIL.jpg", "Chemise col classique homme", 49.75, 1000, "S" },
                    { 2, "Liberto", 2, "Noir", "Robe élégante pour les occasions spéciales.", "https://www.lahalle.com/dw/image/v2/BCHM_PRD/on/demandware.static/-/Sites-lahalle_master/default/dwbeb2b943/robe-de-soiree-droite-manches-longues-noir-femme-vue1-36165600645731061.jpg?sw=1600&sh=1600", "Robe de soirée", 19.989999999999998, 500, "M" },
                    { 3, "Mango Kids", 3, "Bleu foncé", "Jean slim pour un look décontracté.", "https://img01.ztat.net/article/spp-media-p1/84a52eefe191416d8831bbfd7d951685/158458b6cba74cd59725f434bc297b78.jpg?imwidth=1800&filter=packshot", "Jean slim garçon", 9.9900000000000002, 700, "10 ans" },
                    { 5, "Tezenis", 3, "Bleu ciel/Gris", "60% coton, 40% polyester", "https://img01.ztat.net/article/spp-media-p1/e9f7714483f24ce6bf4e7ea017e64fc2/16c300d2b8434a0cbf89e5b6dbc69451.jpg?imwidth=156&filter=packshot", "Pyjama Cartoon", 25.629999999999999, 263, "S" },
                    { 6, "Pinko", 2, "Vert", "Robe longue inspiration Asiatique", "https://img01.ztat.net/article/spp-media-p1/f64de54bbdcc4bb1a4e606378a5fcaae/b62ca0fc6cad4713974bf01fb89cd45c.jpg?imwidth=156&filter=packshot", "SUSHI ABITO - Robe longue", 394.94999999999999, 6, "M" },
                    { 7, "ONLY", 2, "Vert", "Composition: 60% coton, 40% polyester\r\nMatière: Sweat", "https://img01.ztat.net/article/spp-media-p1/3bea6fcc60564c99a2f46a38c97432df/bb8d59aa88f54942ac1ec10c72cc276a.jpg?imwidth=156&filter=packshot", "ONLBROOKE O NECK FLOWER - Sweatshirt", 32.990000000000002, 48, "S" },
                    { 8, "LEVI", 1, "Noir", "Composition: 98% coton, 2% élasthanne", "https://img01.ztat.net/article/spp-media-p1/04a16d77bfc94d65aba8294306692a3b/302bec109d6842bf9de5c16039692710.jpg?imwidth=156", "Pantalon cargo", 48.990000000000002, 855, "L" },
                    { 9, "Jack & Jones", 1, "Blanc", "Composition: 100% coton", "https://img01.ztat.net/article/spp-media-p1/30a2e37ae97d4a499d9178d558151f79/4031697abb324a7ebc982fc69b227842.jpg?imwidth=156&filter=packshot", "JORCALIFLO TEE CREW NECK - T-shirt imprimé", 95.349999999999994, 632, "S" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 49.75, 3 },
                    { 1, 3, 9.9900000000000002, 2 },
                    { 4, 1, 59.990000000000002, 1 },
                    { 5, 2, 19.989999999999998, 1 },
                    { 5, 3, 12.99, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
