using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Entities
{
	[Table("AppBlogs")]
	public class AppBlog
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Summary { get; set; }
		public string Content { get; set; }
		public long Views { get; set; }
		public float Votes { get; set; }
		public bool Published { get; set; }
		public DateTime? PublishedAt { get; set; }
		public string CoverImgPath { get; set; }
		public string CoverImgThumbnailPath { get; set; }
		public string StampPath { get; set; }

		public DateTime? CreatedDate { get; set; }
		public int? UserId { get; set; }
		public int? CategoryId { get; set; }
		public AppUserAdmin Users { get; set; }
		public AppBlogCategory NewsCategory { get; set; }

	}
}
