using dA.Data;
using dA.Data.DStringHasher;
using dA.Data.Repositories;
using dA.Web.Areas.Admin.ViewModels;
using dA.Web.Hubs;
using dA.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dA.Web.Controllers
{
	public class AccountCustomerController : Controller
	{
		public RepositoriesBase Repo;
		private IHubContext<MessageHub> hubContext { get; set; }
		public AccountCustomerController(IHubContext<MessageHub> _hubContext, RepositoriesBase _Repo)
		{
			Repo = _Repo;
			hubContext = _hubContext;
		}
		[HttpGet]
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public IActionResult LoginCustomer()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> LoginCustomer(UserLoginCustomerVM model)
		{
			var user = await Repo.db.AppCustomer.SingleOrDefaultAsync(x => x.Username == model.Username);
			if (user == null)
			{
				TempData["Mesg"] = "Tài khoản của bạn không hợp lệ";
				return RedirectToAction("LoginCustomer");
			}
			if (user.IsLock == true)
			{
				TempData["Mesg"] = "Tài khoản của bạn không hợp lệ";
				return RedirectToAction("LoginCustomer");
			}
			string encryptPassword = DStringHasher.HashWith(model.Password, user.Salt);
			if (user.Password == encryptPassword)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
					new Claim(ClaimTypes.Name,user.Name),
					new Claim(ClaimTypes.Role, "Customer")
				};
				var identities = new ClaimsIdentity(claims, "Cookies");
				var principal = new ClaimsPrincipal(identities);
				var authenProperty = new AuthenticationProperties
				{
				
					ExpiresUtc = DateTime.UtcNow.AddMinutes(240)
				};
				await HttpContext.SignInAsync("Customer", principal, authenProperty);
				//await hubContext.Clients.All.SendAsync("ReceiveMessage", "Thành viên đã đăng nhập vào hệ thống!!!");
				return RedirectToAction("Index", "SanPham");
			}
			{
				TempData["Mesg"] = "Tài khoản hoặc mật khẩu không chính xác";
			}
			return RedirectToAction("LoginCustomer");
		}

		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> LogoutCustomer()
		{
			await HttpContext.SignOutAsync("Customer");
			return RedirectToAction("LoginCustomer");
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult AddUserCustomer()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> AddUserCustomer(AppCustomer model)
		{

			AppCustomer prod = new()
			{
				Salt = model.Salt = DStringHasher.CreateSalt(),
				Password = model.Password.HashWith(model.Salt),
				Username = model.Username,
				PhoneNumber = model.PhoneNumber,
				Name = model.Name,
				Email = model.Email,
				Address = model.Address,
				CreateDate = DateTime.Now
			};
			await Repo.db.AddAsync(prod);
			await Repo.Save();
			await hubContext.Clients.All.SendAsync("ReceiveMessage", "Có thêm một thành viên mới đã đăng ký Tài Khoản!!!");
			return RedirectToAction("LoginCustomer");
		}
	}
}
