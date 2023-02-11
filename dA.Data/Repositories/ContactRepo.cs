using dA.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class ContactRepo : RepositoriesBase
	{
		//public ContactRepo() : base() { }
		public ContactRepo(DoAnContext _db) : base(_db) { }

		public async Task<bool> AddAsync(AppContact model)
		{
			model.DateSent = DateTime.Now;
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
		public async Task<AppContact> FindIdAsync(int id)
		{
			return await db.AppContacts.FindAsync(id);
		}
		public async Task<List<AppContact>> ListAsync(int Page, int PageSize)
		{
			return await db.AppContacts.OrderByDescending(x => x.Id)
				.Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync();
		}
		public async Task<int> GetRowCountTradermark()
		{
			return await db.AppContacts.CountAsync();
		}
	}
}
