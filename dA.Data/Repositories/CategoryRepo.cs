using dA.Data.JsonViewModels.Category;
using dA.Data.JsonViewModels.Trademarks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class CategoryRepo : RepositoriesBase
	{
		//public CategoryRepo() : base() { }
		public CategoryRepo(DoAnContext _db) : base(_db) { }

		public async Task<bool> AddAsync(AppCategory model)
		{
			if (model != null)
			{
				try
				{
					model.CreateDate = DateTime.Now;
					model.UpdateDate = DateTime.Now;
					model.TotalProduct = 0;
					await db.AddAsync(model);
					await db.SaveChangesAsync();
					return true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		public async Task<bool> UpdateAsync(AppCategory model)
		{
			try
			{
				var prod = db.AppCategory.Find(model.Id);
				prod.Name = model.Name;
				prod.DisplayOrder = model.DisplayOrder;
				if (model.TrademarkId != null)
				{
					prod.TrademarkId = model.TrademarkId;
				}
				prod.UpdateDate = DateTime.Now;
				await db.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<int> GetRowCount()
		{
			return await db.AppCategory.CountAsync();
		}
		public async Task<List<CategoryJM>> ListAsync(int Page,int PageSize)
		{
			return await db.AppCategory.Select(x => new CategoryJM
			{
				Id = x.Id,
				Name = x.Name,
				TotalProduct = x.TotalProduct,
				TrademarkId = x.ListTrademark.Name
			}).OrderByDescending(x => x.Id).Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync();

		}

		public async Task<List<TrademarkItemJM>> GetTrademark()
		{
			return await db.AppTrademark.Select(x => new TrademarkItemJM
			{
				Id = x.Id,
				Name = x.Name
			}).OrderByDescending(x => x.Id).ToListAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var prod = await db.AppCategory.Include(x => x.ListProduct).Where(i => i.Id == id).ToListAsync();
			if (prod != null)
			{
				foreach (var item in prod)
				{
					if (item.ListProduct != null)
					{
						item.ListProduct = null;
					}
				}
				db.AppCategory.RemoveRange(prod);
				await db.SaveChangesAsync();
				return true;
			}
			return false;
		}
		public async Task<CategoryJM> GetOneAsync(int id)
		{
			return await db.AppCategory.Include(x => x.ListTrademark).Select(x => new CategoryJM
					{
						Id = x.Id,
						Name = x.Name,
						DisplayOrder = x.DisplayOrder,
						TotalProduct = x.TotalProduct,
						TrademarkId = x.ListTrademark.Name
					}).Where(x => x.Id == id).OrderByDescending(x => x.Id).SingleOrDefaultAsync();
		}
	}
}
