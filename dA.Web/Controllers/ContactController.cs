using dA.Data.Entities;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dA.Web.Controllers
{
	public class ContactController : Controller
	{
		public ContactRepo ContactRepo;
		public ContactController()
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
			return View("Index", "Home");
		}
	}
}
