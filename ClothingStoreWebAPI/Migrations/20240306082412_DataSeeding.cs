using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStoreWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "UserId", "BillingAdress", "DateOfBirth", "DeliveryAdress", "Email", "FirstName", "IsAdmin", "LastName", "Password", "PhoneNumber" },
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
                    { 3, "Mango Kids", 3, "Bleu foncé", "Jean slim pour un look décontracté.", "https://img01.ztat.net/article/spp-media-p1/84a52eefe191416d8831bbfd7d951685/158458b6cba74cd59725f434bc297b78.jpg?imwidth=1800&filter=packshot", "Jean slim garçon", 9.9900000000000002, 700, "10 ans" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
