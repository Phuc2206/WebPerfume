using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class TrademarkRepo : RepositoriesBase
	{
		//public TrademarkRepo() : base() { }
		public TrademarkRepo(DoAnContext _db) : base(_db) { }
		public async Task<bool> AddAsync(AppTrademark model)
		{
			try
			{
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
		public async Task<bool> UpdateAsync(AppTrademark model)
		{
			try
			{
				int id = model.Id;
				AppTrademark prod = await db.AppTrademark.FindAsync(id);
				prod.Name = model.Name;
				if(model.Avatar != null)
				{
					prod.Avatar = model.Avatar;
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
		
		public async Task<AppTrademark> FindIdAsync(int id)
		{
			return await db.AppTrademark.FindAsync(id);
		}

		public async Task<bool> DeleteAysnc(int id)
		{
			try
			{
				var prod = await db.AppTrademark.Include(s =>s.ListCategory).Where(x=>x.Id == id).ToListAsync();
				foreach(var item in prod)
				{
					item.ListCategory = null;
				}
				db.AppTrademark.RemoveRange(prod);
				await db.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		public async Task<List<AppTrademark>> ListAsync(int Page,int PageSize)
		{
			return await db.AppTrademark.OrderByDescending(x => x.Id).Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync();
		}
		public async Task<int> GetRowCountTradermark()
		{
			return await db.AppTrademark.CountAsync();
		}

		public async void AddImg(AppTrademark model ,IFormFileCollection files)
		{
			if (files.Count == 1)
			{
				var projectPath = Directory.GetCurrentDirectory();
				var fileName = files[0].FileName;
				var fullPath = projectPath + "/wwwroot/Images/Trademarks/" + fileName;
				var stream = System.IO.File.Create(fullPath);
				await files[0].CopyToAsync(stream);
				await stream.DisposeAsync();
				model.Avatar = files[0].FileName;
			}
		}
	}
}
