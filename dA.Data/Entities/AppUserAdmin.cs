using dA.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
	public class AppUserAdmin
	{
		public AppUserAdmin()
		{
			AppNewsNavigation = new HashSet<AppBlog>();
		}
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Phonenumber { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public bool IsSuper { get; set; }
		public bool IsDelete  { get; set; }
		public string Avatar  { get; set; }

		public ICollection<AppBlog> AppNewsNavigation { get; set; }
	}
}
