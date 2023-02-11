﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dA.Data
{
	public class AppPicture
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int? ProducId { get; set; }

		[ForeignKey("ProducId")]
		public virtual AppProduct ListProduct { get; set; }
		
	}
}
