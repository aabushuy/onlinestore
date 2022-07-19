using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public abstract class ControllerBase : Controller
	{
		protected string ControllerName => ControllerContext.RouteData.Values["controller"].ToString();
	}
}
