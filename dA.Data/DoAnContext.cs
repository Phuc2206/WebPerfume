using App.Data.Configurations;
using dA.Data.Config;
using dA.Data.Entities;
using dA.Data.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dA.Data
{
	public class DoAnContext : DbContext
	{
		public DbSet<AppCategory> AppCategory { get; set; }
		public DbSet<AppProduct> AppProduct { get; set; }
		public DbSet<AppPicture> AppPictures { get; set; }
		public DbSet<AppUserAdmin> AppUserAdmin { get; set; }
		public DbSet<AppCustomer> AppCustomer { get; set; }
		public DbSet<AppTrademark> AppTrademark { get; set; }
		public DbSet<AppBill> AppBill { get; set; }
		public DbSet<AppSize> AppSize { get; set; }
		public  DbSet<AppBillDetail> AppBillDetail { get; set; }
		public DbSet<AppBlogCategory> AppBlogCategory { get; set; }
		public DbSet<AppBlog> AppBlog  { get; set; }

		public DbSet<AppContact> AppContacts { get; set; }
		public DbSet<AppSystem> AppSystems { get; set; }
		public object SystemEnvs { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	var builder = new ConfigurationBuilder()
		//		.AddJsonFile("appsettings.json", false)
		//		.Build();
		//	optionsBuilder.UseSqlServer(builder.GetConnectionString("DACoSo2"));
		//}
		public DoAnContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//set 1 khóa chính có 2 trường
			modelBuilder.Entity<AppBillDetail>()
				.HasKey(x => new { x.IdBill, x.IdProduct });


			modelBuilder.Entity<AppBlogCategory>(entity =>
			{
				entity.HasIndex(c => c.Slug);
			});
			modelBuilder.ApplyConfiguration(new AppBlogCategoryConfig());
			modelBuilder.ApplyConfiguration(new AppBlogConfig());
			modelBuilder.ApplyConfiguration(new AppSystemConfig());
			modelBuilder.Entity<AppSystem>().SeedData();
		}

	}
}
