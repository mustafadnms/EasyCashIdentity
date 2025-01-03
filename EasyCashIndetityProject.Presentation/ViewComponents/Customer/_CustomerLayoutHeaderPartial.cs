using Microsoft.AspNetCore.Mvc;

namespace EasyCashIndetityProject.Presentation.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }

}
