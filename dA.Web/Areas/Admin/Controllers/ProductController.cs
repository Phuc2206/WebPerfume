using dA.Data;
using dA.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using X.PagedList;
using Microsoft.AspNetCore.Http;

namespace dA.Web.Areas.Admin.Controllers
{
	public class ProductController : ControllerBase
	{
		public ProductController(CategoryRepo _RepoCategory, TrademarkRepo _TrademarkRepo, ProductRepo _RepoProduct, RepositoriesBase _Repo,
			BillRepo _RepoBill, UserCustomerRepo _CustomerRepo) : base(_RepoCategory, _TrademarkRepo, _RepoProduct, _Repo, _RepoBill, _CustomerRepo)
		{
			
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> ListProduct(int page = 1)
		{
			var resualt = await RepoProduct.ListAsync(page, PageSize);
			var rowCount = await RepoProduct.GetRowCountProduct();
			var response = new
			{
				data = resualt,
				perPage = PageSize,
				currentPage = page,
				pageCount = rowCount
			};
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AppProduct model)
		{
			var files = Request.Form.Files;
			if (files.Count >= 1)
			{
				for (int i = 0; i < files.Count; i++)
				{
					var projectPath = Directory.GetCurrentDirectory();
					var fileName = files[i].FileName;
					var fullPath = projectPath + "/wwwroot/Images/product/" + fileName;
					var stream = System.IO.File.Create(fullPath);
					await files[i].CopyToAsync(stream);
					await stream.DisposeAsync();
					var PictureName = files[i].FileName;
					model.UrlPicture = files[0].FileName;
					if (PictureName != null)
					{
						model.ListProductPicture.Add(new()
						{
							Name = PictureName
						});
					}
				}
			}	
			if (model.Id == 0)
			{
				return Ok(await RepoProduct.AddAsync(model));
			}
			return Ok(await RepoProduct.UpdateAsync(model));
		
		}


		[HttpGet]
		public async Task<IActionResult> Details()
		{
			return View();
		}

		// Lấy thông tin của sản phẩm 
		[HttpGet]
		public async Task<IActionResult> GetOneDetail(int id)
		{
			return Ok(await RepoProduct.GetOneDetailAsync(id));
		}
		// Lấy Img của chi tiết sản phẩm
		public async Task<IActionResult> GetImgDetail(int id)
		{
			return Ok(await RepoProduct.GetImgDetailAsync(id));
		}
		// Lấy one Img của sản phẩm
		public async Task<IActionResult> GetOneImg(int id)
		{
			return Ok(await RepoProduct.GetOneImgProduct(id));
		}
		// Lấy danh sách thể loại ra
		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			return Ok(await RepoProduct.GetCategories());
		}
		// Delete 
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await RepoProduct.DeleteAsync(id));
		}
	}
}
