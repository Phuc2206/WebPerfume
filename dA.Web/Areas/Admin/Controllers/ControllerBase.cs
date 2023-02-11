using dA.Data;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class ControllerBase : Controller
	{
		protected int PageSize { get; set; }

		protected int CurrentUserId { get => Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); }

		public CategoryRepo RepoCategory;
		public TrademarkRepo TrademarkRepo;
		public ProductRepo RepoProduct;
		public RepositoriesBase Repo;
		public BillRepo RepoBill;
		public UserCustomerRepo CustomerRepo;
		public ContactRepo ContactRepo;
		
		public ControllerBase(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo, BillRepo _RepoBill, UserCustomerRepo _CustomerRepo)
		{
			PageSize = 5;
			RepoCategory = _RepoCategory;
			TrademarkRepo = _TrademarkRepo;
			RepoProduct = _RepoProduct;
			Repo = _Repo;
			RepoBill = _RepoBill;
			CustomerRepo = _CustomerRepo;


		}



	}
}
