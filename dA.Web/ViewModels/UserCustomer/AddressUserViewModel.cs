using dA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.ViewModels.UserCustomer
{
	public class AddressUserViewModel : AppCustomer
	{
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string StreetAddress { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string PhuongXa { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string QuanHuyen { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string ThanhPho { get; set; }
		[Required(ErrorMessage = "dử liệu bất buộc")]
		public string GhiChu { get; set; }
	}
}
