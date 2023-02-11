using dA.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class BillRepo : RepositoriesBase
	{
		//public BillRepo() : base() { }
		public BillRepo(DoAnContext _db) : base(_db) { }

		public async Task<int> GetRowCount()
		{
			return await db.AppBill.CountAsync();
		}
		public async Task<List<AppBill>> ListAsync(int Page , int PageSize)
		{
			return await db.AppBill.OrderByDescending(x => x.Id).Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync();
		}
		public async Task<List<AppBillDetail>> GetAllDetailAsync(int id)
		{
			return await db.AppBillDetail.Include(s=>s.BillProduct).Include(x=>x.IdBillNavigation).Where(i => i.IdBill == id).OrderByDescending(x => x.IdBill).ToListAsync();
		}
		public async Task<bool> DeleteAsync(int id)
		{
			var prod = await db.AppBill.Include(x => x.AppBillDetailtNavigation).Where(i => i.Id == id).ToListAsync();
			if (prod != null)
			{
				foreach (var item in prod)
				{
					if (item.AppBillDetailtNavigation != null)
					{
						item.AppBillDetailtNavigation = null;
					}
				}
				db.AppBill.RemoveRange(prod);
				await db.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
