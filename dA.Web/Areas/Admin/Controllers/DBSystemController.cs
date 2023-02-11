using dA.Data.Repositories;
using dA.Web.common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dA.Web.Areas.Admin.Controllers
{
	public class DBSystemController : ControllerBase
	{

		private readonly AppSystemEnv _sysEnv;
		public DBSystemController(AppSystemEnv sysEnv, CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{
			_sysEnv = sysEnv;
		}
		public IActionResult Index()
		{
			return View(_sysEnv);
		}
		[HttpPost]
		public IActionResult Update(Dictionary<string, string> model)
		{
			foreach (var item in model)
			{
				_sysEnv.UpdateSysEnv(item.Key, item.Value);
			}
			return RedirectToAction(nameof(Index));
		}

	}
}
