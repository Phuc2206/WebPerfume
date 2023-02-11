using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
	public class AppCustomer
	{
		[Key]
		public int id { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Name { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Username { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Bắt buộc nhập")]
		[MinLength(6, ErrorMessage = "Mật khẩu quá ngắn")]
		public string Password { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Address { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Email { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Salt { get; set; }
		public bool IsLock { get; set; }
		public DateTime? CreateDate { get; set; }
	}
}
