using dA.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Config
{
	public class AppSystemConfig : IEntityTypeConfiguration<AppSystem>
	{
		public void Configure(EntityTypeBuilder<AppSystem> builder)
		{
			builder.ToTable("AppSystem");
			builder.HasKey(x => x.Key);
		}
	}
}
