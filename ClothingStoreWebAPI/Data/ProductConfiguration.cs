using ClothingStoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingStoreWebAPI.Data
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			Product[] products =
			[
				new Product
				{
					ProductId = 1,
					CategoryId = 1,
					Brand = "Charles Tyrwhitt",
					Name = "Chemise col classique homme",
					Color = "Bleu ciel",
					Size = "S",
					Price = 49.75,
					Description = "Fabriqué en pur coton doux et respirant.",
					QuantityInStock = 1000,
					ImageURL = "https://www.charlestyrwhitt.com/on/demandware.static/-/Sites-ctshirts-master/default/dwebe4f658/hi-res/FON0409SKY_COLLAR_DETAIL.jpg"
				},
				new Product
				{
					ProductId = 2,
					CategoryId = 2,
					Brand = "Liberto",
					Name = "Robe de soirée",
					Color = "Noir",
					Size = "M",
					Price = 19.99,
					Description = "Robe élégante pour les occasions spéciales.",
					QuantityInStock = 500,
					ImageURL = "https://www.lahalle.com/dw/image/v2/BCHM_PRD/on/demandware.static/-/Sites-lahalle_master/default/dwbeb2b943/robe-de-soiree-droite-manches-longues-noir-femme-vue1-36165600645731061.jpg?sw=1600&sh=1600"
				},
				new Product
				{
					ProductId = 3,
					CategoryId = 3,
					Brand = "Mango Kids",
					Name = "Jean slim garçon",
					Color = "Bleu foncé",
					Size = "10 ans",
					Price = 9.99,
					Description = "Jean slim pour un look décontracté.",
					QuantityInStock = 700,
					ImageURL = "https://img01.ztat.net/article/spp-media-p1/84a52eefe191416d8831bbfd7d951685/158458b6cba74cd59725f434bc297b78.jpg?imwidth=1800&filter=packshot"
				},
				new Product
				{
					ProductId = 5,
					CategoryId = 3,
					Brand = "Tezenis",
					Name = "Pyjama Cartoon",
					Color = "Bleu ciel/Gris",
					Size = "S",
					Price = 25.63,
					Description = "60% coton, 40% polyester",
					QuantityInStock = 263,
					ImageURL = "https://img01.ztat.net/article/spp-media-p1/e9f7714483f24ce6bf4e7ea017e64fc2/16c300d2b8434a0cbf89e5b6dbc69451.jpg?imwidth=156&filter=packshot",
				},
				new Product
				{
					ProductId = 6,
					CategoryId = 2,
					Brand = "Pinko",
					Name = "SUSHI ABITO - Robe longue",
					Color = "Vert",
					Size = "M",
					Price = 394.95,
					Description = "Robe longue inspiration Asiatique",
					QuantityInStock = 6,
					ImageURL = "https://img01.ztat.net/article/spp-media-p1/f64de54bbdcc4bb1a4e606378a5fcaae/b62ca0fc6cad4713974bf01fb89cd45c.jpg?imwidth=156&filter=packshot",


				},
				new Product
				{
					ProductId = 7,
					CategoryId = 2,
					Brand = "ONLY",
					Name = "ONLBROOKE O NECK FLOWER - Sweatshirt",
					Color = "Vert",
					Size = "S",
					Price = 32.99,
					Description = "Composition: 60% coton, 40% polyester\r\nMatière: Sweat",
					QuantityInStock = 48,
					ImageURL = "https://img01.ztat.net/article/spp-media-p1/3bea6fcc60564c99a2f46a38c97432df/bb8d59aa88f54942ac1ec10c72cc276a.jpg?imwidth=156&filter=packshot",


				},
				new Product
				{
					ProductId = 8,
					CategoryId = 1,
					Brand = "LEVI",
					Name = "Pantalon cargo",
					Color = "Noir",
					Size = "L",
					Price = 48.99,
					Description = "Composition: 98% coton, 2% élasthanne",
					QuantityInStock = 855,
					ImageURL = "https://img01.ztat.net/article/spp-media-p1/04a16d77bfc94d65aba8294306692a3b/302bec109d6842bf9de5c16039692710.jpg?imwidth=156",


				},
				new Product
				{
					ProductId = 9,
					CategoryId = 1,
					Brand = "Jack & Jones",
					Name = "JORCALIFLO TEE CREW NECK - T-shirt imprimé",
					Color = "Blanc",
					Size = "S",
					Price = 95.35,
					Description = "Composition: 100% coton",
					QuantityInStock = 632,
					ImageURL = "https://img01.ztat.net/article/spp-media-p1/30a2e37ae97d4a499d9178d558151f79/4031697abb324a7ebc982fc69b227842.jpg?imwidth=156&filter=packshot",


				},
			];
			builder.HasData(products);
		}
	}
}
