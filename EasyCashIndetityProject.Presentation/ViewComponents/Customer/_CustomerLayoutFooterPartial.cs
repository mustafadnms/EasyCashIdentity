using Microsoft.AspNetCore.Mvc;

namespace EasyCashIndetityProject.Presentation.ViewComponents.Customer
{
	public class _CustomerLayoutFooterPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
