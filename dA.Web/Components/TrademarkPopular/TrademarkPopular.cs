using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Components.TrademarkPopular
{
	public class TrademarkPopular : ViewComponent
	{
		private readonly HomeShopRepo HomeShop;
		public TrademarkPopular(HomeShopRepo _HomeShop)
		{
			HomeShop = _HomeShop;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			return View(await HomeShop.GetTrademarkPopular());
		}
	}
}
