using System;
using System.ComponentModel.DataAnnotations;

namespace dA.Web.ViewModels.Contact
{
	public class ContactVM
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string Email { get; set; }
		public DateTime? DateSent { get; set; }
		public string Message { get; set; }

		public string Phone { get; set; }
	}
}
