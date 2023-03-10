using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
	[Table("AppTrademarks")]
	public class AppTrademark
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Avatar { get; set; }
		public virtual ICollection<AppProduct> ListProduct { get; set; }
		public virtual ICollection<AppCategory> ListCategory { get; set; }
	}
}
