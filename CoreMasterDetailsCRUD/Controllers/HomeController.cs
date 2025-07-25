using Microsoft.AspNetCore.Mvc;

namespace CoreMasterDetailsCRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
