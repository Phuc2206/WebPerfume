using dA.Data;
using dA.Data.Repositories;
using dA.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	public class BillController : ControllerBase
	{
		public BillController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{

		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> GetList(int page = 1)
		{
			var resualt = await RepoBill.ListAsync(page, PageSize);
			var rowCount = await RepoBill.GetRowCount();
			var response = new
			{
				data = resualt,
				currentPage = page,
				pageCount = rowCount,
				perPage = PageSize,
			};
			return Ok(response);
		}
		[HttpGet]
		public async Task<IActionResult> GetAllDetail(int id)
		{
			return Ok(await RepoBill.GetAllDetailAsync(id));
		}
		public async Task<IActionResult> Remove(int id)
		{
			return Ok(await RepoBill.DeleteAsync(id));
		}
	}
}
