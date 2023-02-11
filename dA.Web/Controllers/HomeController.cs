using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dA.Web.Controllers
{
	
	public class HomeController : Controller
	{

		[AllowAnonymous]
		[Authorize(AuthenticationSchemes = "Customer")]
		public IActionResult Index()
		{
			return View();
		}
		
	}
}
