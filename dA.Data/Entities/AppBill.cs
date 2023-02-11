using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Entities
{
	[Table("AppBills")]
	public class AppBill
	{
        public AppBill()
        {
            AppBillDetailtNavigation = new HashSet<AppBillDetail>();
        }
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string Addresss { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }
        public string Note { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual ICollection<AppBillDetail> AppBillDetailtNavigation { get; set; }
    }
}
