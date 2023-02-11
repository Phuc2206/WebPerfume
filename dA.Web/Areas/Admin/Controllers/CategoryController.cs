using dA.Data;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : ControllerBase
	{

		public CategoryController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetList(int page = 1)
		{
			var resualt = await RepoCategory.ListAsync(page, PageSize);
			var rowCount = await RepoCategory.GetRowCount();
			var response = new
			{
				data = resualt,
				currentPage = page,
				pageCount = rowCount,
				perPage = PageSize,
			};
			return Ok(response);
		}

		public async Task<IActionResult> AddOrUpdate(AppCategory model)
		{
			if (model.Id == 0)
			{
				return Ok(await RepoCategory.AddAsync(model));
			}
			return Ok(await RepoCategory.UpdateAsync(model));
		}
		// Lấy List thương hiệu 
		[HttpGet]
		public async Task<IActionResult> GetItemTrademark()
		{
			return Ok(await RepoCategory.GetTrademark());
		}

		[HttpDelete]
		public async Task<IActionResult> Remove(int id)
		{
			return Ok(await RepoCategory.DeleteAsync(id));
		}
		// Lấy 1 thằng lên Update 
		[HttpGet]
		public async Task<IActionResult> GetOne(int id)
		{
			return Ok(await RepoCategory.GetOneAsync(id));
		}
	}
}
