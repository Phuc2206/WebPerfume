using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dA.Data;
using dA.Data.Entities;

namespace dA.Data.Repositories
{
	public class CheckoutRepo : RepositoriesBase
	{
		//public CheckoutRepo() : base() { }
		public CheckoutRepo(DoAnContext _db) : base(_db) { }
		public async Task<AppCustomer> CheckUsername(int id)
		{
			if (id != null)
			{
				return db.AppCustomer.Where(x => x.id == id).FirstOrDefault();
			}
			return (new AppCustomer());
		}
		public async Task<bool> AddAsync(AppBill model)
		{
			try
			{
				model.CreateDate = DateTime.Now;
				await db.AppBill.AddAsync(model);
				await db.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
		public void SoluongSanPham(int id, int soluong)
		{
			var de = db.AppSize.Find(id);
			de.Quantity -= soluong;
			Save();
		}

	}

}
