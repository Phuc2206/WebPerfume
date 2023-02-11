using dA.Data;
using dA.Data.DStringHasher;
using dA.Data.Repositories;
using dA.Web.Areas.Admin.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	public class UserAdminController : ControllerBase
	{
		public UserAdminController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{

		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		//[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> AddUser(AddUserVM model)
		{
				try
				{
					var files = Request.Form.Files;
					if (files.Count >= 1)
					{
						var projectPath = Directory.GetCurrentDirectory();
						var fileName = files[0].FileName;
						var fullPath = projectPath + "/wwwroot/Images/Admin/" + fileName;
						var stream = System.IO.File.Create(fullPath);
						await files[0].CopyToAsync(stream);
						await stream.DisposeAsync();
						model.Avatar = files[0].FileName;
					}
					else
					{
						model.Avatar = "imgDefault.png";
					}
					// TODO: Đặt đường dẫn mặc định cho ảnh user
					AppUserAdmin prod = new()
					{
						Salt = model.Salt = DStringHasher.CreateSalt(),
						Password = model.Password.HashWith(model.Salt),
						Username = model.Username,
						Avatar = model.Avatar,
						Phonenumber = model.Phonenumber,
						Name = model.FullName,
						Email = model.Email,
						Address = model.Address, 
						IsSuper = model.IsSupper,
					};
					await Repo.db.AddAsync(prod);
					await Repo.Save();
					return Ok(true);
				}
				catch
				{
					return Ok(false);
				}
		}

		[HttpGet]
		public async Task<IActionResult> ListUser(int page =1)
		{
			var prod = await Repo.db.AppUserAdmin.Select(x => new UserListVM {
				Id = x.Id,
				Username = x.Username,
				Fullname = x.Name , 
				IsSuper = x.IsSuper ,
				Avatar = x.Avatar
			}).Where(u => u.Username != User.Identity.Name).OrderByDescending(x=>x.Id).Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();
			var rowCount = await Repo.db.AppUserAdmin.CountAsync();
			var response = new
			{
				data = prod,
				currentPage = page,
				perPage = PageSize,
				pageCount = rowCount-1
			};
			return Ok(response);
		}
		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> Edit(int id)
		{
			var model = await Repo.db.AppUserAdmin.FindAsync(id);
			if(model != null)
			{
				model.IsSuper = !model.IsSuper;
				await Repo.Save();
				return Ok(true);
			}
			return Ok(false);
		}

		[HttpDelete]
		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> Delete(int id)
		{
			var prod =await Repo.db.AppUserAdmin.FindAsync(id); 
			if(prod !=null)
			{
				Repo.db.AppUserAdmin.Remove(prod);
				await Repo.Save();
				return Ok(true);
			}
			return Ok(false);
		}



	}
}
