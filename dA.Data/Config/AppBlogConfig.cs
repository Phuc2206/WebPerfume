
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
	public class AppBlogConfig : IEntityTypeConfiguration<AppBlog>
	{
		public void Configure(EntityTypeBuilder<AppBlog> builder)
		{
			builder.ToTable(DB.AppBlog.TABLE_NAME);

			// Khóa chính
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title)
				.HasMaxLength(DB.AppBlog.TITLE_LENGTH)
				.IsRequired();

			builder.Property(x => x.Slug)
				.HasMaxLength(DB.AppBlog.SLUG_LENGTH)
				.IsRequired();

			builder.Property(x => x.Summary)
				.HasMaxLength(DB.AppBlog.SUMMARY_LENGTH)
				.IsRequired();

			builder.Property(x => x.Published)
				.HasDefaultValue(DB.AppBlog.PUBLIC_NEWS);

			builder.Property(s => s.CreatedDate)
				.HasDefaultValueSql(DB.AppBlog.DEFAULT_DATE);

			builder.Property(s => s.PublishedAt)
				.HasDefaultValue(DB.AppBlog.DEFAULT_VALUE);

			builder.Property(s => s.Votes)
				.HasDefaultValue(DB.AppBlog.COUNT);

			builder.Property(s => s.Views)
				.HasDefaultValue(DB.AppBlog.COUNT);

			builder.Property(s => s.CoverImgPath)
				.HasDefaultValue(DB.AppBlog.DEFAULT_VALUE);

			builder.HasIndex(s => s.Slug, $"uq_slug")
				.IsUnique();

			// Khóa ngoại
			builder.HasOne(s => s.NewsCategory)
				.WithMany(s => s.NewsNavigation)
				.HasForeignKey(s => s.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(s => s.Users)
				.WithMany(s => s.AppNewsNavigation)
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
