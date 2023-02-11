using dA.Data.Consts;
using dA.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Configurations
{
	public class AppBlogCategoryConfig : IEntityTypeConfiguration<AppBlogCategory>
	{
		public void Configure(EntityTypeBuilder<AppBlogCategory> builder)
		{
			builder.ToTable(DB.AppBlogCategory.TABLE_NAME);

			// Khóa chính
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title)
				.HasMaxLength(DB.AppBlogCategory.TITLE_LENGTH)
				.IsRequired();

			builder.Property(x => x.Slug)
				.HasMaxLength(DB.AppBlogCategory.SLUG_LENGTH);

			builder.Property(x => x.CreatedDate)
				.HasDefaultValueSql(DB.AppBlogCategory.DEFAULT_DATE);
		}
	}
}
