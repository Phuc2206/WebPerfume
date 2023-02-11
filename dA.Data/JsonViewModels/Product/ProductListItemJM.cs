using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.JsonViewModels.Product
{
	public class ProductListItemJM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Views { get; set; }
		public int? Sold { get; set; }
		public decimal? Price { get; set; }
		public decimal? PromoPrice { get; set; }
		public string CateName { get; set; }
		public int? DisplayOrder { get; set; }
		public string ImgName { get; set; }
		public virtual ICollection<AppPicture> ListProductPicture { get; set; }
	}
}
