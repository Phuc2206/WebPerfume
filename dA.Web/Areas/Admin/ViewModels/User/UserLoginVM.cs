using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Areas.Admin.ViewModels
{
	public class UserLoginVM
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
