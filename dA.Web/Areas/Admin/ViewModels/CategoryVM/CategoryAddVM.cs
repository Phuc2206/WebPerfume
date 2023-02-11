using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.ViewModels.CategoryVM
{
	public class CategoryAddVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public int TrademarkId { get; set; }
		public int? DisplayOrder { get; set; }
	}
}
