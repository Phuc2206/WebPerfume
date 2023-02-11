using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
	[Table("AppSizes")]
	public class AppSize
	{
		[Key]
		public int Id { get; set; }
		public int Name { get; set; }
		public int Quantity { get; set; }
		public int? ProductId { get; set; }

		[ForeignKey("ProductId")]
		public virtual AppProduct Product { get; set; }

	}
}
