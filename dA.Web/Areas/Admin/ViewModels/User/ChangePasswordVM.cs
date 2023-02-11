using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.ViewModels.User
{
	public class ChangePasswordVM
	{
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Bắt buộc nhập")]
		public string Pwd { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Bắt buộc nhập")]
		[MinLength(4, ErrorMessage = "Mật khẩu quá ngắn")]
		public string NewPwd { get; set; }

		[DataType(DataType.Password)]
		[Compare("NewPwd", ErrorMessage = "Mật khẩu không khớp")]
		public string ConfirmPwd { get; set; }

		public bool isCheck { get; set; }
	}
}
