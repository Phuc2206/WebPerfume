using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.ViewModels.User
{
	public class AddUserVM
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Username { get; set; }

		[Required(ErrorMessage = "dử liệu bất buộc")]
		[MinLength(5, ErrorMessage = "Mật khẩu quá ngắn")]
		public string Password { get; set; }

		[Required(ErrorMessage = "dử liệu bất buộc")]
		[Compare(nameof(Password), ErrorMessage = "mật khẩu không khớp")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Email { get; set; }

		[Required(ErrorMessage ="dử liệu bất buộc")]
		public string Phonenumber { get; set; }
		public string Salt { get; set; }
		public string Avatar { get; set; }
		public string Address { get; set; }
		public bool IsSupper { get; set; }
	}
}
