using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.JsonViewModels.Customer
{
	public class ItemCustomerJM
	{
		public int id { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public bool IsLock { get; set; }
	}
}
