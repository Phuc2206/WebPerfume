using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Entities
{
    [Table("AppBillDetails")]
	public class AppBillDetail
	{
		public String Size { get; set; }
		public int Quantity { get; set; }
        public int IdBill { get; set; }
        public decimal? TotalProduct { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdBill")]
        public AppBill IdBillNavigation { get; set; }
        [ForeignKey("IdProduct")]
        public virtual AppProduct BillProduct { get; set; }
    }
}
