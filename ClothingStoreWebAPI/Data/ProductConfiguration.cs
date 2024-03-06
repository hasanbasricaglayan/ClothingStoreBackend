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
				}
			];
			builder.HasData(products);
		}
	}
}
