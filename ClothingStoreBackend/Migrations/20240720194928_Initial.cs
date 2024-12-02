using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStoreBackend.Migrations
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
                    { 1, "Chemises" },
                    { 2, "T-shirts" },
                    { 3, "Polos" },
                    { 4, "Sweats" },
                    { 5, "Pulls" },
                    { 6, "Gilets" },
                    { 7, "Vestes" },
                    { 8, "Blousons" },
                    { 9, "Manteaux" },
                    { 10, "Pantalons" },
                    { 11, "Jeans" },
                    { 12, "Costumes" },
                    { 13, "Chaussures" },
                    { 14, "Accessoires" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BillingAddress", "DateOfBirth", "DeliveryAddress", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Adresse de facturation 1", new DateOnly(2024, 7, 20), "Adresse de livraison 1", "email_1@mail.com", "Prénom 1", true, "Nom 1", "Password_1", "+331" },
                    { 2, "Adresse de facturation 2", new DateOnly(2024, 7, 20), "Adresse de livraison 2", "email_2@mail.com", "Prénom 2", true, "Nom 2", "Password_2", "+332" },
                    { 3, "Adresse de facturation 3", new DateOnly(2024, 7, 20), "Adresse de livraison 3", "email_3@mail.com", "Prénom 3", false, "Nom 3", "Password_3", "+333" },
                    { 4, "Adresse de facturation 4", new DateOnly(2024, 7, 20), "Adresse de livraison 4", "email_4@mail.com", "Prénom 4", false, "Nom 4", "Password_4", "+334" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 7, 20), "Livrée", 1 },
                    { 2, new DateOnly(2024, 7, 20), "En attente", 2 },
                    { 3, new DateOnly(2024, 7, 20), "Validée", 2 },
                    { 4, new DateOnly(2024, 7, 20), "Expédiée", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "CategoryId", "Color", "Description", "ImageURL", "Name", "Price", "QuantityInStock", "Size" },
                values: new object[,]
                {
                    { 1, "Marque 1", 1, "Couleur 1", "Description 1", "https://placehold.co/300x400", "Produit 1", 1.0, 100, "Taille 1" },
                    { 2, "Marque 2", 1, "Couleur 2", "Description 2", "https://placehold.co/300x400", "Produit 2", 2.0, 200, "Taille 2" },
                    { 3, "Marque 3", 2, "Couleur 3", "Description 3", "https://placehold.co/300x400", "Produit 3", 3.0, 300, "Taille 3" },
                    { 4, "Marque 4", 2, "Couleur 4", "Description 4", "https://placehold.co/300x400", "Produit 4", 4.0, 400, "Taille 4" },
                    { 5, "Marque 5", 3, "Couleur 5", "Description 5", "https://placehold.co/300x400", "Produit 5", 5.0, 500, "Taille 5" },
                    { 6, "Marque 6", 3, "Couleur 6", "Description 6", "https://placehold.co/300x400", "Produit 6", 6.0, 600, "Taille 6" },
                    { 7, "Marque 7", 4, "Couleur 7", "Description 7", "https://placehold.co/300x400", "Produit 7", 7.0, 700, "Taille 7" },
                    { 8, "Marque 8", 4, "Couleur 8", "Description 8", "https://placehold.co/300x400", "Produit 8", 8.0, 800, "Taille 8" },
                    { 9, "Marque 9", 5, "Couleur 9", "Description 9", "https://placehold.co/300x400", "Produit 9", 9.0, 900, "Taille 9" },
                    { 10, "Marque 10", 5, "Couleur 10", "Description 10", "https://placehold.co/300x400", "Produit 10", 10.0, 1000, "Taille 10" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 10.99, 2 },
                    { 1, 2, 20.989999999999998, 3 },
                    { 1, 3, 30.989999999999998, 1 },
                    { 2, 4, 4.9900000000000002, 1 },
                    { 2, 5, 5.9900000000000002, 2 },
                    { 3, 6, 6.9900000000000002, 1 },
                    { 4, 7, 7.9900000000000002, 4 }
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
