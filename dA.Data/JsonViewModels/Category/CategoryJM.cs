using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.JsonViewModels.Category
{
	public class CategoryJM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? DisplayOrder { get; set; }
		public string TrademarkId { get; set; }
		public int? TotalProduct { get; set; }
		public ICollection<AppProduct> ListProduct { get; set; }
	}
}
