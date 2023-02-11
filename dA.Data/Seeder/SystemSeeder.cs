using dA.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Seeder
{
	public static class SystemSeeder
	{
		public static void SeedData(this EntityTypeBuilder<AppSystem> builder)
		{
			builder.HasData(
				new AppSystem
				{
					Key = "logo",
					Value = ""
				},
				new AppSystem
				{
					Key = "BrandName",
					Value = "PT.PerFume"
				},
				new AppSystem
				{
					Key = "Address",
					Value = "Cần Thơ"
				},
				new AppSystem
				{
					Key = "Phone",
					Value = "068686868"
				},
				new AppSystem
				{
					Key = "Email",
					Value = "vnpmphuc090701@gmail.com"
				},
				new AppSystem
				{
					Key = "DefautImg",
					Value = ""
				},
				new AppSystem
				{
					Key = "Icon",
					Value = ""
				}
				);
		}
	}
}

