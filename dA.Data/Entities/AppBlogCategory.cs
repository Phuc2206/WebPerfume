using dA.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Entities
{
	//[Table ("AppBlogCategorys")]
	public class AppBlogCategory
	{
		public AppBlogCategory()
		{
			NewsNavigation = new HashSet<AppBlog>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Content { get; set; }
		public string CoverImgPath { get; set; }

		public DateTime? CreatedDate { get; set; }
		public ICollection<AppBlog> NewsNavigation { get; set; }
	}
}
