using Microsoft.AspNetCore.Mvc;

namespace MVC_Task2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();  
        }
    }
}
