using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Configuration;
using System.IO;
using dA.Web.Hubs;
using dA.Data;
using Microsoft.EntityFrameworkCore;
using dA.Web.common;
using Microsoft.Extensions.Logging;
using dA.Data.Repositories;

namespace dA.Web
{

	public class Startup
	{
		//elfinder
		public static string WebRootPath { get; private set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddDbContext<DoAnContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DACoSo2")));
			services.AddControllersWithViews();
			//dung cho dang nhap cap quyen
			services.AddAuthentication("Cookies")
				.AddCookie(
			  options =>
			  {
				  options.LoginPath = "/Admin/UserActivity/login";  // đường dẫn trang đăng nhập
				  options.ExpireTimeSpan = TimeSpan.FromHours(6); // tự đăng xuất sau 6h
				  options.Cookie.HttpOnly = true; // lý do bảo mật
				  options.AccessDeniedPath = "/Admin/ThongKe/Error403";
			  })
			.AddCookie("Customer", option =>
			{
				option.LoginPath = "/AccountCustomer/LoginCustomer";
				option.Cookie.HttpOnly = true;
				option.ExpireTimeSpan = TimeSpan.FromDays(1);
			});


			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				});


			services.AddSignalR();
			services.AddScoped<RepositoriesBase>();
			services.AddScoped<ProductRepo>();
			services.AddScoped<HomeShopRepo>();
			services.AddScoped<CategoryRepo>();
			services.AddScoped<BillRepo>();
			services.AddScoped<CheckoutRepo>();
			services.AddScoped<TrademarkRepo>();
			services.AddScoped<UserCustomerRepo>();
			//system
			services.AddDbContext<DoAnContext>(option =>
			{
				option.UseSqlServer(Configuration.GetConnectionString("DACoSo2"));
			});
			var db = services.BuildServiceProvider().GetService<DoAnContext>();

			AppSystemEnv systemEnv = new(db);
			systemEnv.LoadSysEnv();
			services.AddSingleton(systemEnv);
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			//su dung cho dang nhap 
			app.UseCookiePolicy(new CookiePolicyOptions()
			{
				MinimumSameSitePolicy = SameSiteMode.Strict
			}); 

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<MessageHub>("/messagehub");

				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			WebRootPath = env.WebRootPath;

		}
	}
}
