using dA.Data;
using dA.Data.DStringHasher;
using dA.Data.Repositories;
using dA.Web.Areas.Admin.ViewModels;
using dA.Web.Areas.Admin.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.Controllers
{
	public class UserActivityController : ControllerBase
	{
		public UserActivityController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{
		}
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(UserLoginVM model)
		{
			var user = await Repo.db.AppUserAdmin.SingleOrDefaultAsync(x => x.Username == model.Username);
	
			if (user == null || user.IsDelete == true)
			{
				TempData["Mesg"] = "Tài khoản của bạn không hợp lệ";
				return RedirectToAction("Login");
			}
			string encryptPassword = DStringHasher.HashWith(model.Password, user.Salt);
			if (user.Password == encryptPassword)
			{
				string avatarPath = user.Avatar;
				if (avatarPath == null)
				{
					avatarPath = "imgDefault.png";
				}
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Actor, avatarPath),
					new Claim(ClaimTypes.Uri, user.Name),
					new Claim(ClaimTypes.Role, user.IsSuper ? "SuperAdmin" : "Admin"),
				};
				var identities = new ClaimsIdentity(claims, "Cookies");
				var principal = new ClaimsPrincipal(identities);
				var authenProperty = new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddHours(6),
					IsPersistent = model.RememberMe
				};
				await HttpContext.SignInAsync("Cookies", principal, authenProperty);
				return RedirectToAction("Index","Home");
			}
			else
			{
				TempData["Mesg"] = "Tài khoản hoặc mật khẩu không chính xác";
			}
			return RedirectToAction("Login");
		}

		public async Task<IActionResult> DangXuat()
		{
			await HttpContext.SignOutAsync("Cookies");
			return RedirectToAction("Login");
		}
		[Authorize(Roles = "Admin, SuperAdmin")]
		public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
		{
			var findUser = Repo.db.AppUserAdmin.Find(this.CurrentUserId);
			var encryptPassword = DStringHasher.HashWith(model.Pwd, findUser.Salt);
			if (encryptPassword == findUser.Password)
			{	
				var newPass = model.NewPwd.HashWith(findUser.Salt);
				findUser.Password = newPass;
				await Repo.Save();
				if (model.isCheck == true)
				{
					return RedirectToAction(nameof(DangXuat));
				}
				return Redirect(Request.Headers["Referer"].ToString());
			}
			else
			{
				TempData["Err"] = "Mật khẩu cũ không chính xác";
			}
			return Redirect(Request.Headers["Referer"].ToString());
		}
	}
}
