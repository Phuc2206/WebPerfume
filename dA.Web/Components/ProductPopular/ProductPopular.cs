using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Components.ProductPopular
{
	[ViewComponent]
	
	public class ProductPopular : ViewComponent
	{
		readonly HomeShopRepo HomeShop;
		public ProductPopular(HomeShopRepo _HomeShop)
		{
			HomeShop = _HomeShop;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await HomeShop.GetProductPopular());
		}
	}
}
