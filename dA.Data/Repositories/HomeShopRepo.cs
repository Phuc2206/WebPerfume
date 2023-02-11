using dA.Data.JsonViewModels.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class HomeShopRepo : RepositoriesBase
	{
		//public HomeShopRepo() : base() { }
		public HomeShopRepo(DoAnContext _db) : base(_db) { }

		// lay nhung product Most Popular Sneakers  
		public async Task<List<ProductListItemJM>> GetProductPopular()
		{
			return await db.AppProduct.Include(x =>x.ListProductPicture)
			.Select(x => new ProductListItemJM
			{
				Id = x.Id,
				Name = x.Name,
				Price = x.Price,
				PromoPrice = x.PromoPrice,
				Sold = x.Sold,
				DisplayOrder = x.DisplayOrder,
				CateName = x.CategoryNavigation.Name,
				ListProductPicture = x.ListProductPicture
			}).OrderBy(x => x.DisplayOrder).Take(10).ToListAsync();
		}

		public async Task<List<AppTrademark>> GetTrademarkPopular()
		{
			return await db.AppTrademark.ToListAsync();
		}
	}
}
