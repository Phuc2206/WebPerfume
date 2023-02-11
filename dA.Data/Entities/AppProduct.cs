using dA.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
	[Table("AppProducts")]
	public class AppProduct
	{
		public AppProduct()
		{
		}

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string UrlPicture { get; set; }
		public int? CategoryId { get; set; }
		public int? Like { get; set; }
		public int? Sold { get; set; }
		public decimal? Price { get; set; }
		public decimal? PromoPrice { get; set ; }
		public DateTime? CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public int? DisplayOrder { get; set; }
		public string Summary { get; set; }

		[ForeignKey("TrademarkId")]
		public virtual AppTrademark TrademarkNavigation { get; set; }

		[ForeignKey("CategoryId")]
		public virtual AppCategory CategoryNavigation { get; set; }
		public virtual ICollection<AppSize> ListSizeNavigation { get; set; }

		public virtual ICollection<AppPicture> ListProductPicture { get; set; }
		public virtual ICollection<AppBillDetail> AppBillDetailtNavigation { get; set; }
	}
}
