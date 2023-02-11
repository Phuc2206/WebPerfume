using dA.Data;
using dA.Data.Entities;
using dA.Data.Repositories;
using dA.Web.Hubs;
using dA.Web.ViewModels;
using dA.Web.ViewModels.UserCustomer;
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
	public class CheckoutController : Controller
	{
		public ProductRepo RepoProduct;
		public UserCustomerRepo RepoCustomer;
		public CheckoutRepo RepoCheckout;
		readonly RepositoriesBase _repo;
		private IHubContext<MessageHub> hubContext { get; set; }

		public CheckoutController(IHubContext<MessageHub> _hubContext, ProductRepo _RepoProduct, CheckoutRepo _RepoCheckout, RepositoriesBase repo)
		{
			RepoProduct = _RepoProduct;
			RepoCheckout = _RepoCheckout;
			_repo = repo;
			hubContext = _hubContext;
		}

		public async Task<IActionResult> CheckOutGuest()
		{
			var cookieList = Request.Cookies.Where(x => x.Key.Contains("ProductP_"))
			.ToList();
			var cokieListQuantity = Request.Cookies.Where(s => s.Key.Contains("ProductSize_")).ToList();
			List<ShoppingCartViewModel> gioHangList = new List<ShoppingCartViewModel>();
	
			foreach (var item in cookieList)
			{
				int currentID = Convert.ToInt32(item.Key.Replace("ProductP_", ""));
				AppProduct thisProduct = await RepoProduct.GetOneProduct(currentID);
				var thisSize = await RepoProduct.GetOneSizeProduct(int.Parse(item.Value));
				// đùng để Set size
				var thisQuantity = 1;
				foreach (var itemQuantity in cokieListQuantity)
				{
					if (currentID == Convert.ToInt32(itemQuantity.Key.Replace("ProductSize_", "")))
					{
						thisQuantity = Convert.ToInt32(itemQuantity.Value);
						break;
					}
				}

				gioHangList.Add(new ShoppingCartViewModel()
				{
					Id = thisProduct.Id,
					PriceProduct = thisProduct.Price,
					Quantity = thisQuantity,
					Name = thisProduct.Name,
					UrlPicture = thisProduct.UrlPicture,
					Size = thisSize.Name.ToString()
				});
			}
			return View(gioHangList);
		}

		//[HttpPost]
		//public async Task<IActionResult> CheckOutGuest(AddressUserViewModel model)
		//{
		//	var cookieList = Request.Cookies.Where(x => x.Key.Contains("ProductNP_")).ToList();
		//	var cokieListQuantity = Request.Cookies.Where(s => s.Key.Contains("ProductSize_")).ToList();
		//	List<AppBillDetail> ListBillDetail = new List<AppBillDetail>();
		//	foreach (var item in cookieList)
		//	{
		//		int currentID = Convert.ToInt32(item.Key.Replace("ProductNP_", ""));
		//		AppProduct thisProduct = await RepoProduct.GetOneProduct(currentID);
		//		var thisSize = await RepoProduct.GetOneSizeProduct(int.Parse(item.Value));

		//		// đùng để Set size
		//		var thisQuantity = 1;
		//		foreach (var itemQuantity in cokieListQuantity)
		//		{
		//			if (currentID == Convert.ToInt32(itemQuantity.Key.Replace("ProductSize_", "")))
		//			{
		//				thisQuantity = Convert.ToInt32(itemQuantity.Value);
		//				break;
		//			}
		//		}

		//		var BillDetail = new AppBillDetail()
		//		{
		//			IdProduct = currentID,
		//			Quantity = thisQuantity,
		//			TotalProduct = (thisProduct.Price ?? 0 - thisProduct.PromoPrice ?? 0) * thisQuantity,
		//			Size = thisSize.Name.ToString()
		//		};
		//		ListBillDetail.Add(BillDetail);
		//	}
		//	AppBill donDatHang = new AppBill()
		//	{
		//		Fullname = model.Name,
		//		Phonenumber = model.PhoneNumber,
		//		Addresss = model.StreetAddress + " " + model.QuanHuyen + " " + model.ThanhPho,
		//		CreateDate = DateTime.Now,
		//		Email = model.Email,
		//		AppBillDetailtNavigation = ListBillDetail
		//	};
		//	decimal priceTmp = 0;
		//	foreach (var item in donDatHang.AppBillDetailtNavigation)
		//	{
		//		priceTmp += Convert.ToDecimal(item.TotalProduct ?? 0);
		//	}
		//	donDatHang.Total = priceTmp + 35000;
		//	await RepoCheckout.AddAsync(donDatHang);
		//	return RedirectToAction("CheckoutSs", "Checkout");

		//}

		[HttpGet]
		[Authorize(AuthenticationSchemes = "Customer")]
		public async Task<IActionResult> CheckOutMenber()
		{
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.Email = "";
				ViewBag.HoVaTen = "";
				ViewBag.SoDienThoai = "";
				ViewBag.Address = "";
				AppCustomer cus = await RepoCheckout.CheckUsername(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
				ViewBag.Email = cus.Email;
				ViewBag.Name = cus.Name;
				ViewBag.PhoneNumber = cus.PhoneNumber;
				ViewBag.Address = cus.Address;
			}
			var cookieList = Request.Cookies.Where(x => x.Key.Contains("ProductP_"))
			.ToList();
			var cokieListQuantity = Request.Cookies.Where(s => s.Key.Contains("ProductSize_")).ToList();

			List<ShoppingCartViewModel> gioHangList = new List<ShoppingCartViewModel>();
			foreach (var item in cookieList)
			{
				int currentID = Convert.ToInt32(item.Key.Replace("ProductP_", ""));
				AppProduct thisProduct = await RepoProduct.GetOneProduct(currentID);
				var thisSize = await RepoProduct.GetOneSizeProduct(int.Parse(item.Value));
				// đùng để Set size
				var thisQuantity = 1;
				foreach (var itemQuantity in cokieListQuantity)
				{
					if (currentID == Convert.ToInt32(itemQuantity.Key.Replace("ProductSize_", "")))
					{
						thisQuantity = Convert.ToInt32(itemQuantity.Value);
						break;
					}
				}

				gioHangList.Add(new ShoppingCartViewModel()
				{
					Id = thisProduct.Id,
					PriceProduct = thisProduct.Price,
					Quantity = thisQuantity,
					Name = thisProduct.Name,
					UrlPicture = thisProduct.UrlPicture,
					Size = thisSize.Name.ToString()
				}); ;
			}
			return View(gioHangList);
		}

		//[HttpPost]
		//[AllowAnonymous]
		//[Authorize(AuthenticationSchemes = "Customer")]
		//public async Task<IActionResult> CheckOutMenber(AddressUserViewModel model)
		//{
		//	if (User.Identity.IsAuthenticated)
		//	{
		//		AppCustomer infoCustomer =await RepoCheckout.CheckUsername(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
		//		var cookieList = Request.Cookies.Where(x => x.Key.Contains("ProductNP_")).ToList();
		//		var cokieListQuantity = Request.Cookies.Where(s => s.Key.Contains("ProductSize_")).ToList();

		//		List<AppBillDetail> ListBillDetail = new List<AppBillDetail>();
		//		foreach (var item in cookieList)
		//		{
		//			int currentID = Convert.ToInt32(item.Key.Replace("ProductNP_", ""));
		//			AppProduct thisProduct = await RepoProduct.GetOneProduct(currentID);
		//			var thisSize = await RepoProduct.GetOneSizeProduct(int.Parse(item.Value));
		//			// đùng để Set size
		//			var thisQuantity = 1;
		//			foreach (var itemQuantity in cokieListQuantity)
		//			{
		//				if (currentID == Convert.ToInt32(itemQuantity.Key.Replace("ProductSize_", "")))
		//				{
		//					thisQuantity = Convert.ToInt32(itemQuantity.Value);
		//					break;
		//				}
		//			}

		//			var BillDetail = new AppBillDetail()
		//			{
		//				IdProduct = currentID,
		//				Quantity = thisQuantity,
		//				TotalProduct = (thisProduct.Price ?? 0 - thisProduct.PromoPrice ?? 0) * thisQuantity,
		//				Size = thisSize.Name.ToString()
		//			};
		//			ListBillDetail.Add(BillDetail);
		//		}
		//		AppBill donDatHang = new AppBill()
		//		{
		//			Fullname = infoCustomer.Name,
		//			Phonenumber = infoCustomer.PhoneNumber,
		//			Addresss = model.StreetAddress + " " + model.QuanHuyen + " " + model.ThanhPho,
		//			CreateDate = DateTime.Now,
		//			Email = infoCustomer.Email,
		//			AppBillDetailtNavigation = ListBillDetail
		//		};
		//		decimal priceTmp = 0;
		//		foreach (var item in donDatHang.AppBillDetailtNavigation)
		//		{
		//			priceTmp += Convert.ToDecimal(item.TotalProduct ?? 0);
		//		}
		//		donDatHang.Total = priceTmp;
		//		await RepoCheckout.AddAsync(donDatHang);
		//		return RedirectToAction("CheckoutSs", "Checkout");
		//	}
		//	return RedirectToAction("index", "ShoppingCart");
		//}


		[HttpPost]
		public async Task<IActionResult> CheckoutAjax(AddressUserViewModel model)
		{
			try
			{
				var cookieList = Request.Cookies.Where(x => x.Key.Contains("ProductP_"))
				.ToList();
				var cokieListQuantity = Request.Cookies.Where(s => s.Key.Contains("ProductSize_")).ToList();
				List<AppBillDetail> ListBillDetail = new List<AppBillDetail>();
				foreach (var item in cookieList)
				{
					int currentID = Convert.ToInt32(item.Key.Replace("ProductP_", ""));
					AppProduct thisProduct = await RepoProduct.GetOneProduct(currentID);
					var thisSize = await RepoProduct.GetOneSizeProduct(int.Parse(item.Value));
					// đùng để Set size
					var thisQuantity = 1;
					foreach (var itemQuantity in cokieListQuantity)
					{
						if (currentID == Convert.ToInt32(itemQuantity.Key.Replace("ProductSize_", "")))
						{
							thisQuantity = Convert.ToInt32(itemQuantity.Value);
							break;
						}
					}
					var BillDetail = new AppBillDetail()
					{
						IdProduct = currentID,
						Quantity = thisQuantity,
						TotalProduct = (thisProduct.Price ?? 0 - thisProduct.PromoPrice ?? 0) * thisQuantity,
						Size = thisSize.Name.ToString()
					};

					ListBillDetail.Add(BillDetail);
					RepoCheckout.SoluongSanPham(thisSize.Id,thisQuantity);

				}
				AppBill donDatHang = new AppBill()
				{
					Fullname = model.Name,
					Phonenumber = model.PhoneNumber,
					Addresss = model.PhuongXa + " " + model.QuanHuyen + " " + model.ThanhPho,
					CreateDate = DateTime.Now,
					Email = model.Email,
					DeliveryAddress = model.StreetAddress,
					Note = model.GhiChu,
					AppBillDetailtNavigation = ListBillDetail
				};
				decimal priceTmp = 0;
				foreach (var item in donDatHang.AppBillDetailtNavigation)
				{
					priceTmp += Convert.ToDecimal(item.TotalProduct ?? 0);
				}
				donDatHang.Total = priceTmp;
				await RepoCheckout.AddAsync(donDatHang);
				var listIdAdmin = await _repo.db.AppUserAdmin
				.Select(x => x.Id.ToString())
				.ToListAsync();
				await hubContext.Clients.All.SendAsync("ReceiveMessage", "Bạn có một đơn hàng mới!!!");

			}
			catch(Exception ex)
			{
				return Ok(false);
			}
			return Ok(true);
		}
	}
}
