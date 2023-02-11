using dA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.ViewModels
{
	public class ShoppingCartViewModel
	{
		public int Id { get; set; }
		public decimal? PriceProduct { get; set; }
		public string? UrlPicture { get; set; }
		public int? Quantity { get; set; }
		public string Name { get; set; }
		public string? Size { get; set; }
	}
}
