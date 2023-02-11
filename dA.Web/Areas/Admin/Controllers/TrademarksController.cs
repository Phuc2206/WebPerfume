using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dA.Data;
using System.IO;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace dA.Web.Areas.Admin.Controllers
{

	public class TrademarksController : ControllerBase
	{
		
		public TrademarksController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) :base (_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{
			
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> GetList(int page = 1)
		{
			var resualt = await TrademarkRepo.ListAsync(page, PageSize);
			var rowCount = await TrademarkRepo.GetRowCountTradermark();
			var response = new
			{
				data = resualt,
				currentPage = page,
				pageCount = rowCount,
				perPage = PageSize,
			};
			return Ok(response);
		}	

		[HttpPost]
		public async Task<IActionResult> AddOrUpdate(AppTrademark model)
		{
			var files = Request.Form.Files;
			TrademarkRepo.AddImg(model, files);
			if (model.Id == 0)
			{
				return Ok(await TrademarkRepo.AddAsync(model));
			}
			return Ok(await TrademarkRepo.UpdateAsync(model));
		}
		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await TrademarkRepo.FindIdAsync(id));
		}
		[HttpDelete]
		public async Task<IActionResult> Remove(int id)
		{
			return Ok(await TrademarkRepo.DeleteAysnc(id));
		}
	}
}
