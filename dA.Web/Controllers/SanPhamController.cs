using dA.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Controllers
{
	public class SanPhamController : Controller
	{
		ProductRepo productRepo;
		public SanPhamController(ProductRepo _productRepo)
		{
			productRepo = _productRepo;
		}
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> Index(string searchString, int page = 1)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				var result = productRepo.ShowListProductSearch(searchString, page, 6);
				return View(result);
			}
			var data = productRepo.ShowListProduct(page, 3);
			return View(data);
		}
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> ProductDetail(int? id)
		{
			var data = await productRepo.GetDetailtProduct(id ?? 1);
			if (data == null)
			{
				return RedirectToAction("index");
			}
			return View(data);
		}

		public async Task<IActionResult> GetSize(int? id)
		{
			return Ok(await productRepo.GetListSize(id));
		}
	}

}
