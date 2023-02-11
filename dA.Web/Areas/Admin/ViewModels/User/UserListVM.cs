using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.ViewModels.User
{
	public class UserListVM
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Fullname { get; set; }
		public bool IsSuper { get; set; }

		public string Avatar { get; set; }

	}
}
