using dA.Data.JsonViewModels.Customer;
using dA.Data.JsonViewModels.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class UserCustomerRepo : RepositoriesBase
	{
		//public UserCustomerRepo() : base() { }
		public UserCustomerRepo(DoAnContext _db) : base(_db) { }

		public async Task<AppCustomer> FindAsync(int? id)
		{
			return await db.AppCustomer.FindAsync(id);
		}

		public async Task<int> GetRowCountCustomer()
		{
			return await db.AppCustomer.CountAsync();
		}

		public async Task<List<ItemCustomerJM>> ListAsync(int Page, int PageSize)
		{ 
				return await db.AppCustomer.Select(x => new ItemCustomerJM
				{
					id = x.id,
					Name = x.Name,
					Username = x.Username,
					Email = x.Email, 
					IsLock = x.IsLock
				}).OrderByDescending(x => x.id).Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync();
		}
		public async Task<AppCustomer> FindAsync(int id)
		{
			return await db.AppCustomer.FindAsync(id);
		}

		public async Task<bool> UpdateAsync(AppCustomer model)
		{
			try
			{
				var prod = db.AppCustomer.Find(model.id);
				prod.Name = model.Name;
				prod.Username = model.Username;
				prod.PhoneNumber = model.PhoneNumber;
				prod.IsLock = model.IsLock;
				prod.Email = model.Email;
				await Save();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> DeleteAsync(int id)
		{
			var prod = await db.AppCustomer.Where(i => i.id == id).SingleOrDefaultAsync();
			if (prod != null)
			{
				db.AppCustomer.RemoveRange(prod);
				await Save();
				return true;
			}
			return false;
		}
	}
}
