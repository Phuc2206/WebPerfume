using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Repositories
{
	public class RepositoriesBase
	{
		public readonly DoAnContext db;
		public RepositoriesBase(DoAnContext _db)
		{
			db = _db;
		}
		//public RepositoriesBase(DoAnContext database)
		//{
		//	db = database;
		//}
		public async Task Save()
		{
			await db.SaveChangesAsync();
		}

	}
}
