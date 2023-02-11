//using dA.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace dA.Data.Repositories
//{
//	internal class BlogRepo : RepositoriesBase
//	{
//		public BlogRepo() : base() { }
//		public BlogRepo(DoAnContext _db) : base(_db) { }
//		public async Task<bool> AddAsync(BlogRepo model)
//		{
//			try
//			{
//				await db.AddAsync(model);
//				await db.SaveChangesAsync();
//				return true;
//			}
//			catch (Exception ex)
//			{
//				Console.WriteLine(ex.Message);
//				return false;
//			}
//		}
//		public async Task<bool> UpdateAsync(AppBlog model)
//		{
//			try
//			{
//				int id = model.IdBlog;
//				AppBlog prod = await db.AppBlog.FindAsync(id);
//				prod.Content = model.Content;
//				await db.SaveChangesAsync();
//				return true;
//			}
//			catch (Exception ex)
//			{
//				Console.WriteLine(ex.Message);
//				return false;
//			}

//		}
//	}
//}
