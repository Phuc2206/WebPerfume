using dA.Data;
using dA.Data.Entities;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	public class ContactController : ControllerBase
	{
		public ContactController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{ 
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AppContact model)
		{
			if (model.Id == 0)
			{
				return Ok(await ContactRepo.AddAsync(model));
			}
			return View("Index","Home");
		}
	}
}
