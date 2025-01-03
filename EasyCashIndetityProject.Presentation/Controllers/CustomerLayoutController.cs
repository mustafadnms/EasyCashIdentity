using Microsoft.AspNetCore.Mvc;

namespace EasyCashIndetityProject.Presentation.Controllers
{
	public class CustomerLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
