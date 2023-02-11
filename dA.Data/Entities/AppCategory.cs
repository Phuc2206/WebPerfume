using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
    [Table("AppCategorys")]
    public class AppCategory
	{
        public AppCategory()
        {
            ListProduct = new HashSet<AppProduct>();
        }
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
        public string Name { get; set; }
        public int? TotalProduct { get; set; }
		public int? TrademarkId { get; set; }

        [ForeignKey("TrademarkId")]
        public virtual AppTrademark ListTrademark { get; set; }
        public virtual ICollection<AppProduct> ListProduct { get; set; }
        
    }
}
