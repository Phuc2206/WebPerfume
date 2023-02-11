using dA.Data;
using dA.Data.Repositories;
using dA.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Controllers
{
	public class ShoppingCartController : Controller
	{
		public ProductRepo RepoProduct;
		public ShoppingCartController(ProductRepo _RepoProduct)
		{
			RepoProduct = _RepoProduct;
		}
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> Index()
		{
			var cookieList = Request.Cookies.Where(x => x.Key.Contains("ProductP_"))
				.ToList();
			var cokieListQuantity = Request.Cookies.Where(s => s.Key.Contains("ProductSize_")).ToList();
			List<ShoppingCartViewModel> gioHangList = new List<ShoppingCartViewModel>();
			
			foreach (var item in cookieList)
			{
				int currentID = Convert.ToInt32(item.Key.Replace("ProductP_", ""));
				AppProduct thisProduct =await RepoProduct.GetOneProduct(currentID);
				var thisSize = await RepoProduct.GetOneSizeProduct(int.Parse(item.Value));
				var thisQuantity = 1;
				foreach (var itemQuantity in cokieListQuantity)
				{
					if(currentID == Convert.ToInt32(itemQuantity.Key.Replace("ProductSize_", "")))
					{
						thisQuantity = Convert.ToInt32(itemQuantity.Value);
						break;
					}
				}

				if (thisProduct != null)
				{
					gioHangList.Add(new ShoppingCartViewModel()
					{
						Id = thisProduct.Id,
						PriceProduct = thisProduct.Price,
						Quantity = thisQuantity,
						Name = thisProduct.Name,
						UrlPicture = thisProduct.UrlPicture,
						Size = thisSize.Name.ToString()
					}) ;
				}	
			}
			return View(gioHangList);
		}


	}
}
