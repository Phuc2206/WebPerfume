using dA.Data;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	public class CustomerController : ControllerBase
	{
		public CustomerController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{ }
		public IActionResult index()
		{
			return View();
		}
		public async Task<IActionResult> GetList(int page = 1)
		{
			var resualt = await CustomerRepo.ListAsync(page, PageSize);
			var rowCount = await CustomerRepo.GetRowCountCustomer();
			var response = new
			{
				data = resualt,
				perPage = PageSize,
				currentPage = page,
				pageCount = rowCount
			};
			return Ok(response);
		}
		// dùng để lấy thông tin lên modal update
		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await CustomerRepo.FindAsync(id));
		}
		public async Task<IActionResult> UpdateAsync(AppCustomer model)
		{
			return Ok(await CustomerRepo.UpdateAsync(model));
		}
		public async Task<IActionResult> Remove(int id)
		{
			return Ok(await CustomerRepo.DeleteAsync(id));
		}
	}
}
