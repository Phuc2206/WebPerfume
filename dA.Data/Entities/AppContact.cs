using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data.Entities
{
	public class AppContact
	{
		[Key]
		public int Id { get; set; }

		//[Column(TypeName = "nvarchar")]
		[StringLength(50)]
		[Required]
		public string FullName { get; set; }
		[StringLength(100)]

		[Required]
		public string Email { get; set; }
		public DateTime? DateSent { get; set; }
		public string Message { get; set; }

		[StringLength(50)]
		public string Phone { get; set; }
	}
}
