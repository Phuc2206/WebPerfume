using dA.Data.JsonViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using X.PagedList;

namespace dA.Data.Repositories
{
	public class ProductRepo : RepositoriesBase
	{
		//public ProductRepo() : base() { }
		public ProductRepo(DoAnContext _db) : base(_db) { }

		public async Task<bool> AddAsync(AppProduct model)
		{

			try
			{
				model.CreateDate = DateTime.Now;
				model.UpdateDate = DateTime.Now;
				model.Sold = 0;
				if (model.Price != null)
				{
					model.Price = decimal.Parse(model.Price.ToString().Replace('.', ' ').Replace(',', ' '));
				}
				if (model.PromoPrice != null)
				{
					model.PromoPrice = decimal.Parse(model.PromoPrice.ToString().Replace('.', ' ').Replace(',', ' '));
				}
				if (model.PromoPrice == null) {
					model.PromoPrice = 0;
				};
				await db.AddAsync(model);
				await db.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
		
		public async Task<bool> UpdateAsync(AppProduct model)
		{
			try
			{
				AppProduct prop =await db.AppProduct.FindAsync(model.Id);
				prop.Name = model.Name;
				prop.Summary = model.Summary;
				prop.Description = model.Description;
				prop.DisplayOrder = model.DisplayOrder;
				if (model.Price != null)
				{
					prop.Price = decimal.Parse(model.Price.ToString().Replace('.', ' ').Replace(',',' '));
				}	
				if(model.PromoPrice !=null)
				{
					prop.PromoPrice = decimal.Parse(model.PromoPrice.ToString().Replace('.', ' ').Replace(',', ' '));
				}	

				if (model.CategoryId != null)
				{
					prop.CategoryId = model.CategoryId;
				}
				if(model.UrlPicture != null)
				{
					prop.UrlPicture = model.UrlPicture;
				}	
				if(model.ListProductPicture != null)
				{
					prop.ListProductPicture = model.ListProductPicture;
				}	
				if(model.ListSizeNavigation !=null)
				{
					prop.ListSizeNavigation = model.ListSizeNavigation;
				}	
				await db.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
		public async Task<AppProduct> FindId(int id)
		{
			return await db.AppProduct.FindAsync(id);
		}

		public async Task<List<ProductListItemJM>> ListAsync(int Page , int PageSize)
		{
			return await db.AppProduct.Select(x => new ProductListItemJM
			{
				Id = x.Id,
				Name = x.Name,
				Price = x.Price,
				PromoPrice = x.PromoPrice,
				Sold = x.Sold,
				DisplayOrder = x.DisplayOrder,
				CateName = x.CategoryNavigation.Name,
				ImgName = x.UrlPicture
			}).OrderBy(x => x.Name).Skip((Page-1)*PageSize).Take(PageSize).ToListAsync();
		}
		public async Task<List<GetItemCategoryJM>> GetCategories()
		{
			return await db.AppCategory
				.Select(x => new GetItemCategoryJM
				{
					Id = x.Id,
					Name = x.Name,
					DisplayOrder = x.DisplayOrder
				}).OrderByDescending(x => x.DisplayOrder).ToListAsync();
		}

		public async Task<AppProduct> GetOneProduct(int? id)
		{
			AppProduct prod =await db.AppProduct
				.Include(s => s.ListSizeNavigation)
				.Where(x => x.Id == id).SingleOrDefaultAsync();
			if (prod != null)
			{
				return prod;
			}
			return null;
		}

		// lấy dữ liệu cho trang details 
		public async Task<AppProduct> GetOneDetailAsync(int id)
		{
			return await db.AppProduct.Include( x=>x.CategoryNavigation)
									.Where(x => x.Id == id)
									.OrderBy(x => x.DisplayOrder)
									.SingleOrDefaultAsync();
		}
		// lấy Img cho trang details GetOneSizeProduct
		public async Task<List<AppPicture>> GetImgDetailAsync(int id)
		{
			return await db.AppPictures
									.Where(x => x.ProducId == id)
									.OrderByDescending(x => x.Id)
									.ToListAsync();
		}
		public async Task<string> GetOneImgProduct(int id)
		{
			var prod =  await db.AppPictures
									.Where(x => x.ProducId == id)
									.OrderByDescending(x => x.Id)
									.ToListAsync();
			string NameImg = "";
			foreach(var item in prod)
			{
				 NameImg = item.Name;
				break;
			}	
			return NameImg;
		}
		public async Task<AppSize> GetOneSizeProduct(int id)
		{
			return await db.AppSize
									.Where(x => x.Id == id)
									.OrderByDescending(x => x.Id)
									.SingleOrDefaultAsync();
		}
		// xóa sản phẩm 
		public async Task<bool> DeleteAsync(int id)
		{
			var prod = await db.AppProduct.Include(s =>s.ListProductPicture)
										  .Include( x =>x.ListSizeNavigation)
										  .Include(i=> i.ListSizeNavigation)
										  .Where( i => i.Id == id)
										  .ToListAsync(); 
			if(prod !=null)
			{
				foreach(var ItemProd in prod)
				{
					foreach(var ItemPicture in ItemProd.ListProductPicture)
					{
						if (ItemPicture != null)
						{
							db.RemoveRange(ItemPicture);
						}
					}	
					foreach(var ItemSize in ItemProd.ListSizeNavigation)
					{
						if(ItemSize != null)
						{
							db.RemoveRange(ItemSize);
						}	
					}	
				}	
				db.AppProduct.RemoveRange(prod);
				await db.SaveChangesAsync();
				return true;
			}	
			return false;
		}


		// lấy dữ liệu và phân trang dử liệu cho phía người dùng
		public  IPagedList<ProductListItemJM> ShowListProduct(int page, int size)
		{
			return  db.AppProduct.Select(x => new ProductListItemJM
			{
				Id = x.Id,
				Name = x.Name,
				Price = x.Price,
				PromoPrice = x.PromoPrice,
				Sold = x.Sold,
				DisplayOrder = x.DisplayOrder,
				CateName = x.CategoryNavigation.Name,
				ImgName = x.UrlPicture,
				ListProductPicture = x.ListProductPicture
			}).OrderBy(x => x.DisplayOrder).ToPagedList(page, size);
		}
		public IPagedList<ProductListItemJM> ShowListProductSearch(string searchString, int page, int size)
		{
			var regexString = '.' + searchString + '.';
			Regex regex = new Regex(regexString);
			string lowerSearchString = searchString.ToLower();
			var result = db.AppProduct.Select(x => new ProductListItemJM
			{
				Id = x.Id,
				Name = x.Name,
				Price = x.Price,
				PromoPrice = x.PromoPrice,
				Sold = x.Sold,
				DisplayOrder = x.DisplayOrder,
				CateName = x.CategoryNavigation.Name,
				ImgName = x.UrlPicture,
				ListProductPicture = x.ListProductPicture
			}).OrderBy(x => x.DisplayOrder).Where(x => x.Name.ToLower().Contains(lowerSearchString)).ToPagedList(page, size);
			return result;
		}

		public async Task<AppProduct> GetDetailtProduct(int? id)
		{
			return await db.AppProduct.Include(x=>x.ListProductPicture)
										.Where(x => x.Id == id)
										.SingleOrDefaultAsync(); ;
		}

		// Get Row count Product dùng cho phân trang
		public async Task<int> GetRowCountProduct()
		{
			return await db.AppProduct.CountAsync();
		}

		public async Task<List<AppSize>> GetListSize(int? id)
		{
			return await db.AppSize
								.Where(x => x.ProductId == id )
								.OrderBy(x => x.Name)
								.ToListAsync();
		}


	}
}
